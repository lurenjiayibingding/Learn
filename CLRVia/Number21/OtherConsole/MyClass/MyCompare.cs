using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OtherConsole.MyClass
{
    public class MyCompare
    {
        public static bool ComperBySpan<T>(T[] t1, T[] t2) where T : struct
        {
            var span1 = MemoryMarshal.AsBytes<T>(t1.AsSpan());
            var result1 = span1.SequenceCompareTo(MemoryMarshal.AsBytes<T>(t2.AsSpan()));
            return false;
        }
    }
}
