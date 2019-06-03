using System;
using System.Timers;

namespace HMI
{
    public enum PereezdStatus
    {
        Closed = 0,
        Opened = 1
    }

    public enum PereezdMode
    {
        None = 0,
        Manual = 1,
        Automatic = 2
    }

    class Program
    {
        static Pereezd pereezd;
        static Controller controller;
        
        static void Main(string[] args)
        {   
            pereezd = new Pereezd();
            controller = new Controller();

            Console.WriteLine("Добро пожаловать в систему управления переездом!");
            while (true)
            {
                if (pereezd.Status == PereezdStatus.Closed)
                    Console.WriteLine("Навигация по меню:\n1 -- Открыть переезд\n2 -- Посмотреть состояние переезда\n0 -- Выйти из системы");
                else
                {
                    Console.WriteLine("Навигация по меню:\n1 -- Закрыть переезд");
                    if (pereezd.Mode == PereezdMode.None)
                    {
                        Console.WriteLine("2 -- Включить ручной режим управления\n3 -- Включить автоматический режим управления");
                        Console.WriteLine("4 -- Посмотреть состояние переезда\n0 -- Выйти из системы");
                    }
                    if (pereezd.Mode == PereezdMode.Manual)
                    {
                        Console.WriteLine("2 -- Включить автоматический режим управления");
                        Console.WriteLine("3 -- Посмотреть состояние переезда\n0 -- Выйти из системы");
                    }
                    if (pereezd.Mode == PereezdMode.Automatic)
                    {
                        Console.WriteLine("2 -- Включить ручной режим управления");
                        Console.WriteLine("3 -- Посмотреть состояние переезда\n4 -- Запустить поезд\n0 -- Выйти из системы");
                    }
                }
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                Console.Clear();
                switch (consoleKey)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        return;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (pereezd.Status == PereezdStatus.Closed)
                            controller.OpenPereezd(ref pereezd);
                        else
                            controller.ClosePereezd(ref pereezd);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (pereezd.Status == PereezdStatus.Opened)
                        {
                            if (pereezd.Mode == PereezdMode.None || pereezd.Mode == PereezdMode.Automatic)
                                ManualMenu();
                            else
                                controller.SetAutomaticMode(ref pereezd);
                        }
                        else
                        {
                            CheckPereezdStatus();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (pereezd.Status == PereezdStatus.Opened)
                        {
                            if (pereezd.Mode == PereezdMode.None)
                                controller.SetAutomaticMode(ref pereezd);
                            else
                            {
                                CheckPereezdStatus();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введен неверный символ!Пожалуйста, повторите попытку:");
                            Console.ResetColor();
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (pereezd.Status == PereezdStatus.Opened && pereezd.Mode == PereezdMode.None)
                            CheckPereezdStatus();
                        else
                        {
                            if (pereezd.Mode == PereezdMode.Automatic)
                            {
                                if (!pereezd.BarrierOpened)
                                    controller.OpenOrCloseBarier(ref pereezd);
                                controller.CreateTrain(ref pereezd);
                            }
                            else
                            {   Console.WriteLine("Введен неверный символ!Пожалуйста, повторите попытку:");
                                Console.ResetColor();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Введен неверный символ!Пожалуйста, повторите попытку:");
                        Console.ResetColor();
                        break;
                }
            }
        }
        
        static void CheckPereezdStatus()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (pereezd.Status == PereezdStatus.Closed)
            {
                Console.WriteLine($"Состояние переезда: Закрыт");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу, чтобы перейти назад");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine($"Состояние переезда: Открыт");
            string message;
            if (pereezd.Mode == PereezdMode.None)
                message = "Не задан";
            if (pereezd.Mode == PereezdMode.Automatic)
            {
                Console.WriteLine("Режим управления: Автоматический режим");
                Console.WriteLine($"Дистанция закрытия шлагбаума: {pereezd.CloseDist}м");
                Console.WriteLine($"Дистанция открытия шлагбаума: {pereezd.OpenDist}м");
                message = pereezd.SoundSignal ? "Включена" : "Отключена";
                Console.WriteLine($"Подача звукового сигнала: {message}");
                message = pereezd.LightSignal ? "Включена" : "Отключена";
                Console.WriteLine($"Подача светового сигнала: {message}");
            }
            else if (pereezd.Mode == PereezdMode.Manual)
            {
                Console.WriteLine("Режим управления: Ручной режим");
                message = pereezd.BarrierOpened ? "Открыт" : "Закрыт";
                Console.WriteLine($"Состояние шлагбаума: {message}");
            }
            Console.ResetColor();
            Console.WriteLine("Нажмите любую клавишу, чтобы перейти назад");
            Console.ReadKey(true);
        }

        static void ManualMenu()
        {
            while (true)
            {
                controller.SetManualMode(ref pereezd);
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Навигация по меню:");
                if (pereezd.BarrierOpened)
                    Console.WriteLine("1 -- Закрыть шлагбаум");
                else
                    Console.WriteLine("1 -- Открыть шлагбаум");
                Console.WriteLine("2 -- Подать звуковой сигнал");
                Console.WriteLine("3 -- Подать световой сигнал\n0 -- Назад");
                Console.ResetColor();
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                Console.Clear();
                switch (consoleKey)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        return;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        controller.OpenOrCloseBarier(ref pereezd);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        controller.MakeSoundSignal(ref pereezd);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        controller.MakeLightSignal(ref pereezd);
                        break;
                    default:
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введен неверный символ!Пожалуйста, повторите попытку:");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
