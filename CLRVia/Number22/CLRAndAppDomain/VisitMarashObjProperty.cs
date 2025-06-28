using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRAndAppDomain
{
    public class VisitMarashObjProperty
    {
        public void VisitObjProperty()
        {
            MyMerashObj obj1 = new MyMerashObj();
            obj1.Name = "zhangsan";
            obj1.Age = 25;

            MyObj obj2 = new MyObj();
            obj2.Name = "zhangsan";
            obj2.Age = 25;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch w1 = new Stopwatch();
                w1.Start();
                for (int j = 0; j < 100000; j++)
                {
                    int age = obj1.Age;
                    string name = obj1.Name;
                    //obj1.Age = 25;
                    //obj1.Name = "zhangsan";
                }
                Console.WriteLine("MerashObj:" + w1.ElapsedTicks.ToString());

                w1.Restart();
                for (int j = 0; j < 100000; j++)
                {
                    int age = obj2.Age;
                    string name = obj2.Name;
                    //obj2.Age = 25;
                    //obj2.Name = "zhangsan";
                }
                Console.WriteLine("NormalObj:" + w1.ElapsedTicks.ToString());
                Console.WriteLine();
            }
        }
    }

    public class MyMerashObj : MarshalByRefObject
    {
        public int Age;

        public string Name;
    }

    public class MyObj : Object
    {
        public int Age;

        public string Name;
    }
}
