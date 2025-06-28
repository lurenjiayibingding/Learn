namespace MyTypeForward
{
    /// <summary>
    /// 
    /// </summary>
    public class ForwardClass
    {
        public static void PrintMessage()
        {
            Console.WriteLine(typeof(ForwardClass).Assembly.FullName);
        }
    }
}