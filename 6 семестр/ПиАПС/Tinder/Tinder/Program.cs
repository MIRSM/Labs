using System;

namespace Tinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Passersby passersby = new Passersby();
            Phonebook phonebook = new Phonebook();
            Internet internet = new Internet();

            passersby.SetNext(phonebook).SetNext(internet);

            Console.WriteLine("Цепочка поиска: passerby -> phonebook -> internet");
            Finder.FindPeople(passersby);
            Console.WriteLine();

            Console.WriteLine("Цепочка поиска: phonebook -> internet");
            Finder.FindPeople(phonebook);
            Console.ReadKey();
        }
    }
}


