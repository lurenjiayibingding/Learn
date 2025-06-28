using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.DefClass
{
    public class MyToString
    {
        public static string ToString<T>(object targetObject, T trageAttribute) where T : System.Type
        {
            if (targetObject.GetType().IsDefined(trageAttribute, true))
            {
                return "应用了自定义的Flages定制特性";
            }
            else
            {
                return "未应用自定义的Flages定制特性";
            }
        }
    }
}