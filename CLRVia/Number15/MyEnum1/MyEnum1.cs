using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnum1
{
    internal enum Color : int
    {
        White = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Orange = 4
    }

    internal enum Color2 : byte
    {
        White = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Orange = 4
    }

    internal enum Action : int
    {
        None = 0,
        Read = 1,
        Write = 2,
        ReadWrite = Read | Write,
        Delete = 4,
        Query = 8,
        Sync = 16,
        All = Read | Write | Delete | Query | Sync
    }
}
