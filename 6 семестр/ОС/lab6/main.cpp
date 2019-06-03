#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fstream>
#include <string>
#include <cstring>
#include <iostream>

using namespace std;

#define READ_FILE_PATH "/home/mirsm/lab6/text"
#define WRITE_FILE_PATH "/home/mirsm/lab6/outText"


void mode_to_letters( int mode, char str[] )
{
    strcpy( str, "------" );           /* default=no perms */
    if ( mode & S_IRGRP ) str[0] = 'r';    /* 3 bits for group */
    if ( mode & S_IWGRP ) str[1] = 'w';
    if ( mode & S_IXGRP ) str[2] = 'x';

    if ( mode & S_IROTH ) str[3] = 'r';    /* 3 bits for other */
    if ( mode & S_IWOTH ) str[4] = 'w';
    if ( mode & S_IXOTH ) str[5] = 'x';
}


int main()
{
    char text[256];
    cout<<"Введите текст:"<<endl;
    cin.getline(text,256);
    char *pText=text;
    int iText=0;
    while(*pText!='\0')
    {
        iText++;
        *pText++;
    }
    int fHandle;
    char modestr[7];
    struct stat statReadFile;
    if((fHandle=open(READ_FILE_PATH ,O_RDWR | O_TRUNC))==-1)
    {
        perror("Не удалось открыть первый файл\n");
        exit(1);
    }
    stat(READ_FILE_PATH,&statReadFile);

    mode_to_letters(statReadFile.st_mode, modestr);
    cout<<"Разрешения первого файла:"<<endl;
    cout<< modestr<<endl;
    //cout<<text<<endl;
    write(fHandle,text,iText);

    int fOutHandle;
    struct stat statWriteFile;
    if((fOutHandle=open(WRITE_FILE_PATH ,O_WRONLY | O_TRUNC))==-1)
    {
        perror("Не удалось открыть второй файл\n");
        exit(1);
    }
    stat(WRITE_FILE_PATH,&statWriteFile);
    mode_to_letters(statReadFile.st_mode, modestr);
    cout<<"Разрешения второго файла:"<<endl;
    cout<< modestr<<endl;
//printf("%d, %d",fHandle, fOutHandle);

    char buf[256];
    //size_t bufSize=sizeof(buf);
    //ssize_t readedSize;
    //while((readedSize=read(fHandle,buf,bufSize))>0)
    {
        char *p=text;
        char *q=buf;
        int i=0;
        bool checked=false;
        while(*p)
        {
            if(*p!=' ')
            {
                *q++=*p;
                i++;
                checked=false;
            }
            else if(*p==' ' && !checked)
            {
                *q++=*p;
                i++;
                checked=true;
            }
            ++p;
        }
        *q='\0';
        //printf(buf);
        write(fOutHandle,buf,i);
    }
    /*if(readedSize==-1)
    {
        perror("Не считать информацию из первого файла\n");
        close(fHandle);
        close(fOutHandle);
        exit(1);
    }*/
    close(fHandle);
    close(fOutHandle);
    stat(WRITE_FILE_PATH,&statWriteFile);
    printf("Размер второго файла: %ld\n",statWriteFile.st_size);

    return 0;
}
