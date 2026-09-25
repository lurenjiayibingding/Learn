using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    public class ThreadPoolPractice
    {
        public void PushQueUserWorkItem()
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                if (int.TryParse(state.ToString(), out int n))
                {
                    CommonMethod.SumWithoutResult(n);
                }
            }, 1000);
        }
    }
}
