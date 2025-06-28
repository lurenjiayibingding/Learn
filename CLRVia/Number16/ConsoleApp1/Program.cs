using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3] {
                new Person("龙傲天",30),
                new Person("叶良臣",23),
                new Person("王大锤",33),
            };
            PersonCollection1 personCollectioon = new PersonCollection1(persons);

            foreach (var item in personCollectioon)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("****");

            var enumerator = ((IEnumerable)personCollectioon).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.ToString());
            }
            Console.WriteLine("****");

            PersonCollection2 collection2 = new PersonCollection2(persons);
            foreach (var item in collection2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("****");

            PersonCollection3 collection3 = new PersonCollection3(persons);
            foreach (var item in collection3)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("****");

            PersonCollection4 collection4 = new PersonCollection4(persons);
            foreach (var item in collection4)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
