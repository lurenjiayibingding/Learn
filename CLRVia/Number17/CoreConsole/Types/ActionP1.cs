using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.Types
{
    public class ActionP1
    {
        public void Math1()
        {
            var s = "Hello Word";
            var action = new Action(() =>
            {
                Console.WriteLine(s);
            });
            action();
        }

        public void Math2()
        {
            var s = "Hello Word";
            var action = new Action<object>(s =>
            {
                Console.WriteLine(s);
            });
            action(s);
        }
    }
}
