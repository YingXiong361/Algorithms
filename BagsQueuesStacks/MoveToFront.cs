using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Execise 1.3.40
    /// </summary>
    public class MoveToFront
    {
        private Node first;
        public MoveToFront()
        {
            first = null;
        }

        public void InsertInTheFront(char item)
        {
            DeleteDuplicate(item);
            first = new Node
            {
                Item = item,
                Next = first
            };
        }

        private bool DeleteDuplicate(char item)
        {
            if (first == null) { return false; }
            if (first.Item == item)
            {
                first = first.Next;
                return true;
            }

            for (Node i = first; i.Next != null; i = i.Next)
            {
                if (i.Next.Item == item)
                {
                    i.Next = i.Next.Next;
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (Node i = first; i != null; i = i.Next)
            {
                stringBuilder.Append(i.Item + " ");
            }
            return stringBuilder.ToString();
        }

        private class Node
        {
            public char Item;
            public Node Next;
        }
    }
}
