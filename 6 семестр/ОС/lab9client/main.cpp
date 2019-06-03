#include <sys/types.h>
#include <sys/msg.h>
#include <sys/ipc.h>
#include <string.h>
#include <stdio.h>
#include <unistd.h>
#include <iostream>

using namespace std;

bool WaitForResponse();

int main()
{
    key_t ipckey;
    int mq_id;
    char mymsg[100];
    /* Generate the ipc key */
    ipckey = ftok("/home/mirsm/lab9/sharedQueue/sendToServerQueue", 42);

    /* Set up the message queue */
    mq_id = msgget(ipckey, IPC_CREAT | 0644);

    while(true)
    {
        cout<<"Нажмите Enter, чтобы продолжить\n";
        char chr[12] ;
        cin.getline(chr,12);
        cout << "Отправляю запрос" << endl;
        msgsnd(mq_id, &mymsg, sizeof(mymsg), 0);
        while(WaitForResponse());
    }
}

bool WaitForResponse()
{
    key_t ipckey;
    int mq_id;
    char mymsg[BUFSIZ] ;
    int received;

    /* Generate the ipc key */
    ipckey = ftok("/home/mirsm/lab9/sharedQueue/sendToClientQueue", 43);

    /* Set up the message queue */
    mq_id = msgget(ipckey, 0);

    memset(mymsg, 0, sizeof(mymsg));
    received = msgrcv(mq_id, &mymsg, sizeof(mymsg), 0, 1);
    cout<<mymsg<<endl;

    return false;

}
