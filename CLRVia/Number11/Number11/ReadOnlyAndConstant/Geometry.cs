using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyAndConstant
{
    public abstract class Geometry
    {
        protected string name;

        /// <summary>
        /// 面积
        /// </summary>
        /// <returns></returns>
        public abstract double Area();

        /// <summary>
        /// 周长
        /// </summary>
        /// <returns></returns>
        public abstract double Perimeter();

        public string GetName()
        {
            return name;
        }
    }
}
