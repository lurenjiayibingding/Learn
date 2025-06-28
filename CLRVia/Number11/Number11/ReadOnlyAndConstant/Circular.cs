using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyAndConstant
{
    public class Circular : Geometry
    {
        internal readonly double Π;

        internal const double radius = 10.0;

        public Circular()
        {
            name = "圆形";
            Π = 3.1415926;
        }

        public override double Area()
        {
            return 0.0;
        }

        public override double Perimeter()
        {
            return 0.0;
        }

        //public void SetΠ(double newΠ)
        //{
        //    Π = newΠ;
        //}
    }
}
