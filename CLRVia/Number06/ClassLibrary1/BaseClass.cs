using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BaseClass
    {
        protected int flag;

        public BaseClass()
        {
            flag = 100;
            Console.WriteLine($"Base {this.flag}");
        }

        public virtual void SealeMethod()
        {
            Console.WriteLine("Base SealeMethod");
        }

        public void Dail()
        {
            Console.WriteLine("BaseClass.Dail");
            Console.WriteLine($"Base Dail {this.flag}");
            EstablishConnection();
        }

        public virtual void EstablishConnection()
        {
            Console.WriteLine($"Base EstablishConnection {this.flag}");
            Console.WriteLine("SonClass.EstablishConnection");
        }
    }
}
