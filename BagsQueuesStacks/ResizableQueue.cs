using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    class ResizableQueue<T> : IEnumerable<T>
    {
        public static readonly string TestSample = "to be or not to - be - - that - - - is";

        T[] data;
        int _headIndex;
        int _tailIndex;
        public ResizableQueue(int defaultSize)
        {
            data = new T[defaultSize];
            _headIndex = -1;
            _tailIndex = 0;
        }

        public int Size()
        {
            return _headIndex - _tailIndex + 1;
        }

        public bool IsEmpty()
        {
            return _tailIndex > _headIndex;
        }

        private bool IsFull()
        {
            return Size() == data.Length;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Resize(data.Length * 2);
            }
            _headIndex++;
            data[_headIndex % data.Length] = item;
        }

        public T Dequeue()
        {
            T item = data[_tailIndex % data.Length];
            data[_tailIndex%data.Length] = default(T);
            _tailIndex++;
            Halve();
            return item;
        }

        private void Resize(int max)
        {
            T[] newData = new T[max];
            int k = -1;
            for (int i = _tailIndex % data.Length; i <= _headIndex % data.Length; i++)
            {
                newData[++k] = data[i];
            }

            data = newData;
            _tailIndex = 0;
            _headIndex = k;
        }

        private void Halve()
        {
            if (Size() != 0 && Size() <= data.Length / 4)
            {
                T[] newData = new T[data.Length / 2];
                int k = -1;
                for (int i = _tailIndex % data.Length; i <= _headIndex % data.Length; i++)
                {
                    newData[++k] = data[i];
                }
                data = newData;
                _tailIndex = 0;
                _headIndex = k;
            }
        }

        public static void RunClient(string sample)
        {
            ResizableQueue<string> s = new ResizableQueue<string>(100);
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

        private IEnumerator<T> GetEnumerator()
        {
            return new ResizableQueueEnumerator(this);
        }

        private class ResizableQueueEnumerator : IEnumerator<T>
        {
            private ResizableQueue<T> _containingClassInstance;
            int _currentIndex;

            public ResizableQueueEnumerator(ResizableQueue<T> containingClassObj)
            {
                _containingClassInstance = containingClassObj;
                _currentIndex = containingClassObj._tailIndex - 1;
            }

            T IEnumerator<T>.Current
            {
                get { return Current; }
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return _containingClassInstance.data[_currentIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }

                }
            }
            void IDisposable.Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _currentIndex++;
                return _currentIndex <= _containingClassInstance._headIndex;
            }

            void System.Collections.IEnumerator.Reset()
            {
                _currentIndex = _containingClassInstance._tailIndex - 1;
            }
        }
    }
}
