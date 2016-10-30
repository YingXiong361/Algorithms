using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // FixedCapacityStackOfStrings.RunClient(FixedCapacityStackOfStrings.TestSample);
            // FixedCapacityStack<string>.RunClient(FixedCapacityStack<string>.TestSample);
           // ResizableStack<string>.RunClient(ResizableStack<string>.TestSample);

            //var queue = new ResizableQueue<string>(100);
            //foreach (var item in ResizableStack<string>.TestSample.Split(' ').ToList())
            //{
            //    queue.Enqueue(item.ToString());
            //}

            //foreach (var item in queue)
            //{
            //    Console.Write(item + " ");
            //}

            ResizableQueue<string>.RunClient(ResizableQueue<string>.TestSample);

            Console.Read();
        }
    }
}
