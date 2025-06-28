using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.DefClass
{
    [System.AttributeUsage(AttributeTargets.Enum,Inherited =false)]
    public class MyFlagsAttribute : System.Attribute
    {
        public MyFlagsAttribute()
        {

        }
    }
}