using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;

namespace CoreConsole.Types
{
    //public delegate int AddDelete(int a, int b);

    //public delegate string UpperDelegate(string input);

    /// <summary>
    /// 委托与反射
    /// </summary>
    public class DeleteReflect
    {
        private delegate int AddDelete(int a, int b);

        private delegate string UpperDelegate(string input);

        private delegate DateTime ConverttDateTimeDelegate(string input);


        /// <summary>
        /// 调用通过反射创建的委托
        /// </summary>
        /// <param name="args"></param>
        public void InvokeReflectDelegate(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                throw new ArgumentException("Please provide two integer arguments.");
            }

            Delegate d = null;
            object[] delArgs = new object[args.Length - 1];

            var delType = Type.GetType(args[0]);
            if (delType == typeof(AddDelete))
            {
                if (!Int32.TryParse(args[1], out int a) || !Int32.TryParse(args[2], out int b))
                {
                    throw new ArgumentException("Please provide valid integer arguments.");
                }

                delArgs[0] = a;
                delArgs[1] = b;
                //d = Delegate.CreateDelegate(delType, this, nameof(AddMethod));

                var methodInfo = typeof(DeleteReflect).GetMethod("AddMethod");
                d = Delegate.CreateDelegate(delType, this, methodInfo);

            }
            else
            {
                if (delType == typeof(UpperDelegate))
                {
                    delArgs[0] = args[1];
                    d = Delegate.CreateDelegate(delType, this, nameof(UpperMethod));
                }
            }

            if (d != null)
            {
                try
                {
                    var resul = d.DynamicInvoke(delArgs);
                    Console.WriteLine($"结果的实际类型为：{resul.GetType().FullName}，结果的值为：{resul.ToString()}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"参数错误：{ex.Message}");
                    throw;
                }
            }
        }


        public int AddMethod(int a, int b)
        {
            return a + b;
        }

        public string UpperMethod(string input)
        {
            return input.ToUpper();
        }
    }
}