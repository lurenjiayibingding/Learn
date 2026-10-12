using CoreConsoleThread.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleThread.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateOptions
    {
        public void CreateHierarchyTask()
        {
            try
            {
                var parentTask = new Task(() =>
                {
                    CommonMethod.Sum(100);

                    var ct1 = new Task(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Console.WriteLine($"ct1:{DateTime.Now.Ticks.ToString()}");
                            Thread.Sleep(10);
                        }
                    }, TaskCreationOptions.AttachedToParent);
                    ct1.Start();

                    var ct2 = new Task(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Console.WriteLine($"ct2:{DateTime.Now.Ticks.ToString()}");
                            Thread.Sleep(13);
                        }
                    }, TaskCreationOptions.AttachedToParent);
                    ct2.Start();

                }, TaskCreationOptions.DenyChildAttach);

                parentTask.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                throw;
            }

        }
    }
}
