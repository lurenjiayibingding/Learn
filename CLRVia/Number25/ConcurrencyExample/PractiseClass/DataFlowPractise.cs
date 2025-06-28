using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConcurrencyExample.PractiseClass
{
    /// <summary>
    /// 
    /// </summary>
    public class DataFlowPractise
    {
        public async void DataFlowMeth1(int input)
        {
            var multiplyBlock = new TransformBlock<int, int>(item =>
            {
                var result = item * 2;
                Console.WriteLine($"MultiplyBlock result:{result}");
                return result;
            });
            var subtractBlock = new TransformBlock<int, int>(item =>
            {
                var result = item - 2;
                Console.WriteLine($"subtractBlock Result:{result}");
                return result;
            });
            multiplyBlock.LinkTo(subtractBlock);

            var option = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            multiplyBlock.Post(input);
            multiplyBlock.Complete();
            await subtractBlock.Completion;
        }
    }
}