using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public class FixedCapacityStackOfStrings
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        private string[] datas;
        private int index;

        public FixedCapacityStackOfStrings(int size)
        {
            datas = new string[size];
            index = 0;
        }

        public void Push(string item)
        {
            datas[index++] = item;
        }

        public string Pop()
        {
            return datas[--index];
        }

        public bool IsEmpty()
        {
            return index == 0;
        }

        public int Size()
        {
            return index;
        }

        public static void RunClient(string sample)
        {
            FixedCapacityStackOfStrings s = new FixedCapacityStackOfStrings(100);
            var items = sample.Split(' ').ToList();
            foreach (var item in items)
            {
                if (item != "-")
                {
                    s.Push(item);
                }
                else if (!s.IsEmpty())
                {
                    Console.Write(s.Pop() + " ");
                }
            }

            Console.WriteLine("("+s.Size()+" left on stack )");
        }
    }
}
