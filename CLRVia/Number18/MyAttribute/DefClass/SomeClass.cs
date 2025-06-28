using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.DefClass
{
    [MyDef]
    public class SomeBasicClass
    {
        [MyDef]
        public virtual void Method()
        {
            Console.WriteLine("Do Some Thins");
        }
    }

    public class SomeInheritClass : SomeBasicClass
    {
        public override void Method()
        {
            Console.WriteLine("Do Some Thins2");
        }
    }
}
