using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public class ResizableStack<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        int index;
        T[] data;

        public ResizableStack(int initialSize)
        {
            data = new T[initialSize];
            index = 0;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                Resize(data.Length * 2);
            }
            data[index++] = item;
        }

        public T Pop()
        {
            index--;
            T item = data[index];
            data[index] = default(T);
            return item;
        }

        public bool IsEmpty()
        {
            return index == 0;
        }

        private void Resize(int max)
        {
            var newData = new T[max];
            for (int i = 0; i < index; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }

        private void Halve()
        {
            if(index!=0&&index==data.Length/4)
            {
                var newData = new T[data.Length / 2];
                for(int i=0;i<index;i++)
                {
                    newData[i] = data[i];
                }
                data = newData;
            }
        }

        public int Size()
        {
            return index;
        }

        private bool IsFull()
        {
            return index == data.Length;
        }


        public static void RunClient(string sample)
        {
            ResizableStack<string> s = new ResizableStack<string>(100);
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
