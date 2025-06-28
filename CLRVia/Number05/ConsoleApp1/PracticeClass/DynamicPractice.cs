using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.PracticeClass
{
    internal class DynamicPractice
    {
        public void DynamicDemo()
        {
            for (int i = 0; i < 2; i++)
            {
                dynamic arg = (i == 0) ? (dynamic)5 : (dynamic)"Hello";
                //dynamic arg = (i == 0) ? (dynamic)5.12M : (dynamic)"Hello";
                
                var result = Plus(arg);
                Print(result);
                //dynamic result = Plus(arg);
                //Print(result);
            }
        }

        private dynamic Plus(dynamic d)
        {
            return d + d;
        }

        private void Print(int n)
        {
            Console.WriteLine($"Int类型,值为{n.ToString()}");
        }

        private void Print(string n)
        {
            Console.WriteLine($"字符串类型,值为{n}");
        }
    }
}
