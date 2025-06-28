namespace CoreConsoleApp.Define
{
    public class CompileEqual
    {
        private static Int32? NullableCodeSize1(Int32? a, Int32? b)
        {
            return (a + b);
        }

        private static Int32? NullableCodeSize2(Int32? a, Int32? b)
        {
            Int32? nullable1 = a;
            Int32? nullable2 = b;
            if (!(nullable1.HasValue & nullable2.HasValue))
            {
                //return new int?();
                return new Nullable<int>();
            }
            return new Nullable<int>(nullable1.GetValueOrDefault() + nullable2.GetValueOrDefault());
        }

        public int AndMethod()
        {
            var a = 1;
            var b = 1;
            var c = a & b;
            return c;
        }
    }
}
