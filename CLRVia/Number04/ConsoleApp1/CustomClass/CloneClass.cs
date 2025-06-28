using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomClass
{
    /// <summary>
    /// 克隆类
    /// </summary>
    public class CloneClass
    {
        public int IntValue { get; set; }

        public int[] IntArray { get; set; }


        public CloneClass MyClone()
        {
            return (CloneClass)this.MemberwiseClone();
        }
    }
}