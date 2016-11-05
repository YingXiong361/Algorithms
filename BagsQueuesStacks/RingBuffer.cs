using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public interface IRingBuffer<T> where T : struct
    {
        bool IsFull();

        bool IsEmpty();

        void Enqueue(T item);

        T Dequeue();
    }
    /// <summary>
    ///  Exercise 1.3.39
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RingBuffer<T> : IRingBuffer<T> where T : struct
    {
        T[] _data;
        int _headIndex;
        int _tailIndex;
        private object _mutex = new object();
        public RingBuffer(int size)
        {
            _data = new T[size];
            _tailIndex = 0;
            _headIndex = -1;
        }

        bool IRingBuffer<T>.IsFull()
        {
            lock (_mutex)
            {
                return Size() == _data.Length;
            }
        }

        bool IRingBuffer<T>.IsEmpty()
        {
            lock (_mutex)
            {
                return _headIndex < _tailIndex;
            }
        }

        private int Size()
        {
            return _headIndex - _tailIndex + 1;
        }
        void IRingBuffer<T>.Enqueue(T item)
        {
            lock (_mutex)
            {
                _data[++_headIndex % _data.Length] = item;
            }
        }

        T IRingBuffer<T>.Dequeue()
        {
            lock (_mutex)
            {
                var item = _data[_tailIndex % _data.Length];
                _tailIndex++;
                return item;
            }
        }

        public static void RunClient()
        {
            var buffer = new RingBuffer<int>(4);
            var shouldStop = false;
            var producerThread = new Thread(() => Produce(buffer, ref shouldStop)) { Name = "Producer_1" };
            var consumerThread = new Thread(() => Consume(buffer, ref shouldStop)) { Name = "Consumer_1" };
            producerThread.Start();
            consumerThread.Start();
            producerThread.Join();
            consumerThread.Join();
            Console.WriteLine("Finsh producing and consuming");
        }

        public static int DataSize = 100;
        private static void Produce(IRingBuffer<int> buffer, ref bool shouldStop)
        {
            Thread.Sleep(500);
            int i = 0;
            while (i <= 100)
            {
                if (!buffer.IsFull())
                {
                   // Console.WriteLine("Produce data [{0}] Thread[{1}]", i, Thread.CurrentThread.Name);
                    Thread.Sleep(500);
                    buffer.Enqueue(i++);
                }
            }
            shouldStop = true;
        }

        private static void Consume(IRingBuffer<int> buffer, ref bool shouldStop)
        {

            while (!shouldStop || !buffer.IsEmpty())
            {
                if (!buffer.IsEmpty())
                {
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Consume data[{0}] on Thread [{1}]", buffer.Dequeue(), Thread.CurrentThread.Name);
                    Console.ResetColor();
                }
            }
        }
    }
}
