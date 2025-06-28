using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisplayEvent
{
    public class ShowEventClass
    {
        public event DelegateText EventTest
        {
            add
            {
                int i = 1;
            }
            remove
            {
                int i = 2;
            }
        }
    }
}
