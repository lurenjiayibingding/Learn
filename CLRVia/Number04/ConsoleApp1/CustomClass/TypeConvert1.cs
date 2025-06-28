using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomClass
{
    public class TypeConvert
    {
        public int ConvertProperty1 { get; set; }

        public string ConvertProperty2 { get; set; }
    }

    public class TypeConvert1 : TypeConvert
    {
        public int Property1 { get; set; }

        public string Property2 { get; set; }
    }

    public class TypeConvert2 : TypeConvert
    {
        public int Property1 { get; set; }

        public string Property2 { get; set; }

        //public static explicit operator TypeConvert2(TypeConvert1 typeConvert) => new TypeConvert2()
        //{
        //    Property1 = typeConvert.Property1,
        //    Property2 = typeConvert.Property2
        //};

        public static implicit operator TypeConvert2(TypeConvert1 typeConvert) => new TypeConvert2()
        {
            Property1 = typeConvert.Property1,
            Property2 = typeConvert.Property2
        };

        public static int operator +(TypeConvert2 t1, TypeConvert2 t2) => t1.Property1 + t2.Property1;
    }
}
