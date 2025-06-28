using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.DefClass
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All,Inherited =true)]
    public class MyDefAttribute : System.Attribute
    {
    }
}