#include <iostream>
#include <signal.h>
#include <unistd.h>
#include <fstream>

using namespace std;

//Сигналы
#define SIGPZD  1
#define SIGMAN  2
#define SIGAUT  3
#define SIGCHK  4
#define SIGBAR  5
#define SIGTRN  6
#define SIGSND  7
#define SIGLGT  8

#define KEY1 49
#define KEY2 50

#define PEREEZDPIDFILE "/home/mirsm/Рабочий стол/Pereezd/PereezdPid"
#define CONSOLEPIDFILE "/home/mirsm/Рабочий стол/Kursach/ConsolePid"
#define PEREEZDPARAMS   "/home/mirsm/Рабочий стол/Pereezd/PereezdParams"
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
pereezd Pereezd;
int                 ConsolePid;

void OpenOrCloseBarier(int sig);
void OpenOrClosePereezd(int sig);
void PrintStatus(int sig);
void ClearConsole();
void SetManualMode(int sig);
void SetAutomaticMode(int sig);
void StartTrain(int sig);
void MakeSoundSignal(int sig);
void MakeLightSignal(int sig);

int main()
{
    ConsolePid=-1;
    ofstream fout(PEREEZDPIDFILE);
    fout<<getpid();
    fout.close();
    Pereezd.BarierOpened=false;
    Pereezd.PereezdOpened=false;
    Pereezd.PereezdStatus=PereezdMode::None;
    Pereezd.SoundSignal=false;
    Pereezd.LightSignal=false;
    Pereezd.DistToClose=0;
    Pereezd.DistToOpen=0;

    signal(SIGBAR,OpenOrCloseBarier);
    signal(SIGPZD,OpenOrClosePereezd);
    signal(SIGCHK,PrintStatus);
    signal(SIGTRN,StartTrain);
    signal(SIGMAN,SetManualMode);
    signal(SIGAUT,SetAutomaticMode);
    signal(SIGSND,MakeSoundSignal);
    signal(SIGLGT,MakeLightSignal);

    while(1)
    {

    }
    return 0;
}


void OpenOrCloseBarier(int sig)
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
}

void OpenOrClosePereezd(int sig)
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
}

void PrintStatus(int sig)
{
    if(Pereezd.PereezdOpened)
    {
        cout<<"Переезд открыт\n";
    }
    else
    {
        cout<<"Переезд закрыт\n";
        return;
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
}

void ClearConsole()
{
    printf("\E[H\E[2J");
}

void SetManualMode(int sig)
{
    Pereezd.PereezdStatus=PereezdMode::Manual;
}

void SetAutomaticMode(int sig)
{
    Pereezd.PereezdStatus=PereezdMode::Automatic;
    Pereezd.BarierOpened=true;
    cout<<"Шлагбаум открыт\n";
    ifstream fin(PEREEZDPARAMS);
    int nBuf;
    fin>>nBuf;
    if(nBuf==1)
        Pereezd.SoundSignal=true;
    else
        Pereezd.SoundSignal=false;
    fin>>nBuf;
    if(nBuf==1)
        Pereezd.LightSignal=true;
    else
        Pereezd.LightSignal=false;
    fin>>Pereezd.DistToOpen;
    fin>>Pereezd.DistToClose;
    fin.close();
    cout<<"Параметры заданы!\n";
}

void StartTrain(int sig)
{
    ifstream fin(CONSOLEPIDFILE);
    fin>>ConsolePid;
    fin.close();
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
        MakeSoundSignal(1);
    if(Pereezd.LightSignal)
        MakeLightSignal(1);
    OpenOrCloseBarier(1);
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

    OpenOrCloseBarier(1);
    kill(ConsolePid,SIGABRT);
}

void MakeLightSignal(int sig)
{
    cout<<"Световой сигнал подан!\n";
}

void MakeSoundSignal(int sig)
{
    cout<<"Звуковой сигнал подан!\n";
}
