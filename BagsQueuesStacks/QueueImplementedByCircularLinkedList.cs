using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public class QueueImplementedByCircularLinkedList<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        private Node _last;
        private int N;

        public QueueImplementedByCircularLinkedList()
        {
            N = 0;
            _last = null;
        }

        public void Enqueue(T item)
        {
            var oldLast = _last;
            _last = new Node
            {
                Data = item,
            };
            if (IsEmpty())
            {
                _last.Next = _last;
            }
            else
            {
                _last.Next = oldLast.Next;                
                oldLast.Next = _last;
            }
            N++;
        }

        public T Dequeue()
        {
            N--;
            var data = _last.Next.Data;
            if(IsEmpty())
            {
                _last = null;
            }
            else
            {
                _last.Next = _last.Next.Next;
            }
            return data;
        }

        public int Size()
        {
            return N;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }
        class Node
        {
            public T Data;
            public Node Next;
        }

        public static void RunClient(string sample)
        {
            QueueImplementedByCircularLinkedList<string> s = new QueueImplementedByCircularLinkedList<string>();
            var items = sample.Split(' ').ToList();
            foreach (var item in items)
            {
                if (item != "-")
                {
                    s.Enqueue(item);
                }
                else if (!s.IsEmpty())
                {
                    Console.Write(s.Dequeue() + " ");
                }
            }

            Console.WriteLine("(" + s.Size() + " left on queue )");
        }
    }
}
