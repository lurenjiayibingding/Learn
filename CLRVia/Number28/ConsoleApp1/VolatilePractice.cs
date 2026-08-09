using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class VolatilePractice
    {
        public void M()
        {
            Monitor.Enter(this);


            Monitor.Exit(this);
        }
    }
}
