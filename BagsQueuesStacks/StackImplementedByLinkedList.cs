using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    class StackImplementedByLinkedList<T> : IEnumerable<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";
        int N;
        Node first;

        public StackImplementedByLinkedList()
        {
            N = 0;
            first = null;
        }
        public void Push(T item)
        {
            var oldFirst = first;
            first = new Node
            {
                Item = item,
                Next = oldFirst
            };
            N++;
        }

        public T Pop()
        {
            var data = first.Item;
            first = first.Next;
            N--;
            return data;
        }

        /// <summary>
        /// Exercise 1.3.7
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return first.Item;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public int Size()
        {
            return N;
        }

        public static void RunClient(string sample)
        {
            StackImplementedByLinkedList<string> s = new StackImplementedByLinkedList<string>();
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

        private class Node
        {
            public T Item;
            public Node Next = null;
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
            private StackImplementedByLinkedList<T> _outerClassInstance;
            private Node _current;
            public Iterator(StackImplementedByLinkedList<T> outerClass)
            {
                _outerClassInstance = outerClass;
                _current = new Node
                    {
                        Item = default(T),
                        Next = _outerClassInstance.first
                    };
            }

            T IEnumerator<T>.Current
            {
                get { return _current.Item; }
            }

            void IDisposable.Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return _current.Item; }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _current = _current.Next;
                return _current != null;
            }

            void System.Collections.IEnumerator.Reset()
            {
                _current = new Node
                {
                    Item = default(T),
                    Next = _outerClassInstance.first
                };
            }
        }
    }
}
