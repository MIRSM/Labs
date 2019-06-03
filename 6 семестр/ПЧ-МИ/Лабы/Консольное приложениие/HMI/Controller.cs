using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HMI
{
    struct structTrain
    {
        public int DistDoPereezd;
        public int DistOtPereezd;
        public Timer Timer;

    }

    class Controller
    {
        public structTrain train;

        public Controller()
        {

        }

        public bool OpenPereezd(ref Pereezd pereezd)
        {
            if (pereezd.Status != PereezdStatus.Closed)
                return false;
            pereezd.SetOpenStatus();
            return true;
        }

        public bool ClosePereezd(ref Pereezd pereezd)
        {
            if (pereezd.Status != PereezdStatus.Opened)
                return false;
            pereezd.SetClosedStatus();
            return true;
        }

        public bool SetManualMode(ref Pereezd pereezd)
        {
            if (pereezd.Status != PereezdStatus.Opened || pereezd.Mode == PereezdMode.Manual)
                return false;
            pereezd.EnableManualMode();
            return true;
        }

        public void OpenOrCloseBarier(ref Pereezd pereezd)
        {
            pereezd.BarrierOpened = !pereezd.BarrierOpened;
            string message = pereezd.BarrierOpened ? "Шлагбаум открыт!" : "Шлагбаум закрыт!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            return;
        }

        public bool MakeLightSignal(ref Pereezd pereezd)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Световой сигнал подан!");
            Console.ResetColor();
            return true; ;
        }

        public bool MakeSoundSignal(ref Pereezd pereezd)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Звуковой сигнал подан!");
            Console.ResetColor();
            return true;
        }

        public bool SetAutomaticMode(ref Pereezd pereezd)
        {
            if (pereezd.Status != PereezdStatus.Opened || pereezd.Mode == PereezdMode.Automatic)
                return false;

            bool bSoundSignal = false;
            bool founded = false;
            while (true)
            {
                Console.WriteLine("Включить подачу звукового сигнала?\n1 -- Да, 2 -- Нет:");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        bSoundSignal = true;
                        founded = true;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        bSoundSignal = false;
                        founded = true;
                        break;
                    default:
                        founded = false;
                        break;
                }
                if (founded)
                    break;
                Console.WriteLine("Введен неверный символ! Пожалуйста, повторите попытку:");
            }

            bool bLightSignal = false;
            founded = false;
            while (true)
            {
                Console.WriteLine("Включить подачу светового сигнала?\n1 -- Да, 2 -- Нет:");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        bLightSignal = true;
                        founded = true;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        bLightSignal = false;
                        founded = true;
                        break;
                    default:
                        founded = false;
                        break;
                }
                if (founded)
                    break;
                Console.WriteLine("Введен неверный символ! Пожалуйста, повторите попытку:");
            }

            int nOpenDist = 100;
            while (true)
            {
                Console.WriteLine("Введите на какое расстояние, в метрах, должен отдалиться поезд, чтобы шлагбаум открылся:");
                try
                {
                    nOpenDist = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введен неверный символ! Пожалуйста, повторите попытку:");
                }
            }

            int nCloseDist = 100;
            while (true)
            {
                Console.WriteLine("Введите на какое расстояние, в метрах, должен приблизиться поезд, чтобы шлагбаум закрылся:");
                try
                {
                    nCloseDist = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введен неверный символ! Пожалуйста, повторите попытку:");
                }
            }

            pereezd.EnableAutomaticMode();
            pereezd.SoundSignal = bSoundSignal;
            pereezd.LightSignal = bLightSignal;
            pereezd.OpenDist = nOpenDist;
            pereezd.CloseDist = nCloseDist;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Параметры заданы!");
            Console.ResetColor();
            CreateTrain(ref pereezd);
            return true;
        }

        public void CreateTrain(ref Pereezd pereezd)
        {
            if(!pereezd.BarrierOpened)
                OpenOrCloseBarier(ref pereezd);
            train = new structTrain();
            Random rnd = new Random();
            train.DistDoPereezd = rnd.Next(200, 1000);
            train.Timer = new Timer(TrainTimer_Tick, pereezd, 0, 100);
            train.DistOtPereezd = 0;
        }

        public void TrainTimer_Tick(object state)
        {
            Pereezd pereezd = (Pereezd)state;
            if (train.DistDoPereezd > pereezd.CloseDist)
            {
                Console.WriteLine($"Поезд подъезжает. Расстояние от поезда до переезда: {train.DistDoPereezd}");
                if (train.DistDoPereezd - 50 <= pereezd.CloseDist)
                {
                    train.DistDoPereezd = pereezd.CloseDist;
                }
                else
                    train.DistDoPereezd -= 50;
            }
            else
            {
                if (pereezd.BarrierOpened)
                {
                    Console.WriteLine($"Поезд подъехал. Расстояние от поезда до переезда: {train.DistDoPereezd}");
                    if (pereezd.LightSignal)
                        MakeLightSignal(ref pereezd);
                    if (pereezd.SoundSignal)
                        MakeSoundSignal(ref pereezd);
                    OpenOrCloseBarier(ref pereezd);
                }
                if (train.DistOtPereezd < pereezd.OpenDist)
                {
                    Console.WriteLine($"Поезд отъезжает. Расстояние от переезда до поезда: {train.DistOtPereezd}");
                    if (train.DistOtPereezd + 50 >= pereezd.OpenDist)
                    {
                        train.DistOtPereezd = pereezd.OpenDist;
                    }
                    else
                        train.DistOtPereezd += 50;
                }
                else
                {
                    Console.WriteLine($"Поезд отъехал. Расстояние от переезда до поезда: {train.DistOtPereezd}");
                    OpenOrCloseBarier(ref pereezd);
                    train.Timer.Dispose();
                }
            }
        }
    }
}
