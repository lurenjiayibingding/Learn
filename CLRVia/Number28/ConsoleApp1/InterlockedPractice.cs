using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class InterlockedPractice
    {
        /// <summary>
        /// 官方建议的使用方式
        /// </summary>
        /// <param name="location"></param>
        public void SafeCompareAndSwap(ref int location)
        {
            int currentValue = location, tempValue;
            do
            {
                tempValue = currentValue;
                int value = Matches(tempValue);//耗时操作，计算新值
                currentValue = Interlocked.CompareExchange(ref location, value, tempValue);
            }
            while (currentValue != tempValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public void SafeCompareAndSwap2(ref int location)
        {
            //与上面的方法相比，减少了一个变量的使用，代码更简洁，但性能稍差

            int tempValue, value;
            do
            {
                tempValue = Volatile.Read(ref location);
                value = Matches(tempValue);//耗时操作，计算新值
            }
            while (Interlocked.CompareExchange(ref location, value, tempValue) != tempValue);
        }
    }
}
