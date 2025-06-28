using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1.SameMethod
{
    public class MyClass1 : IWindow //, IRestaurant
    {
        public void GetMeun()
        {
            Console.WriteLine("I'm Class Meun");
        }

        //void IWindow.GetMeun()
        //{
        //    Console.WriteLine("I'm IWindow Meun");
        //}

        //void IRestaurant.GetMeun()
        //{
        //    Console.WriteLine("I'm IRestaurant Meun");
        //}
    }
}
