using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole.Types
{
    /// <summary>
    /// 有关闭包
    /// </summary>
    public class Closure
    {
        /// <summary>
        /// 产生闭包的示例
        /// </summary>
        public void Run()
        {
            int factor = 2;
            Func<int, int> multiplier = x => x * factor;
            Console.WriteLine(multiplier(5)); // 输出 10
            factor = 3;
            Console.WriteLine(multiplier(5)); // 输出 15
        }

        /// <summary>
        /// 不会产生闭包的示例
        /// </summary>
        public void Run2()
        {
            int factor = 2;
            Func<int, int, int> multiplier = (x, y) => x * y;
            Console.WriteLine(multiplier(5, factor));
            factor = 3;
            Console.WriteLine(multiplier(5, factor));
        }


        public void Run3()
        {
            int factor = 2;
            Func<int, int, int> multiplier = Multiplier;

            Console.WriteLine(multiplier(5, factor)); // 输出 10
            factor = 3;
            Console.WriteLine(multiplier(5, factor)); // 输出 15
        }

        private int Multiplier(int x, int factor)
        {
            return x * factor;
        }
    }
}
