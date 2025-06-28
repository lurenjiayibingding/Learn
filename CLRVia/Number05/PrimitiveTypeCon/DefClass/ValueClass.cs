using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimitiveTypeCon.DefClass
{
    
    internal class ValueClass
    {

        public int value { get; set; }

        public void PrimitiveType()
        {
            Int32 a = 1;
            Int64 b = a;
        }
    }
}
