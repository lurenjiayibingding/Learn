namespace CoreConsoleApp.Define
{
    internal class Box
    {
        public static void NullableToBox()
        {
            int? a = null;
            int? b = new Nullable<int>();

            Console.WriteLine($"a has value:{a.HasValue.ToString()}");
            Console.WriteLine($"b has value:{b.HasValue.ToString()}");

            object c = a;
            object d = b;
            Console.WriteLine($"a to box is null:{(c == null).ToString()}");
            Console.WriteLine($"b to box is null:{(d == null).ToString()}");
        }

        public static void GetNullableType()
        {
            //int? a = null;
            //Console.WriteLine(a.GetType().FullName);
            int? b = 5;
            Console.WriteLine(b.GetType().FullName);
        }

        public static void InvockInterface()
        {
            int? a = 6;
            //正常运行
            var result = ((IComparable<int>)a).CompareTo(5);

            int? b = null;
            //抛出System.NullReferenceException异常
            result = ((IComparable<int>)b).CompareTo(5);
        }
    }
}
