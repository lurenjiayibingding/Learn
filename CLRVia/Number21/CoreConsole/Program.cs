namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(Callback, null, 0, 1000);
            Console.ReadKey();
            //t = null;
            //t.Dispose();
        }

        static void Callback(object obj)
        {
            Console.WriteLine("In TimerCallback" + DateTime.Now.ToString());
            GC.Collect();
        }
    }
}
