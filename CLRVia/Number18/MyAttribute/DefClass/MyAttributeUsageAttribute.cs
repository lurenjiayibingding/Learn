using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.DefClass
{
    [Serializable]
    public class MyAttributeUsageAttribute:System.Attribute
    {
        internal AttributeTargets attributeTargets;

        public MyAttributeUsageAttribute(AttributeTargets attributeTargets)
        {

        }
    }
}