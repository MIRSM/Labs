#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <string>
#include <cstring>
#include <dirent.h>
#include <ctime>

using namespace std;


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

int main(int argc,char **argv)
{
    if(argc<=1)
        cout<<"Введите имя!"<<endl;
    else
    {
        string path=(string)argv[1];
        struct stat statst;
        DIR *dir;
        dir=opendir(path.c_str());
        stat(path.c_str(), &statst);
        //if(dir!=NULL)
        if(S_ISDIR(statst.st_mode))
        {
            cout<<"Это папка\nУстанавливаем разрешение записи"<<endl;
            chmod(path.c_str(),S_IWUSR | S_IWGRP| S_IWOTH);
            stat(path.c_str(), &statst);
            char modestr[7];
            mode_to_letters(statst.st_mode, modestr);
            cout<<"Режим директории::"<<endl;
            cout<< modestr<<endl;
            closedir(dir);
        }
        else
        {
            cout<<"Это не папка: "<<path.c_str()<<endl;
        }
    }
    //cout<< (string)argv[1]<<endl;
    return 0;
}
