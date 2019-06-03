#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include <fcntl.h>
#include <pthread.h>
#include <iostream>

#define ReadDir "/home/mirsm/file1"
#define WriteDir "/home/mirsm/file2"

using namespace std;
int flagw=1;

static char* readPath()
{
    char line[100];
    cin.getline(line,100);
    return line;
}

int main()
{
    int fdRead=open(ReadDir,O_RDONLY);
    int fdWrite=open(WriteDir,O_WRONLY);
    if(fdRead==-1 || fdWrite==-1)
    {
        perror("Не удалось открыть файл ");
        return 1;
    }

    while(flagw)
    {
        char *path=readPath();
        if(write(fdWrite,path,strlen(path))!=strlen(path))
        {
            perror("Ошибка записи в канал ");
            return 1;
        }
        free(path);

        cout<<"\nЧтобы выйти нажмите любую клавишу\n";
        cin>>;
        flagw=0;
    }

    if(fdRead!=-1) close(fdRead);
    if(fdWrite!=-1)close(fdWrite);

    return 0;
}
