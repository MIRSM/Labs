#include <unistd.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <pthread.h>
#include <sys/wait.h>
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <fstream>
#include <signal.h>

#define BIGSEMNAME      "/BigSem"
#define SMALLSEMNAME    "/SmallSem"
#define MEMORY          "./buffer"

using namespace std;
static pthread_mutex_t SmallMutex=PTHREAD_MUTEX_INITIALIZER;
static pthread_mutex_t BigMutex=PTHREAD_MUTEX_INITIALIZER;

void* Reader(void *p)
{
    while(1)
    {
        pthread_mutex_lock(&SmallMutex);
        cout<<"Зашел "<<(int *)p<<endl;
        ifstream fin(MEMORY);
        char buf[BUFSIZ];
        for(int i=0;i<10;i++)
        {
            fin>>buf;
            cout<<"Процесс читатель "<<(int*)p<<": "<<buf<<endl;
        }
        fin.close();
        pthread_mutex_unlock(&SmallMutex);
        usleep(100);
        pthread_mutex_lock(&BigMutex);
        pthread_mutex_lock(&BigMutex);
    }
}

void* Writer(void *p)
{
    usleep(1);
    pthread_mutex_lock(&SmallMutex);
    cout<<"Писатель работает"<<endl;
    ofstream fout(MEMORY);

    for(int i=0;i<10;i++)
    {
        char buf[16];
        sprintf(buf,"Изменил%d ",i);
        fout<<(buf);
    }
    fout.close();
    cout<<"Писатель перестал работать"<<endl;
    pthread_mutex_unlock(&SmallMutex);
}
void interupt(int sig)
{
    exit(0);
}

int main(void)
{
    signal(SIGINT,interupt);
    int flag = 1;
    int flagOfPrint = 1;

    pthread_t thReader1;
    pthread_t thReader2;
    pthread_t thReader3;
    pthread_t thReader4;
    pthread_t thWriter;

    ofstream fout(MEMORY);
    for(int i=0;i<10;i++)
    {
        char buf[16];
        sprintf(buf,"Процесс%d ",i);
        fout.write(buf,16);
    }
    fout.close();
    cout<<("Сейчас два читателя будут выводить информацию,\nпотом два ее изменят и читатели вновь будут ее выводить\n");

    pthread_create(&thReader1,NULL,Reader,(void*)1);
    pthread_create(&thReader2,NULL,Reader,(void*)2);
    pthread_create(&thReader3,NULL,Reader,(void*)3);
    pthread_create(&thReader4,NULL,Reader,(void*)4);
    pthread_create(&thWriter,NULL,Writer,NULL);

    pthread_join(thReader1,NULL);

    return 0;
}
