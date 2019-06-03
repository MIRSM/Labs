#ifndef PEREEZD_H
#define PEREEZD_H

enum PereezdStatus
{
    Closed = 0,
    Opened = 1
}

enum PereezdMode
{
    None = 0,
    Manual = 1,
    Automatic = 2
}

class Pereezd
{
    public:
        Pereezd();
        SetOpenStatus();
        SetClosedStatus();
        EnableAutomaticMode();
        EnableManualMode()
        virtual ~Pereezd();

    protected:

    private:
        PereezdStatus Status;
        PereezdMode Mode;
        bool SoundSignal;
        bool LightSignal;
        int OpenDist;
        int CloseDist;
        bool BarrierOpened;
};

#endif // PEREEZD_H
