using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// Task中的异常如何处理
    /// </summary>
    public class TeskException
    {

        public static async Task<int> ComputeLengthAsync(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            await Task.Delay(5000);
            return input.Length;
        }


        public static Task<int> ComputeLengthAsync2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //return ComputeLengthImplAsync(input);

            return Task.Run(async () =>
            {
                await Task.Delay(5000);
                return input.Length;
            });

        }
    }
}