using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Common
{
    public class CommonMethod
    {
        public static void SumWithoutResult(int n)
        {
            var result = 0;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine($"i={i.ToString()}, result={result.ToString()}");
                checked
                {
                    result += i;
                }
            }
        }

        public static int Sum(int n)
        {
            var result = 0;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine($"i={i.ToString()}, result={result.ToString()}");
                checked
                {
                    result += i;
                }
            }
            return result;
        }

        public static int Sum(object n)
        {
            if (!int.TryParse(n.ToString(), out int length))
            {
                throw new ArgumentException("Invalid input");
            }

            var result = 0;
            for (int i = 0; i < length; i++)
            {
                result += i;
            }

            return result;
        }
    }
}