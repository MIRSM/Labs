#include <fcntl.h>
#include <sys/types.h>
#include <sys/msg.h>
#include <sys/ipc.h>
#include <stdio.h>
#include <unistd.h>
#include <iostream>
#include <string.h>

#define TEMP_PATH "/home/mirsm/Рабочий стол/lab9server/tempFile"

using namespace std;

bool SendRespone(char*);

int main (void)
{

    key_t ipckey;
    int mq_id;
    //struct { long type; char text[BUFSIZ]; } mymsg;
    char mymsg[100];
    /* Generate the ipc key */
    ipckey = ftok("/home/mirsm/lab9/sharedQueue/sendToServerQueue", 42);
    //printf("My key is %d\n", ipckey);

    /* Set up the message queue */
    mq_id = msgget(ipckey, 0);

    int received;

    while(true)
    {
        key_t outIpckey;
        int outMq_id;
        char outmsg[BUFSIZ];
        memset(outmsg,0,BUFSIZ);
        received = msgrcv(mq_id, &mymsg, sizeof(mymsg), 0, 1);

        system("ps > tempFile");

        int fHandle=-1;
        if((fHandle=open("tempFile",O_RDONLY))==-1)
        {
            perror("Не удалось открыть временный файл!");
            return false;
        }

        /* Send a message */
        if(read(fHandle,outmsg,BUFSIZ)==0)
        {
            perror("read");
            return 1;
        }
        close(fHandle);
        remove("tempFile");

        outIpckey= ftok("/home/mirsm/lab9/sharedQueue/sendToClientQueue", 43);

        /* Set up the message queue */
        outMq_id= msgget(outIpckey, IPC_CREAT | 0644);

        cout<<outmsg<<endl;

        msgsnd(outMq_id, &outmsg, sizeof(outmsg), 0);
    }
    return 0;
}

bool SendRespone(char* buf)
{
    sleep(1);
}
