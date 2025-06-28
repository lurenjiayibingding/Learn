using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameworkConsole
{
    internal delegate void Feedback(int value);
    internal class Program
    {
        static void Main(string[] args)
        {
            StaticDelegateDemo();

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("开始在静态方法中执行委托");
            Count(1, 3, null);
            Count(1, 3, new Feedback(FeedbackToConsole));
            Count(1, 3, new Feedback(FeedbackToMessageBox));
            Console.WriteLine("在静态方法中执行委托结束");
        }

        private static void InstanceDelegateDemo()
        {

        }

        private static void ChainDelegeDemo1(Program program)
        {

        }

        private static void ChainDelegeDemo2(Program program)
        {

        }

        private static void Count(int from, int to, Feedback fb)
        {
            for (int i = from; i <= to; i++)
            {
                if (fb != null)
                {
                    fb(i);
                }
            }
        }

        private static void FeedbackToConsole(int value)
        {
            Console.WriteLine($"item={value}");
        }

        private static void FeedbackToMessageBox(int value)
        {
            MessageBox.Show($"Item={value}");
        }

        private void FeedbackToFail(int value)
        {
            using (StreamWriter sw = new StreamWriter("Status", true))
            {
                sw.WriteLine($"Item={value}");
                sw.Close();
            }
        }
    }
}
