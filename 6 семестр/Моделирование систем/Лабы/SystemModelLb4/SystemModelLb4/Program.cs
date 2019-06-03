using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModelLb4
{
    class Program
    {

        static int RCount = 0;
        static int OCount = 0;
        static int[] Rmas;
        static int[] Omas;
        static double[] Pmas;
        static double K = 0;
        static double[,] Amas;
        static FileStream FileStream = new FileStream("Output.txt", FileMode.Create);
        static StreamWriter StreamWriter = new StreamWriter(FileStream);

        static void Main(string[] args)
        {   
            InputData();

            WithVarO();
            CritVald();
            CritRiskSevidj();
            CritPesOptGurv();
            StreamWriter.Close();
            Console.ReadKey();
        }

        static void InputData()

        {
            Console.WriteLine("Введите кол-во решений:");
            bool norm = true;
            while (norm)
            {
                try
                {
                    RCount = Convert.ToInt32(Console.ReadLine());
                    norm = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено некорректное число!\n Повторите попытку");
                }
            }
            //RCount = 3; //пример
            //RCount = 4; // задание

            Console.WriteLine("Введите кол-во обстановок:");
            norm = true;
            while (norm)
            {
                try
                {
                    OCount = Convert.ToInt32(Console.ReadLine());
                    norm = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено некорректное число!\n Повторите попытку");
                }
            }

            //OCount = 3; // пример и задание

            Rmas = new int[RCount];
            Omas = new int[OCount];
            Pmas = new double[OCount];
            Amas = new double[RCount, OCount];

            //пример
            /*Amas[0, 0] = 0.25;
            Amas[0, 1] = 0.35;
            Amas[0, 2] = 0.4;
            Amas[1, 0] = 0.7;
            Amas[1, 1] = 0.2;
            Amas[1, 2] = 0.3;
            Amas[2, 0] = 0.8;
            Amas[2, 1] = 0.1;
            Amas[2, 2] = 0.35;*/

            //Задание
            /*Amas[0, 0] = 0.55;
            Amas[0, 1] = 0.8;
            Amas[0, 2] = 0.5;
            Amas[1, 0] = 0.1;
            Amas[1, 1] = 0.65;
            Amas[1, 2] = 0.35;
            Amas[2, 0] = 0.2;
            Amas[2, 1] = 0.25;
            Amas[2, 2] = 0.75;
            Amas[3, 0] = 0.15;
            Amas[3, 1] = 0.3;
            Amas[3, 2] = 0.4;*/

            for (int i = 0; i < RCount; i++)
            {
                for (int j = 0; j < OCount; j++)
                {
                    Console.WriteLine($"Введите выигрыш A({i + 1},{j + 1})");
                    norm = true;
                    while (norm)
                    {
                        try
                        {
                            Amas[i, j] = Convert.ToDouble(Console.ReadLine());
                            norm = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введено некорректное число!\n Повторите попытку");
                        }
                    }
                }
            }

            //Пример
           /* Pmas[0] = 0.5;
            Pmas[1] = 0.3;
            Pmas[2] = 0.2;*/

            //Задание
            /*Pmas[0] = 0.4;
            Pmas[1] = 0.2;
            Pmas[2] = 0.4;*/

            for (int i = 0; i < OCount; i++)
            {
                Console.WriteLine($"Введите вероятность обстановки P({i + 1}):");
                norm = true;
                while (norm)
                {
                    try
                    {
                        Pmas[i] = Convert.ToDouble(Console.ReadLine());
                        norm = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Введено некорректное число!\n Повторите попытку");
                    }
                }
            }

            //пример
            //K = 0.5;

            //задание
            //K = 0.4;

            Console.WriteLine($"Введите коэффициент K:");
            norm = true;
            while (norm)
            {
                try
                {
                    K = Convert.ToDouble(Console.ReadLine());
                    norm = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено некорректное число!\n Повторите попытку");
                }
            }

            StreamWriter.WriteLine("Решение производственной задачи:");
            StreamWriter.WriteLine($"Количество решений: {RCount}");
            StreamWriter.WriteLine($"Количество вариантов обстановки: {OCount}");
            StreamWriter.WriteLine("Таблица эффективности:");
            for(int i = 0; i < RCount; i++)
            {
                for(int j = 0; j < OCount; j++)
                {
                    StreamWriter.Write($"{Amas[i,j]}\t");
                }
                StreamWriter.WriteLine();
            }
            StreamWriter.WriteLine($"Вектор вероятностей вариантов обстановки:");
            for(int i = 0; i < OCount; i++)
            {
                StreamWriter.Write($"{Pmas[i]}\t");
            }
            StreamWriter.WriteLine();
            StreamWriter.WriteLine($"Коэффициент K:\n{K}");
        }

        static void WithVarO()
        {
            Console.WriteLine("Выбор наилучшего решения в случае известных вероятностей вариантов обстановки");
            StreamWriter.WriteLine("Выбор наилучшего решения в случае известных вероятностей вариантов обстановки");
            double max = 0; ;
            int iter=0;
            double[] L = new double[RCount];
            for (int i = 0; i < RCount; i++)
            {
                for (int j = 0; j < OCount; j++)
                {
                    L[i] += Amas[i, j] * Pmas[j];
                }
                Console.WriteLine($"L({i + 1})={L[i]}");
                StreamWriter.WriteLine($"L({i + 1})={L[i]}");
                if (L[i]>max)
                {
                    max = L[i];
                    iter = i;
                }
            }
            Console.WriteLine($"Решение R({iter+1}) является оптимальным");
            StreamWriter.WriteLine($"Решение R({iter + 1}) является оптимальным");
        }

        static void CritVald()
        {
            Console.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по минимальному критерию Вальда");
            StreamWriter.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по минимальному критерию Вальда");

            double[] L = new double[RCount];
            for(int i = 0; i < RCount; i++)
            {
                L[i] = 1;
                for(int j = 0; j < OCount; j++)
                {
                    if(Amas[i,j]<L[i])
                    {
                        L[i] = Amas[i, j];
                    }
                }
                Console.WriteLine($"L({i+1})={L[i]}");
                StreamWriter.WriteLine($"L({i + 1})={L[i]}");
            }
            int iter = 0;
            double max = 0;
            for(int i = 0; i < RCount; i++)
            {
                if (L[i] > max)
                {
                    max = L[i];
                    iter = i;
                }
            }
            Console.WriteLine($"Решение R({iter+1}) является оптимальным");
            StreamWriter.WriteLine($"Решение R({iter + 1}) является оптимальным");
        }

        static void CritRiskSevidj()
        {
            Console.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по минимаксному критерию риска Сэвиджа");
            StreamWriter.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по минимаксному критерию риска Сэвиджа");
            Console.WriteLine("Таблица риска:");
            StreamWriter.WriteLine("Таблица риска:");

            double[,] Bmas = new double[RCount,OCount];
            for(int i = 0; i < OCount; i++)
            {
                double max = 0;
                for(int j = 0; j < RCount; j++)
                {
                    if (Amas[j, i] > max)
                        max = Amas[j, i];
                }
                for (int j = 0; j < RCount; j++)
                {
                    Bmas[j, i] = max - Amas[j, i];
                }
            }

            double[] Smas = new double[RCount];
            
            for(int i = 0; i < RCount; i++)
            {
                double max = 0;
                for(int j = 0; j < OCount; j++)
                {
                    if (Bmas[i, j] > max)
                        max = Bmas[i, j];
                    Console.Write($"{Bmas[i,j]}\t");
                    StreamWriter.Write($"{Bmas[i, j]}\t");
                }
                Smas[i] = max;
                Console.WriteLine();
                StreamWriter.WriteLine();
            }

            int iter = 0;
            double min = 1;
            for(int i = 0; i < RCount; i++)
            {
                if (Smas[i] < min)
                {
                    iter = i;
                    min = Smas[i];
                }
                Console.WriteLine($"S({i+1}) = {Smas[i]}");
                StreamWriter.WriteLine($"S({i + 1}) = {Smas[i]}");
            }
            Console.WriteLine($"Наилучшим решением является R({iter+1}), для которого минимальный из максимальных рисков равен {min}");
            StreamWriter.WriteLine($"Наилучшим решением является R({iter + 1}), для которого минимальный из максимальных рисков равен {min}");

        }

        static void CritPesOptGurv()
        {
            Console.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по критерию пессимизма - оптимизма Гурвица");
            StreamWriter.WriteLine("Выбор наилучшего решения в случае неизвестных вероятностей вариантов обстановки по критерию пессимизма - оптимизма Гурвица");

            double[] Gmas = new double[RCount];

            int iter = 0;
            double Gmax = 0;
            Console.WriteLine("Вектор G:");
            StreamWriter.WriteLine("Вектор G:");

            for (int i = 0; i < RCount; i++)
            {
                double min = 1;
                double max = 0;
                for(int j = 0; j < OCount; j++)
                {
                    if (Amas[i, j] > max)
                        max = Amas[i, j];
                    if (Amas[i, j] < min)
                        min = Amas[i, j];
                }
                Gmas[i] = K * min + (1 - K) * max;
                if (Gmas[i]>Gmax)
                {
                    Gmax = Gmas[i];
                    iter = i;
                }
                Console.Write($"{Gmas[i]}\t");
                StreamWriter.Write($"{Gmas[i]}\t");
            }
            Console.WriteLine();
            StreamWriter.WriteLine();
            Console.WriteLine($"Оптимальным решением в данном случае будет R({iter+1}) = {Gmax}, при котором показатель G будет максимален");
            StreamWriter.WriteLine($"Оптимальным решением в данном случае будет R({iter + 1}) = {Gmax}, при котором показатель G будет максимален");
        }
    }
}
