using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SonClass : BaseClass
    {
        public SonClass()
        {
            flag = 200;
            Console.WriteLine($"Son {this.flag}");
        }

        public sealed override void SealeMethod()
        {
            Console.WriteLine("OneSon SealeMethod");
        }

        public new void Dail()
        {
            Console.WriteLine("SonClass.Dail");
            Console.WriteLine($"Son Dail {this.flag}");
            EstablishConnection();
            Console.WriteLine($"base.flag{base.flag}");
            base.Dail();
        }

        public override void EstablishConnection()
        {
            Console.WriteLine($"Son EstablishConnection {this.flag}");
            Console.WriteLine("SonClass.EstablishConnection");
        }

        //public required int age { get; set; }
    }
}
