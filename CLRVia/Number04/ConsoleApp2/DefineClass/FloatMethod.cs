using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DefineClass
{
    public class FloatMethod
    {
        public void GetStrackAddress()
        {
            var f1 = 0.75f;
            byte[] array1 = null;
            unsafe
            {
                var address = &f1;

                MemoryUtils memoryUtils = new MemoryUtils(System.Environment.ProcessId);
                array1 = memoryUtils.ReadToBytes((System.IntPtr)address, 4);
            }

            var array2 = BitConverter.GetBytes(f1);
            foreach (var item in array2)
            {
                var aa = Convert.ToString(item, 2).PadLeft(8, '0');
            }
        }
    }
}