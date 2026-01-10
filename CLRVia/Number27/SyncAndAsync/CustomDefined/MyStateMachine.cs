using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SyncAndAsync.CustomDefined
{
    public class MyStateMachine
    {
        private static async Task<Type1> Method1Async()
        {
            return await Task.Run(() =>
            {
                return new Type1();
            });
        }

        private static async Task<Type2> Method2Async()
        {
            return await Task.Run(() =>
            {
                return new Type2();
            });
        }

        private static async Task<string> MethodAsync(int argument)
        {
            int locak = argument;
            try
            {
                var t1 = await Method1Async();
                for (int i = 0; i < 10; i++)
                {
                    var t2 = await Method2Async();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch");
            }
            finally
            {
                Console.WriteLine("finally");
            }
            return "Hello,World";
        }

        private static async Task<string> Method2Async(string input)
        {
            var asyncResult = await Task.Run(() =>
            {
                return input.ToUpper();
            });
            return asyncResult;
        }
    }

    internal sealed class Type1 { }

    internal sealed class Type2 { }
}
