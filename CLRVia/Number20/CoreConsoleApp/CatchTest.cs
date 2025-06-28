using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    public class CatchTest
    {
        public static void CatchMethod()
        {
            try
            {
                Console.WriteLine("1 try");
                try
                {
                    Console.WriteLine("2 try");
                    try
                    {
                        Console.WriteLine("3 try");
                        try
                        {
                            Console.WriteLine("4 try");
                            throw new AggregateException("4 try exception");
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine("4 ArgumentNullException");
                        }
                        finally
                        {
                            Console.WriteLine("4 finally");
                        }
                        Console.WriteLine("4 finally end");
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine("3 ArgumentNullException");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("3 ArgumentOutOfRangeException");
                    }
                    finally
                    {
                        Console.WriteLine("3 finally");
                    }
                    Console.WriteLine("3 finally end");
                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine("2 ApplicationException");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("2 AggregateException");
                }
                finally
                {
                    Console.WriteLine("2 finally");
                }
                Console.WriteLine("2 finally end");
            }
            catch (Exception ex)
            {
                Console.WriteLine("1 Exception");
            }
            finally
            {
                Console.WriteLine("1 finally");
            }
            Console.WriteLine("1 finally end");
        }
    }
}
