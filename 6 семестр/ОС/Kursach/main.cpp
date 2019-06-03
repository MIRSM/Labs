#include <iostream>
#include <fcntl.h>
#include <signal.h>
#include <unistd.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <fstream>

using namespace std;
#define CH_NAME         "/home/mirsm/Рабочий стол/Pereezd/bin/Debug/Pereezd"
#define PEREEZDPIDFILE  "/home/mirsm/Рабочий стол/Pereezd/PereezdPid"
#define CONSOLEPIDFILE "/home/mirsm/Рабочий стол/Kursach/ConsolePid"
#define PEREEZDPARAMS   "/home/mirsm/Рабочий стол/Pereezd/PereezdParams"

//Нажатые клавиши

#define KEY0 48
#define KEY1 49
#define KEY2 50
#define KEY3 51
#define KEY4 52

//Сигналы
#define SIGPZD  1
#define SIGMAN  2
#define SIGAUT  3
#define SIGCHK  4
#define SIGBAR  5
#define SIGTRN  6
#define SIGSND  7
#define SIGLGT  8


enum PereezdMode
{
    None=0,
    Manual=1,
    Automatic=2
};

bool                PereezdOpened;
PereezdMode         PereezdStatus;
bool                BarierOpened;
bool                SoundSignal;
bool                LightSignal;
int                 DistToClose;
int                 DistToOpen;
int                 PereezdPid;
bool                contin;

void CreateTrain();
void GetSignal(int sig);
void ManualMenu();
void ClearConsole();
void OpenOrCloseBarier();
void MakeSoundSignal();
void MakeLightSignal();
void OpenOrClosePereezd();
void SetAutomaticMode();
void PrintStatus();
void SetContin(int sig);

int main()
{
    cout<<"Добро пожаловать в систему управления ж/д переездом!"<<endl;
    contin=true;
    PereezdOpened=false;
    PereezdStatus=PereezdMode::None;
    BarierOpened=false;
    SoundSignal=false;
    LightSignal=false;
    DistToClose=0;
    DistToOpen=0;
    ofstream fout(CONSOLEPIDFILE);
    fout<<getpid();
    fout.close();
    ifstream fin(PEREEZDPIDFILE);
    fin>>PereezdPid;
    fin.close();
    signal(SIGABRT,SetContin);
    //PereezdPid=getpid()+1;
    int nChild=fork();
    switch(nChild)
    {
        case 0:
            //execl(CH_NAME,"Pereezd",NULL);
            break;
        default:
            sleep(1);
            while(1)
            {
                cout<<"Навигация по меню:\n";
                if(!PereezdOpened)
                {
                    cout<<"1 -- Открыть переезд\n2 -- Посмотреть состояние переезда\n0 -- Выйти из системы\n";
                }
                else
                {
                    cout<<"1 -- Закрыть переезд\n";
                    if(PereezdStatus==PereezdMode::None)
                    {
                        cout<<"2 -- Включить ручной режим управления\n3 -- Включить автоматический режим управления\n";
                        cout<<"4 -- Посмотреть состояние переезда\n0 -- Выйти из системы\n";
                    }
                    if(PereezdStatus==PereezdMode::Manual)
                    {
                        cout<<"2 -- Вернуться к ручному управлению\n";
                        cout<<"3 -- Включить автоматический режим управления\n";
                        cout<<"4 -- Посмотреть состояние переезда\n0 -- Выйти из системы\n";
                    }
                    if(PereezdStatus==PereezdMode::Automatic)
                    {
                        cout<<"2 -- Включить ручной режим управления\n";
                        cout<<"3 -- Вывести состояние переезда\n4 -- Запустить поезд\n0 -- Выйти из системы\n";
                    }
                }
                //так считывается ключ
                //int kkk=getchar();
                int key=cin.get();
                cin.get();
                cout<<key<<endl;
                ClearConsole();
                switch(key)
                {
                    case KEY0:
                        return 0;
                    case KEY1:
                        OpenOrClosePereezd();
                        break;
                    case KEY2:
                        if(PereezdOpened)
                        {
                            PereezdStatus=PereezdMode::Manual;
                            ManualMenu();
                        }
                        else
                        {
                            PrintStatus();
                        }
                        break;
                    case KEY3:
                        if(PereezdOpened)
                        {
                            if(PereezdStatus==PereezdMode::None ||PereezdStatus==PereezdMode::Manual)
                            {
                                SetAutomaticMode();
                            }
                            else
                            {
                                PrintStatus();
                            }
                        }
                        else
                        {
                            cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
                        }
                        break;
                    case KEY4:
                        if(PereezdOpened && PereezdStatus!=PereezdMode::Automatic)
                            PrintStatus();
                        else
                        {
                            if(PereezdStatus==PereezdMode::Automatic)
                            {
                                if(!BarierOpened)
                                {
                                    OpenOrCloseBarier();
                                }
                                CreateTrain();
                            }
                            else
                            {
                                cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
                            }
                        }
                        break;
                    default:
                        cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
                        break;
                }
                while(!contin)
                {

                }
            }
            break;
    }
    return 0;
}

void ManualMenu()
{
    kill(PereezdPid,SIGMAN);
    while(1)
    {
        cout<<"Навигация по меню:\n";
        if(BarierOpened)
            cout<<"1 -- Закрыть шлагбаум\n";
        else
            cout<<"1 -- Открыть шлагбаум\n";
        cout<<"2 -- Подать звуковой сигнал\n";
        cout<<"3 -- Подать световой сигнал\n0 -- Назад\n";
        int key=cin.get();
        cin.get();
        ClearConsole();
        switch(key)
        {
            case KEY0:
                return;
            case KEY1:
                OpenOrCloseBarier();
                break;
            case KEY2:
                MakeSoundSignal();
                break;
            case KEY3:
                MakeLightSignal();
                break;
            default:
                cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
                break;
        }
    }
}

void CreateTrain()
{
    contin=false;
    kill(PereezdPid,SIGTRN);
}

void ClearConsole()
{
    system("clear");
}

void OpenOrCloseBarier()
{
    BarierOpened=!BarierOpened;
    kill(PereezdPid,SIGBAR);
}

void MakeSoundSignal()
{
    kill(PereezdPid,SIGSND);
}

void MakeLightSignal()
{
    kill(PereezdPid,SIGLGT);
}

void OpenOrClosePereezd()
{
    kill(PereezdPid,SIGPZD);
    if(PereezdOpened)
    {
        PereezdOpened=false;
        PereezdStatus=PereezdMode::None;
    }

    else
    {
        PereezdOpened=true;
    }
}

void SetAutomaticMode()
{
    PereezdStatus=PereezdMode::Automatic;
    while(1)
    {
        cout<<"Включить подачу звукового сигнала?\n1 -- Да, 2 -- Нет\n";
        int key=cin.get();
        cin.get();
        bool founded=false;
        switch(key)
        {
            case KEY1:
                SoundSignal=true;
                founded=true;
                break;
            case KEY2:
                SoundSignal=false;
                founded=true;
                break;
            default:
                founded=false;
                break;
        }
        if(founded)
            break;
        cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
    }

    while(1)
    {
        cout<<"Включить подачу светового сигнала?\n1 -- Да, 2 -- Нет\n";
        int key=cin.get();
        cin.get();
        bool founded=false;
        switch(key)
        {
            case KEY1:
                LightSignal=true;
                founded=true;
                break;
            case KEY2:
                LightSignal=false;
                founded=true;
                break;
            default:
                founded=false;
                break;
        }
        if(founded)
            break;
        cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
    }

    while(1)
    {
        cout<<"Введите на какое расстояние, в метрах, должен отдалиться поезд, чтобы шлагбаум открылся:\n";
        try
        {
            cin>>DistToOpen;
            if(DistToOpen<0)
                throw new exception();
            break;
        }catch(...){
            cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
        }
    }

    while(1)
    {
        cout<<"Введите на какое расстояние, в метрах, должен приблизиться поезд, чтобы шлагбаум закрылся:\n";
        try
        {
            cin>>DistToClose;
            if(DistToClose<0)
            throw new exception();
            break;
        }catch(...){
            cout<<"Введен неверный символ! Пожалуйста, повторите попытку:\n";
        }
    }
    ofstream fout(PEREEZDPARAMS);
    cin.get();
    if(SoundSignal)
        fout<<"1 ";
    else
        fout<<"2 ";
    if(LightSignal)
        fout<<"1 ";
    else
        fout<<"2 ";
    fout<<DistToOpen<<" ";
    fout<<DistToClose<<" ";
    fout.close();
    BarierOpened=true;
    kill(PereezdPid,SIGAUT);
}

void PrintStatus()
{
    kill(PereezdPid,SIGCHK);
    sleep(1);
}

void SetContin(int sig)
{
    contin=true;
}
/*
kill(getpid()+1,SIGINT);
sleep(1);
*/
