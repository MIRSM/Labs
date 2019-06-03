#include <iostream>
#include <fcntl.h>
#include <unistd.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <fstream>

using namespace std;

#define CHANGEPEREEZD   0
#define CHANGEBARIER    1
#define SETMANUALMODE   2
#define SETAUTOMATIC    3
#define MAKESOUNDSIGN   4
#define MAKELIGHTSIGN   5
#define STARTTRAIN      6
#define PRINTSTATUS     7

//Нажатые клавиши
#define KEY0 48
#define KEY1 49
#define KEY2 50
#define KEY3 51
#define KEY4 52

enum PereezdMode
{
    None=0,
    Manual=1,
    Automatic=2
};

struct pereezd {
    bool               BarierOpened;
    bool               PereezdOpened;
    PereezdMode        PereezdStatus;
    bool               SoundSignal;
    bool               LightSignal;
    int                DistToClose;
    int                DistToOpen;
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
int fd[2];

void CreateTrain();
void ManualMenu();
void ClearConsole();
void OpenOrCloseBarier();
void MakeSoundSignal();
void MakeLightSignal();
void OpenOrClosePereezd();
void SetAutomaticMode();
void PrintStatus();

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
    if(pipe(fd)==-1)
    {
        perror("pipe");
        return 0;
    }

    int nChild=fork();
    switch(nChild)
    {
        case 0:
        {
            pereezd Pereezd;
            Pereezd.BarierOpened=false;
            Pereezd.PereezdOpened=false;
            Pereezd.PereezdStatus=PereezdMode::None;
            Pereezd.SoundSignal=false;
            Pereezd.LightSignal=false;
            Pereezd.DistToClose=0;
            Pereezd.DistToOpen=0;
            while(1)
            {
                char buf[BUFSIZ];
                read(fd[0],buf,BUFSIZ);
                switch(buf[0]){
                    case CHANGEPEREEZD:
                    {
                        Pereezd.PereezdOpened=!Pereezd.PereezdOpened;
                        if(!Pereezd.PereezdOpened)
                        {
                            cout<<"Переезд закрыт!\n";
                        }
                        else
                        {
                            cout<<"Переезд открыт\n";
                        }
                        break;
                    }
                    case CHANGEBARIER:
                    {
                        Pereezd.BarierOpened=!Pereezd.BarierOpened;
                        if(!Pereezd.BarierOpened)
                        {
                            cout<<"Шлагбаум закрыт!\n";
                        }
                        else
                        {
                            cout<<"Шлагбаум открыт\n";
                        }
                        break;
                    }
                    case SETMANUALMODE:
                    {
                        Pereezd.PereezdStatus=PereezdMode::Manual;
                        break;
                    }
                    case SETAUTOMATIC:
                    {
                        Pereezd.PereezdStatus=PereezdMode::Automatic;
                        Pereezd.BarierOpened=true;
                        cout<<"Шлагбаум открыт\n";
                        if(buf[1]==1)
                            Pereezd.SoundSignal=true;
                        else
                            Pereezd.SoundSignal=false;
                        if(buf[2]==1)
                            Pereezd.LightSignal=true;
                        else
                            Pereezd.LightSignal=false;
                        int i=3;
                        while(buf[i]!=-1)
                        {
                            Pereezd.DistToOpen+=buf[i++];
                        }
                        i++;
                        while(buf[i]!=-1)
                        {
                            Pereezd.DistToClose+=buf[i++];
                        }
                        cout<<"Параметры заданы!\n";
                        break;
                    }
                    case MAKESOUNDSIGN:
                        {
                            cout<<"Звуковой сигнал подан!\n";
                            break;
                        }
                    case MAKELIGHTSIGN:
                        {
                            cout<<"Световой сигнал подан!\n";
                            break;
                        }
                    case STARTTRAIN:
                        {
                            cout<<"Поезд поехал\n";
                            int dist=500;
                            if(dist<Pereezd.DistToClose)
                                dist=Pereezd.DistToClose+100;
                            cout<<"Расстояние от поезда до переезда: "<<dist<<endl;
                            while(dist-100>=Pereezd.DistToClose)
                            {
                                dist-=100;
                                cout<<"Поезд приближается. Расстояние от поезда до переезда: "<<dist<<endl;
                            }
                            dist=Pereezd.DistToClose;
                            cout<<"Расстояние от поезда до переезда: "<<dist<<endl;
                            cout<<"Переезд закрывается\n";
                            if(Pereezd.SoundSignal)
                                cout<<"Звуковой сигнал подан!\n";
                            if(Pereezd.LightSignal)
                                cout<<"Световой сигнал подан!\n";
                            Pereezd.BarierOpened=!Pereezd.BarierOpened;
                            if(!Pereezd.BarierOpened)
                            {
                                cout<<"Шлагбаум закрыт!\n";
                            }
                            else
                            {
                                cout<<"Шлагбаум открыт\n";
                            }
                            while(dist-100>0)
                            {
                                dist-=100;
                                cout<<"Расстояние от поезда до переезда: "<<dist<<endl;
                            }
                            dist=0;
                            cout<<"Расстояние от поезда до переезда: "<<dist<<endl;
                            while(dist+100<=Pereezd.DistToOpen)
                            {
                                dist+=100;
                                cout<<"Поезд отдаляется. Расстояние от поезда до переезда: "<<dist<<endl;
                            }
                            dist=Pereezd.DistToOpen;
                            cout<<"Поезд отдаляется. Расстояние от поезда до переезда: "<<dist<<endl;

                            Pereezd.BarierOpened=!Pereezd.BarierOpened;
                            if(!Pereezd.BarierOpened)
                            {
                                cout<<"Шлагбаум закрыт!\n";
                            }
                            else
                            {
                                cout<<"Шлагбаум открыт\n";
                            }
                            char bf=1;
                            write(fd[1],&bf,sizeof(bf));
                            break;
                        }
                    case PRINTSTATUS:
                    {
                        if(Pereezd.PereezdOpened)
                        {
                            cout<<"Переезд открыт\n";
                        }
                        else
                        {
                            cout<<"Переезд закрыт\n";
                            break;
                        }
                        cout<<"Режим переезда: ";
                        switch(Pereezd.PereezdStatus)
                        {
                            case PereezdMode::None:
                                cout<<"Не установлен\n";
                                break;
                            case PereezdMode::Manual:
                                cout<<"Ручное управление\n";
                                if(Pereezd.BarierOpened)
                                    cout<<"Шлагбаум открыт\n";
                                else
                                    cout<<"Шлагбаум закрыт\n";
                                break;
                            case PereezdMode::Automatic:
                                cout<<"Автоматическое управление\n";
                                if(Pereezd.BarierOpened)
                                    cout<<"Шлагбаум открыт\n";
                                else
                                    cout<<"Шлагбаум закрыт\n";
                                cout<<"Подача звукового сигнала: ";
                                if(Pereezd.SoundSignal)
                                    cout<<"Включена\n";
                                else
                                    cout<<"Выключена\n";
                                cout<<"Подача светового сигнала: ";
                                if(Pereezd.LightSignal)
                                    cout<<"Включена\n";
                                else
                                    cout<<"Выключена\n";
                                cout<<"Расстояние до закрытия шлагбаума: "<<Pereezd.DistToClose<<endl;
                                cout<<"Расстояние до открытия шлагбаума: "<<Pereezd.DistToOpen<<endl;
                                break;
                        }
                        break;
                    }
                }
            }
            break;
            }
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
            }
            break;
    }
    return 0;
}

void ManualMenu()
{
    char buf=SETMANUALMODE;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
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
    char buf=STARTTRAIN;
    write(fd[1],&buf,sizeof(buf));
    sleep(2);
}

void ClearConsole()
{
    system("clear");
}

void OpenOrCloseBarier()
{
    BarierOpened=!BarierOpened;
    char buf=CHANGEBARIER;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
}

void MakeSoundSignal()
{
    char buf=MAKESOUNDSIGN;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
}

void MakeLightSignal()
{
    char buf=MAKELIGHTSIGN;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
}

void OpenOrClosePereezd()
{
    char buf=CHANGEPEREEZD;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
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
    cin.get();
    char buf[BUFSIZ];
    buf[0]=SETAUTOMATIC;
    if(SoundSignal)
        buf[1]=1;
    else
         buf[1]=2;
    if(LightSignal)
         buf[2]=1;
    else
         buf[2]=2;
    int i=3;
    while(DistToOpen>=127)
    {
        buf[i++]=127;
        DistToOpen-=127;
    }
    buf[i++]=DistToOpen;
    buf[i++]=-1;
    while(DistToClose>=127)
    {
        buf[i++]=127;
        DistToClose-=127;
    }
    buf[i++]=DistToClose;
    buf[i]=-1;
    write(fd[1],buf,BUFSIZ);
    BarierOpened=true;
    sleep(1);
}

void PrintStatus()
{
    char buf=PRINTSTATUS;
    write(fd[1],&buf,sizeof(buf));
    sleep(1);
}
