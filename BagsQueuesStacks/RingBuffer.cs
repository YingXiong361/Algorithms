using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public interface IRingBuffer<T> where T : struct
    {
        bool IsFull();

        bool IsEmpty();

        void Enqueue(T item);

        T Dequeu();
    }
    public class RingBuffer<T> : IRingBuffer<T> where T : struct
    {
        T[] _data;
        int _headIndex;
        int _tailIndex;
        public RingBuffer(int size)
        {
            _data = new T[size];
            _tailIndex = 0;
            _headIndex = -1;
        }

        bool IRingBuffer<T>.IsFull()
        {
            return Size() == _data.Length;
        }

        bool IRingBuffer<T>.IsEmpty()
        {
            return _headIndex < _tailIndex;
        }

        private int Size()
        {
            return _headIndex - _tailIndex + 1;
        }
        void IRingBuffer<T>.Enqueue(T item)
        {
            _data[++_headIndex % _data.Length] = item;
        }

        T IRingBuffer<T>.Dequeu()
        {
            return _data[_tailIndex++];
        }
    }
}
