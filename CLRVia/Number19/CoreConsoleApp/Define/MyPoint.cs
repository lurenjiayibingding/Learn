namespace CoreConsoleApp.Define
{
    /// <summary>
    /// 
    /// </summary>
    internal struct MyPoint
    {
        private int _x;
        private int _y;

        public MyPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static bool operator ==(MyPoint p1, MyPoint p2)
        {
            return (p1._x == p2._x) && (p1._y == p2._y);
        }

        public static bool operator !=(MyPoint p1, MyPoint p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(MyPoint p1, MyPoint p2)
        {
            return (p1._x > p2._x) && (p1._y > p2._y);
        }
        public static bool operator <(MyPoint p1, MyPoint p2)
        {
            return (p1._x < p2._x) && (p1._y < p2._y);
        }
    }
}