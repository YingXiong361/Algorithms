using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Exercise 1.3.44
    /// </summary>
    public class Buffer
    {
        StackImplementedByLinkedList<char> _leftCharacters;
        StackImplementedByLinkedList<char> _rightCharacters;

        public Buffer()
        {
            _leftCharacters = new StackImplementedByLinkedList<char>();
            _rightCharacters = new StackImplementedByLinkedList<char>();
        }

        public void Insert(char c)
        {
            _leftCharacters.Push(c);
        }

        public char Delete()
        {
            return _leftCharacters.Pop();
        }

        public void Left(int k)
        {
            for (int i = 0; i < k; i++)
            {
                _rightCharacters.Push(_leftCharacters.Pop());
            }
        }

        public bool AtTheBegining()
        {
            return _leftCharacters.IsEmpty();
        }

        public bool AtTheEnd()
        {
            return _rightCharacters.IsEmpty();
        }

        void Right(int k)
        {
            for (int i = 0; i < k; i++)
            {
                _leftCharacters.Push(_rightCharacters.Pop());
            }
        }

        public static void TestClient()
        {
            var testSample = "How is everything going ?";
            var buffer = new Buffer();
            foreach (var item in testSample)
            {
                buffer.Insert(item);
            }
            Console.WriteLine("Cursor is at the end of the text '{0}'", testSample);
            Console.WriteLine("Move the cursor 8 to the left");
            buffer.Left(8);
            Console.WriteLine("Delete 10 charater");

            for (int i = 0; i < 10; i++)
            {
                buffer.Delete();
            }

            var leftText = new StringBuilder();

            while (!buffer.AtTheBegining())
            {
                leftText.Append(buffer.Delete());
            }

            Console.WriteLine("The left text to the cursor is '{0}'", Reverse(leftText.ToString()));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
