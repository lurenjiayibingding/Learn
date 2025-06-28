using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMConsoleApp.Custom
{
    public struct Point
    {
        private double abscissa;
        private double ordinate;

        public Point(double abscissa, double ordinate)
        {
            this.abscissa = abscissa;
            this.ordinate = ordinate;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            if (point1.abscissa == point2.abscissa && point1.ordinate == point2.ordinate)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
