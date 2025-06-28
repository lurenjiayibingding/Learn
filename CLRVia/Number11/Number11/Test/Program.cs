namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = "str1";
            var str2 = "str2";
            var str3 = "str1";

            var str4 = Interlocked.CompareExchange<string>(ref str1, str2, str3);
            Console.WriteLine(str4 + " " + str1);

            Console.WriteLine("Hello, World!");
        }
    }
}
