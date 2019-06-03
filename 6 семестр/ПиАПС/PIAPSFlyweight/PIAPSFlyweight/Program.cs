using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAPSFlyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FlyweightFactory(
                new Equipment { Weapon = "Двуручный меч", Body = "Кираса", Boots = "Железные сапоги" },
                new Equipment { Weapon = "Одноручный меч", Body = "Кольчуга", Boots = "Железные сапоги" },
                new Equipment { Weapon = "Кинжал", Body = "Кожаная желетка", Boots = "Кожаные сапоги" },
                new Equipment { Weapon = "Волшебный посох", Body = "Туника", Boots = "Легкие сандали" }
                );
            factory.listFlyweights();

            AddEquipmentToDataBase(factory, new Equipment
            {
                Weapon="Волшебная сфера",
                Body="Кираса",
                Boots="Легкие сандали",
                Owner="Джон"
            });

            AddEquipmentToDataBase(factory, new Equipment
            {
                Weapon = "Кинжал",
                Body = "Кожаная желетка",
                Boots = "Кожаные сапоги",
                Owner = "Джон"
            });

            AddEquipmentToDataBase(factory, new Equipment
            {
                Weapon = "Двуручный меч",
                Body = "Кираса",
                Boots = "Легкие сандали",
                Owner = "Марк"
            });

            factory.listFlyweights();
            Console.ReadKey();
        }

        public static void AddEquipmentToDataBase(FlyweightFactory factory,Equipment equipment)
        {
            Console.WriteLine("\nДобавляю экипировку в базу данных:");
            var flyweight = factory.GetFlyweight(new Equipment
            {
                Weapon = equipment.Weapon,
                Body = equipment.Body,
                Boots = equipment.Boots
            });
            flyweight.Operation(equipment);
        }
    }
}
