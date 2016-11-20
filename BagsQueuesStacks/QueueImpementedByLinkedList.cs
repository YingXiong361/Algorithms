using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    class QueueImplementedByLinkedList<T> : IEnumerable<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        int N;
        Node first;
        Node last;
        public QueueImplementedByLinkedList()
        {
            N = 0;
            first = null;
            last = null;
        }
        public void Enqueue(T item)
        {
            var oldLast = last;
            last = new Node
            {
                data = item,
                next = null
            };
            if (IsEmpty())
            {
                first = last;
            }
            else
            {
                oldLast.next = last;
            }
            N++;
        }

        public T Dequeue()
        {
            var oldFirst = first;
            first = oldFirst.next;
            N--;
            if (IsEmpty())
            {
                last = null;
            }
            return oldFirst.data;
        }

        public int Size()
        {
            return N;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        private class Node
        {
            public T data;
            public Node next;
        }

        public static void RunClient(string sample)
        {
            QueueImplementedByLinkedList<string> s = new QueueImplementedByLinkedList<string>();
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Iterator GetEnumerator()
        {
            return new Iterator(this);
        }

        private class Iterator : IEnumerator<T>
        {
            QueueImplementedByLinkedList<T> _outerClassInstance;
            Node _currentNode;

            public Iterator(QueueImplementedByLinkedList<T> outerClassObj)
            {
                _outerClassInstance = outerClassObj;
                _currentNode = new Node
                    {
                        data = default(T),
                        next = _outerClassInstance.first
                    };
            }

            T IEnumerator<T>.Current
            {
                get { return _currentNode.data; }
            }

            void IDisposable.Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return _currentNode.data; }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                var oldCurrent = _currentNode;
                _currentNode = oldCurrent.next;
                return _currentNode != null;
            }

            void System.Collections.IEnumerator.Reset()
            {
                _currentNode = new Node
                {
                    data = default(T),
                    next = _outerClassInstance.first
                };
            }
        }
    }
}
