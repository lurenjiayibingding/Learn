using StandardLib;

namespace CoreLib
{
    public class FrameworkPrint
    {
        public void Print()
        {
            Console.WriteLine(typeof(string).Assembly.FullName);
            Console.WriteLine(typeof(int).Assembly.FullName);
            Console.WriteLine(typeof(bool).Assembly.FullName);
            Console.WriteLine(typeof(List<>).Assembly.FullName);

            Utils.PrintAssemblyNames();
        }
    }
}