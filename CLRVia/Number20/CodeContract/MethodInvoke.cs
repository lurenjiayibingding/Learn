using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeContract
{
    public class MethodInvoke
    {
        public void A()
        {
            B();
        }

        public void B()
        {
            try
            {
                C();
            }
            catch (Exception ex)
            {
                Console.WriteLine("B捕捉到异常:" + ex.StackTrace.ToString());
            }
        }

        public void C()
        {
            D();
        }

        public void D()
        {
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                var currentFram = stackTrace.GetFrame(i);
                Console.WriteLine($"FileName:" + currentFram.GetFileName());
                Console.WriteLine($"FileLineNumber:" + currentFram.GetFileLineNumber());
                Console.WriteLine($"FileColumnNumber:" + currentFram.GetFileColumnNumber());
                Console.WriteLine($"Method:" + currentFram.GetMethod().Name);
            }

            throw new Exception("手动抛出异常");
        }


        public void E()
        {
            bool trySucceeds = false;
            try
            {
                int a = F();
                var b = 100 / a;
                trySucceeds = true;
            }
            finally
            {
                if (!trySucceeds)
                {
                    //捕捉代码放到这里
                }
            }
        }

        public int F()
        {
            return 0;
        }
    }
}
