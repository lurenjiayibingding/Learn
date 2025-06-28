using ConsoleApp1.CustomClass;
using System;
using c1 = ConsoleApp1.CustomClass1;
using c1c = ConsoleApp1.CustomClass1.NamespaceClass;

namespace ConsoleApp1
{
    class Program
    {
        //class System { };


        static void Main(string[] args)
        {
            //CloneClass cc1 = new CloneClass
            //{
            //    IntValue = 100,
            //    IntArray = new int[4] { 1, 2, 3, 4 }
            //};

            //CloneClass cc2 = cc1.MyClone();

            //foreach (var item in cc2.IntArray)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //for (int i = 0; i < cc1.IntArray.Length; i++)
            //{
            //    cc1.IntArray[i] = cc1.IntArray[i] * -1;
            //}

            //foreach (var item in cc2.IntArray)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //TypeConvert tc = new TypeConvert { ConvertProperty1 = 100, ConvertProperty2 = "100" };

            //TypeConvert1 t1 = new TypeConvert1 { Property1 = 100, Property2 = "100" };
            //Console.WriteLine(t1.ConvertProperty1.ToString() + t1.ConvertProperty2);
            //TypeConvert2 t2 = t1;
            //t2.Property1 = 200;
            //t2.Property2 = "200";
            //Console.WriteLine(t1.ConvertProperty1.ToString() + t1.ConvertProperty2);

            //TypeConvert1 t1 = null;
            //TypeConvert tc = t1 as TypeConvert;
            //if (tc != null)
            //{
            //    tc.ConvertProperty1 = 100;
            //    tc.ConvertProperty2 = "100";
            //    Console.WriteLine(t1.ConvertProperty1.ToString() + t1.ConvertProperty2);
            //}

            //int c1c = 100;
            //Console.WriteLine(c1c);

            //c1.NamespaceClass nc = new c1.NamespaceClass();
            //c1::NamespaceClass nc2 = new c1.NamespaceClass();
            //c1c c1C = new c1c();

            //global::System.Console.WriteLine("");


            //int Console = 100;
            //global::System.Console.WriteLine(Console);

            Employee e = new Manager();
            e.GetYearsEmployee();
            Console.WriteLine(e.GenProgressReport());
            Console.WriteLine(Employee.GetName());



            System.Console.ReadKey();
        }
    }
}