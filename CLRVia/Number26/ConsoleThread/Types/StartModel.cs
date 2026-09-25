using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// Task的启动方式
    /// </summary>
    public class StartModel
    {
        public async Task OrdinaryStart()
        {
            var task = new Task<int>(new Func<object?, int>(CommonMethod.Sum), 100);
            task.Start();
            var result = task.Result;
        }
    }
}
