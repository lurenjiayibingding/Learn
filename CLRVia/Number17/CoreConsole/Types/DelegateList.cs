using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole.Types
{
    public class DelegateList
    {
        public delegate string IntConvertDel(int input);


        public void Run()
        {
            CDL1 cdl1 = new CDL1();
            IntConvertDel intConvertEvent = new IntConvertDel(CDL1.IntToString);
            intConvertEvent += cdl1.IntToString2;
            intConvertEvent += cdl1.IntToString3;

            Console.WriteLine(intConvertEvent(5));
        }


        public void CombineAndRemove()
        {
            var c1 = new CDL1();
            var c2 = new CDL1();

            var delegate1 = new IntConvertDel(CDL1.IntToString);
            delegate1 = (IntConvertDel)Delegate.Combine(delegate1, new IntConvertDel(c1.IntToString2));
            delegate1 += c2.IntToString3;
            foreach (IntConvertDel del in delegate1.GetInvocationList())
            {
                Console.WriteLine(del(5));
            }
            Console.WriteLine("******************");

            delegate1 -= c2.IntToString2;
            foreach (IntConvertDel del in delegate1.GetInvocationList())
            {
                Console.WriteLine(del(5));
            }
            Console.WriteLine("******************");

            delegate1 -= c1.IntToString2;
            foreach (IntConvertDel del in delegate1.GetInvocationList())
            {
                Console.WriteLine(del(5));
            }
        }


        public class CDL1
        {
            public static string IntToString(int input)
            {
                return input.ToString();
            }

            public string IntToString2(int input)
            {
                return (input + input).ToString();
            }

            public string IntToString3(int input)
            {
                return (input * input).ToString();
            }
        }
    }
}