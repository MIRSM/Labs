using System;
using System.Collections.Generic;

namespace Tinder
{
    class Finder
    {
        public static void FindPeople(AbstractHandler handler)
        {
            foreach (var man in new List<string> { "Гендальф Белый", "Иванов Иван Иванович", "Петров Петр Петрович",
            "Пушкин Александр Сергеевич","Гарри Поттер","Достоевский Федр Михайлович"})
            {
                Console.WriteLine("-----------------------------");
                Console.Write("Поиск человека ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{man}");
                Console.ResetColor();
                Console.WriteLine("...");
                var result = handler.Handle(man);
                if (result != null)
                {
                    Console.Write("Человека по имени ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(man);
                    Console.ResetColor();
                    Console.WriteLine($" {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(man);
                    Console.ResetColor();
                    Console.WriteLine($" пропал без вести!");
                }
            }
        }
    }
}
