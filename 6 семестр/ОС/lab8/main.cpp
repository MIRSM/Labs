#include <iostream>
#include <fcntl.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include <sys/wait.h>

using namespace std;

int main(int argc,char **argv)
{
    int fd[2];
    if(pipe(fd)==-1)
    {
        perror("pipe");
        return 0;
    }
    char path[BUFSIZ];
    cin.getline(path,BUFSIZ);

    int pid=fork();
    if(pid==0){
        char outPath[BUFSIZ];
        read(fd[0],outPath,BUFSIZ);

        int fHandle;
        if((fHandle=open(outPath,O_RDONLY))==-1)
        {
            write(fd[1],"Такого файла нет",30);
            _exit(0);
        }
        char buf[BUFSIZ];
        while(read(fHandle,buf,BUFSIZ)>0)
        {
            write(fd[1],buf,BUFSIZ);
        }
        close(fHandle);
        _exit(0);
    }
    else
    {
        write(fd[1],path,strlen(path));
        close(fd[1]);
        wait(0);
        int fHandle;
        char *ppointer=path;
        while(*ppointer!='\0')
        {
                *ppointer++;
        }
        *ppointer++='.';
        *ppointer++='r';
        *ppointer++='e';
        *ppointer++='s';
        *ppointer++='u';
        *ppointer++='l';
        *ppointer++='t';

        if((fHandle=open(path,O_RDWR|O_TRUNC|O_CREAT,888))==-1)
        {
            char newPath[BUFSIZ];
            char *point=newPath;
            *point++='.';
            strcat(newPath,path);
            fHandle=open(newPath,O_RDWR|O_TRUNC|O_CREAT,888);
        }
        char Buff[BUFSIZ];
        while(read(fd[0],Buff,BUFSIZ)>0)
        {
            write(fHandle,Buff,strlen(Buff));
        }
        close(fHandle);
    }

    return 0;
}
