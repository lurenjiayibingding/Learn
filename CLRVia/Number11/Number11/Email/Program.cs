using System;
using System.Threading.Tasks;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailManager m = new MailManager("m1");
            //Fax f = new Fax(m);
            //m.SimulateEmail("发送1", "接受1", "主题1");
            //Console.ReadLine();

            //DisplayEvent m2 = new DisplayEvent();
            //DisplayFax f = new DisplayFax(m2);
            //m2.OnNewMail(new NewMailEventArgs("显示发送1", "显示接受1", "显示主题1"));
            //Console.ReadLine();


            //List<int> l1 = new List<int>(3) { 1, 2, 3 };
            //List<int> l2 = new List<int>(4) { 1, 2, 3, 4 };
            //List<int> l3 = new List<int>(3) { 1, 2, 3 };

            //var l4 = Interlocked.CompareExchange<List<int>>(ref l1, l2, l3);

            //Console.WriteLine(l4.Count);
            //Console.WriteLine(l1.Count);

            //Cat cat = new Cat("Tom");
            //Mouse mouse = new Mouse("Jerry");
            //Candle candle1 = new Candle(1);

            //mouse.FindCat(cat, candle1);

            #region 通过+=注册/取消事件监听时，多线程不会冲突
            Cat cat = new Cat("Tom");
            var mouseList = Mouse.CreateList(1000);

            Parallel.ForEach(mouseList, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, item =>
            {
                item.FindCat(cat);
            });
            cat.OnCatYell();

            Parallel.ForEach(mouseList, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, item =>
            {
                item.CastOffCat(cat);
            });
            cat.OnCatYell();
            #endregion

            Console.ReadLine();
        }
    }
}
