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
            //FixedCapacityStackOfStrings.RunClient(FixedCapacityStackOfStrings.TestSample);
           // FixedCapacityStack<string>.RunClient(FixedCapacityStack<string>.TestSample);
            ResizableStack<string>.RunClient(ResizableStack<string>.TestSample);

            Console.Read();
        }
    }
}
