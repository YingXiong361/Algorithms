using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // FixedCapacityStackOfStrings.RunClient(FixedCapacityStackOfStrings.TestSample);
            // FixedCapacityStack<string>.RunClient(FixedCapacityStack<string>.TestSample);
            // ResizableStack<string>.RunClient(ResizableStack<string>.TestSample);

            //var queue = new ResizableQueue<string>(3);
            //foreach (var item in ResizableStack<string>.TestSample.Split(' ').ToList())
            //{
            //    queue.Enqueue(item.ToString());
            //}

            //foreach (var item in queue)
            //{
            //    Console.Write(item + " ");
            //}

            // ResizableQueue<string>.RunClient(ResizableQueue<string>.TestSample);
            //StackImplementedByLinkedList<string>.RunClient(StackImplementedByLinkedList<string>.TestSample);

            //var stack = new StackImplementedByLinkedList<string>();
            //foreach (var item in StackImplementedByLinkedList<string>.TestSample.Split(' ').ToList())
            //{
            //    stack.Push(item.ToString());
            //}

            //foreach (var item in stack)
            //{
            //    Console.Write(item + " ");
            //}

            //     QueueImplementedByCircularLinkedList<string>.RunClient(QueueImplementedByCircularLinkedList<string>.TestSample);

            //var queue = new QueueImplementedByLinkedList<string>();

            //foreach (var item in QueueImplementedByLinkedList<string>.TestSample.Split(' ').ToList())
            //{
            //    queue.Enqueue(item.ToString());
            //}

            //foreach (var item in queue)
            //{
            //    Console.Write(item + " ");
            //}
            //var moveToFront = new MoveToFront();
            //var testSample = "LBJLBJ";
            //Console.WriteLine("Input: {0}", testSample);
            //foreach (var item in testSample.ToCharArray())
            //{
            //    moveToFront.InsertInTheFront(item);
            //}
            //Console.WriteLine(moveToFront.ToString());

            //IRingBuffer<int> buffer = new RingBuffer<int>(4);
            //for (int i = 0; i < 4; i++)
            //{
            //    buffer.Enqueue(i);
            //    Console.WriteLine("IsFull="+buffer.IsFull());
            //}

            //RingBuffer<int>.RunClient();

            //Console.WriteLine(StackGenerabilityTester.CanPermutationBeGenerated(StackGenerabilityTester.GoodSample));
            //Console.WriteLine(StackGenerabilityTester.CanPermutationBeGenerated(StackGenerabilityTester.BadSample));

            //    Buffer.TestClient();
            //var game = new JosephusProblem(7, 2);
            //game.Play();

            //Console.WriteLine("Press any key to stop the program");

            // Console.WriteLine(EvaluatePostfix.Evaluate(InfixToPostfix.Transform(InfixToPostfix.Input)));

            //var testData = new int[] { 5, 1, 2, 3, 4 };

            //Search.InsertionSort(testData);
            //testData.Print();
            Console.WriteLine(Solution.NumSquares(7168));
            Console.ReadKey();
        }

    }

    public class Solution
    {
        public static int NumSquares(int n)
        {
            var pS = new List<int>();
            for (int i = n; i >0; i--)
            {
                if (IsSquare(i))
                {
                    pS.Add(i);
                }
            }

            return GetStep(pS,0,0,n);
        }

        private static int GetStep(List<int> ps,int sum,int? step,int n)
        {
            if(sum==n) return step.Value;
            if(sum>n) return int.MaxValue;
             step=step.Value+1;
             var min=int.MaxValue;
            for(int i=0;i<ps.Count;i++)
            {
                var x = GetStep(ps, (sum + ps[i]), step, n);
                if(x<min)
                {
                    min=x;
                }
            }

            return min;
        }

        private static bool IsSquare(int num)
        {
            for (int i = 1; num > 0; i += 2)
            {
                num -= i;
            }

            return num == 0;
        }
    }
}
