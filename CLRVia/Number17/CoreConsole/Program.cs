using CoreConsole.Definition;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Text;

namespace CoreConsole
{
    internal delegate void Feedback(int value);
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //StaticDelegateDemo();
                //InstanceDelegateDemo();
                //ChainDelegeDemo1(new Program());

                DelegateClass delegateClass = new DelegateClass();
                //delegateClass.delegate1();
                delegateClass.SimpleInvoke1();
                delegateClass.SimpleInvoke2();

                Console.WriteLine("Hello, World!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
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
            Console.WriteLine("开始在实例方法中执行委托");
            Count(1, 3, new Feedback((new Program()).FeedbackToFail));
            Console.WriteLine("在实例方法中执行委托结束");
        }

        private static void ChainDelegeDemo1(Program program)
        {
            Console.WriteLine("开始在委托链中执行方法");
            Feedback f1 = new Feedback(FeedbackToConsole);
            Feedback f2 = new Feedback(FeedbackToMessageBox);
            Feedback f3 = new Feedback(program.FeedbackToFail);

            Feedback fbChain = null;
            //fbChain = (Feedback)Delegate.Combine(f1);
            //fbChain = (Feedback)Delegate.Combine(fbChain, f2);
            //fbChain = (Feedback)Delegate.Combine(fbChain, f3);
            //fbChain = (Feedback)Delegate.Combine(f1);
            //fbChain += f2;
            //fbChain += f3;

            fbChain = new Feedback(f1);
            fbChain += f2;
            fbChain += f3;
            Count(1, 3, fbChain);

            Console.WriteLine("在委托链中执行方法结束");
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
