using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContract
{
    public class FinallyTest
    {
        public void FinallyMethod()
        {
            try
            {
                Console.WriteLine("try");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }

        public string FinallyMethod2()
        {
            try
            {
                return "try";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}
