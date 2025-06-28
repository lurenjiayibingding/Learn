using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FMConsoleApp.Custom
{

    [System.Runtime.InteropServices.ComVisible(true)]
    public static class MyNullableValue
    {

    }



    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MyNullableValue<T> where T : struct
    {
        /*
         * 这里需要注意，在struct结构中无法直接为字段赋值
         */

        private Boolean hasValue;

        public Boolean HasValue { get => hasValue; }

        internal T value;

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException("可控值类型为Null");
                }
                return value;
            }
        }

        public MyNullableValue(T value)
        {
            this.value = value;
            hasValue = true;
        }

        public T GetValueOrDefault()
        {
            if (hasValue)
                return value;
            return default(T);
        }

        public T GetValueOrDefault(T defaultValue)
        {
            if (hasValue)
                return value;
            return defaultValue;
        }

        public static implicit operator MyNullableValue<T>(T value)
        {
            return new MyNullableValue<T>(value);
        }

        public static explicit operator T(MyNullableValue<T> value)
        {
            if (value.HasValue)
            {
                return value.Value;
            }
            return default(T);
        }
    }
}
