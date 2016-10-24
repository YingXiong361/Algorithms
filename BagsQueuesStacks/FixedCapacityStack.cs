using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public class FixedCapacityStack<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        private T[] datas;
        private int index;

        public FixedCapacityStack(int size)
        {
            datas = new T[size];
            index = 0;
        }

        public void Push(T item)
        {
            datas[index++] = item;
        }

        public T Pop()
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
            FixedCapacityStack<string> s = new FixedCapacityStack<string>(3);
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

            Console.WriteLine("(" + s.Size() + " left on stack )");
        }
    }
}
