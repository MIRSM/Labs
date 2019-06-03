using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PIAPSFlyweight
{
    public class Flyweight
    {
        private Equipment _EquipmentVar;

        public Flyweight(Equipment equipment)
        {
            this._EquipmentVar = equipment;
        }

        public void Operation(Equipment uniqueEquipment)
        {
            string s = JsonConvert.SerializeObject(this._EquipmentVar);
            string u = JsonConvert.SerializeObject(uniqueEquipment);
            Console.WriteLine($"Flyweight: Общие поля: {s},\n уникальные поля: {u}.");
        }
    }

    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Equipment[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

        // Возвращает хеш строки Легковеса для данного состояния.
        public string getKey(Equipment key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.Body);
            elements.Add(key.Boots);
            elements.Add(key.Weapon);

            if (key.Owner != null)
            {
                elements.Add(key.Owner);
            }

            elements.Sort();

            return string.Join(", ", elements);
        }

        // Возвращает существующий Легковес с заданным состоянием или создает
        // новый.
        public Flyweight GetFlyweight(Equipment _EquipmentVar)
        {
            string key = this.getKey(_EquipmentVar);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: данного варианта снаряжения ранее не было, регистрирую новый.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(_EquipmentVar), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Используется ранее созданный вариант снаряжения.");
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void listFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: В моей базе {count} объектов flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}
