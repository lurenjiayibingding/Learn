using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypeCon.DefClass
{
    internal class CheckedAndUnchecked
    {
        public static byte DefaultBehaviour()
        {
            //byte a = 300;
            byte a = 100;
            return (Byte)(a + 200);
        }

        public static byte CheckedBehaviour()
        {
            //byte a = 300;
            byte a = 100;
            return checked((Byte)(a + 200));
        }

        public static void AutoConvert()
        {
            int a = 100;
            long b = a;
        }

        public static byte InvalidChecked()
        {
            //return checked(DefaultBehaviour());

            byte result;
            checked
            {
                //byte a = 100;
                //result = (Byte)(a + 200);
                result = DefaultBehaviour();
            }
            return result;
        }
    }
}
