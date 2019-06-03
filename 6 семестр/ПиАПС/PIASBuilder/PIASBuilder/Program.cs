using System;

namespace PIASBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Builder();
            var director = new Director();
            director.Builder = builder;
            Console.WriteLine("Пример рыботы директора:");
            Console.WriteLine("Минимальная карта:");
            director.buildMinimalMap();
            Console.WriteLine(builder.GetProduct().ListFloors());

            Console.WriteLine("Полная карта:");
            director.buildFullMap();
            Console.WriteLine(builder.GetProduct().ListFloors());

            Console.WriteLine("Килент может сам выбирать последовательность построения:");
            builder.BuildWestStreets();
            builder.BuildNorthStreets();
            builder.BuildSouthStreets();
            builder.BuildEastStreets();
            Console.WriteLine(builder.GetProduct().ListFloors());
            Console.ReadKey();
        }
    }
}
