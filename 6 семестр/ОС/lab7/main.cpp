#include <iostream>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/time.h>
#include <signal.h>
#include <unistd.h>
#include <time.h>
#include <fcntl.h>

using namespace std;
#define WRITE_FILE_PATH "/home/mirsm/Рабочий стол/lab7/protocol"
int main()
{
    unsigned int start_time=clock();
    itimerval oVal1;
    itimerval oVal2;
    timeval tParams;
    itimerval inRealVal;
    itimerval inVirtVal;

    tParams.tv_sec=10;
    tParams.tv_usec=0;
    inRealVal.it_value=tParams;
    inRealVal.it_interval=tParams;
    inVirtVal.it_value=tParams;
    inVirtVal.it_interval=tParams;
    setitimer(ITIMER_REAL,&inRealVal,NULL);
    setitimer(ITIMER_VIRTUAL,&inVirtVal,NULL);
    int nChildId=fork();
    switch(nChildId)
    {
        case -1:
            cout<<"Произошла ошибка при создании процесса!"<<endl;
            return 0;
        case 0:
            cout <<"Child PID: "<<getpid()<<endl;
            cout <<"Child PPID: "<<getppid()<<endl;
            sleep(1);
            system("ps >file1");
            break;
        default:
            cout << "Main PID: "<<getpid()<< endl;
            cout<<"Main PPID: "<<getppid()<<endl;
            system("ps >file2");

    for(int i=0;i<100;i++){
    int b=1;
    b=b+1;
    }
    sigset_t mask;
    sigemptyset(&mask);

    sigaddset(&mask,SIGHUP);
    sigaddset(&mask,SIGBUS);
    sigaddset(&mask,SIGALRM);
    sigaddset(&mask,SIGABRT);

    int fOutHandle;
    if((fOutHandle=open(WRITE_FILE_PATH ,O_WRONLY | O_TRUNC))==-1)
    {
        perror("Не удалось файл для сигналов\n");
        exit(1);
    }

    cout<<endl<<"Полученная маска: "<<endl;
    write(fOutHandle,"First mask:\n",12);
    for(int i=1;i<NSIG;i++){
        switch(sigismember(&mask,i)){
            case -1:
            cout<<"Signal "<<i<<" illegal\t";
            break;
            case 1:
            cout<<"Signal "<<i<<" set\t";
            write(fOutHandle,"1",1);
            sigdelset(&mask,i);
            break;
            case 0:
            cout<<"Signal "<<i<<" not set\t";
            write(fOutHandle,"0",1);
            sigaddset(&mask,i);
            break;}
            if(!((i+1)%3)) cout<<endl;
    }
    cout<<endl;
    cout<<"Полученная инверсионная маска: "<<endl;
    write(fOutHandle,"\nInversed mask:\n",16);
    for(int i=1;i<NSIG;i++){
        switch(sigismember(&mask,i)){
            case -1:
            cout<<"Signal "<<i<<" illegal\t";
            break;
            case 1:
            cout<<"Signal "<<i<<" set\t";
            write(fOutHandle,"1",1);
            break;
            case 0:
            cout<<"Signal "<<i<<" not set\t";
            write(fOutHandle,"0",1);
            break;}
            if(!((i+1)%3)) cout<<endl;
    }
cout<<endl;

    getitimer(ITIMER_REAL,&oVal2);
    getitimer(ITIMER_VIRTUAL,&oVal1);
    unsigned int end_time=clock();
    cout<<"Real time: "<<inRealVal.it_interval.tv_sec-oVal2.it_value.tv_sec + oVal2.it_value.tv_usec/1000000.0;
    cout<<"\nVirtual time: "<<inVirtVal.it_interval.tv_sec-oVal1.it_value.tv_sec + oVal1.it_value.tv_usec/1000000.0;
    cout<<"\nTime: "<<end_time-start_time<<" ms\n";
    break;
    }

    return 0;
}
