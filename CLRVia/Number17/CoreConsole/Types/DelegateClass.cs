using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.Definition
{
    public class DelegateClass
    {
        public delegate void Delegate1();

        public Delegate1 delegate1;
        public Delegate1 delegate2;
        public Delegate1 delegate3;

        public DelegateClass()
        {
            delegate1 = new Delegate1(PMethod);
        }

        /// <summary>
        /// 简化的通过方法名代替委托的调用
        /// </summary>
        public void SimpleInvoke1()
        {
            InvokeDelegate(PMethod);
        }

        public void SimpleInvoke2()
        {
            InvokeDelegate(() =>
            {
                Console.WriteLine("Hello World");
            });
        }

        private void PMethod()
        {
            Console.WriteLine("私有方法");
        }

        private void InvokeDelegate(Delegate1 d1)
        {
            if (d1 != null)
            {
                d1();
            }
        }

        private void ThreadSafeInvokeDelegate(Delegate1 d1)
        {
            Interlocked.CompareExchange(ref delegate1, d1, null);
        }
    }
}
