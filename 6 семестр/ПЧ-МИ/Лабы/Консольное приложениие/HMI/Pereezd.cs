using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI
{
    class Pereezd
    {
        //private PereezdStatus status;
        public PereezdStatus Status;
        public PereezdMode Mode;
        public bool SoundSignal;
        public bool LightSignal;
        public int OpenDist;
        public int CloseDist;
        public bool BarrierOpened;

        public Pereezd()
        {
            Status = PereezdStatus.Closed;
            Mode = PereezdMode.None;
        }

        public void SetOpenStatus()
        {
            Status = PereezdStatus.Opened;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Переезд открыт!");
            Console.ResetColor();
        }

        public void SetClosedStatus()
        {
            Status = PereezdStatus.Closed;
            Mode = PereezdMode.None;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Переезд закрыт!");
            Console.ResetColor();
        }

        public void EnableAutomaticMode()
        {
            Mode = PereezdMode.Automatic;
            //ChangeParams(soundSignal, lightSignal, opendDist, closeDist);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Включен автоматический режим управления!");
            Console.ResetColor();
        }

        public void EnableManualMode()
        {
            Mode = PereezdMode.Manual;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Включен ручной режим управления!");
            Console.ResetColor();
        }

        /*public bool OpenOrCloseBarier()
        {
            if (Mode != PereezdMode.Manual)
                return false;
            BarrierOpened = !BarrierOpened;
            string message = BarrierOpened ? "Шлагбаум открыт!" : "Шлагбаум закрыт!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            return true;
        }*/ 

        /*public bool MakeLightSignal()
        {
            if (Mode != PereezdMode.Manual)
                return false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Световой сигнал подан!");
            Console.ResetColor();
            return true;
        }*/

        /*public bool MakeSoundSignal()
        {
            if (Mode != PereezdMode.Manual)
                return false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Звуковой сигнал подан!");
            Console.ResetColor();
            return true;
        }*/

        /*private void ChangeParams(bool soundSignal,bool lightSignal,int opendDist,int closeDist)
        {
            SoundSignal = soundSignal;
            LightSignal = lightSignal;
            OpenDist = opendDist;
            CloseDist = closeDist;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Параметры заданы!");
            Console.ResetColor();
        }*/
    }
}
