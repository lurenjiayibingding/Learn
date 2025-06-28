using System.Collections.Concurrent;

namespace CoreConsole2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<string> result = new ConcurrentBag<string>();
            Parallel.For(1, 10001, new ParallelOptions { MaxDegreeOfParallelism = 10 }, i =>
            {
                result.Add(i.ToString());
            });
            Console.WriteLine(result.Count);
            var order = result.OrderBy(i => i.Length).ThenBy(n => n);
            foreach (var item in order)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
