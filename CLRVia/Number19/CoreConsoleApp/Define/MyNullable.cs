using System.Runtime.InteropServices;

namespace CoreConsoleApp.Define
{
    /// <summary>
    /// 自定义的可空值类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MyNullable<T> where T : struct
    {
        private bool hasValue = false;
        private T value = default(T);

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException("可空值类型必须有一个值.");
                }
                return value;
            }
        }

        public MyNullable(T value)
        {
            hasValue = true;
            this.value = value;
        }

        public T GetValueOrDefault()
        {
            return value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            if (!hasValue)
            {
                return defaultValue;
            }
            return value;
        }

        /// <summary>
        /// 重载Equals方法
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            if (!hasValue)
                return other == null;
            if (other == null)
                return false;
            return value.Equals(other);
        }

        /// <summary>
        /// 因为重载了Equals方法，所以必须重载GetHashCode方法
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!hasValue)
            {
                return 0;
            }
            return value.GetHashCode();
        }

        /// <summary>
        /// 重载ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!hasValue)
            {
                return "";
            }
            return value.ToString();
        }

        /// <summary>
        /// 重载隐式转换操作符:值类型隐式转换为对应的可空值类型
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T>(value);
        }

        /// <summary>
        /// 重载显示转换操作符:可空值类型显示转换为对应的值类型
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator T(MyNullable<T> value)
        {
            //隐式转换时调用的是属性不是字段
            //这样在可空值类型未赋值时可以抛出一个异常
            return value.Value;
        }
    }
}