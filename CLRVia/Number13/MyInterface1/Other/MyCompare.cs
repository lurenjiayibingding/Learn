using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface1
{
    public class MyCompare : IComparable<int>, IComparable<string>
    {
        private int myIntValue;
        private string myStringValue;

        public MyCompare(int intValue, string stringValue)
        {
            myIntValue = intValue;
            myStringValue = stringValue;
        }

        public int CompareTo(int other)
        {
            if (myIntValue > other)
            {
                return 1;
            }
            if (myIntValue == other)
            {
                return 0;
            }
            if (myIntValue < other)
            {
                return -1;
            }
            return 0;
        }

        public int CompareTo(string other)
        {
            if (string.IsNullOrEmpty(other))
            {
                return 1;
            }
            if (myStringValue.Length > other.Length)
            {
                return 1;
            }
            if (myStringValue.Length == other.Length)
            {
                return 0;
            }
            if (myStringValue.Length < other.Length)
            {
                return -1;
            }
            return 0;
        }
    }
}
