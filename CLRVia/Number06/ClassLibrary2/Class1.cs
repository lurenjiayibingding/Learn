using ClassLibrary1;

namespace ClassLibrary2
{
    public class Class1
    {
        public void Method()
        {
            Console.WriteLine(this.GetType().Assembly.FullName.ToString());
        }

        public void Method2()
        {
            FriendPractiseCLass f1 = new FriendPractiseCLass();
            f1.Month1();
        }
    }
}