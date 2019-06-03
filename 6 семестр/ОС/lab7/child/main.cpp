#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>

using namespace std;

main(int argc,char *argv[])
{
    cout <<"Child PID: "<<getpid()<<endl;
    cout <<"Child PPID: "<<getppid()<<endl;

}
