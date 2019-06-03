#include "Pereezd.h"

Pereezd::Pereezd()
{
    Status = 0;
    Mode = 0;
}

Pereezd::SetOpenStatus()
{
    Status=1;
    cout<<"Переезд открыт!";
}

Pereezd::~Pereezd()
{
    //dtor
}
