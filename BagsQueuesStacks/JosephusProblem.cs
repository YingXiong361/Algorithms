using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Exercise 1.3.37
    /// </summary>
    public class JosephusProblem
    {
        int N;
        int M;

        public JosephusProblem(int n, int m)
        {
            N = n;
            M = m;
        }

        public void Play()
        {
            var players = new Queue<int>();
            for (int i = 0; i < N; i++)
            {
                players.Enqueue(i);
            }
            Eliminate(players);
        }
        private void Eliminate(Queue<int> persons)
        {
            int j = 1;
            while (persons.Count > 1)
            {
                if (j % M == 0) { Console.WriteLine(persons.Dequeue()); }
                else { persons.Enqueue(persons.Dequeue()); }
                j++;
            }
            Console.WriteLine(persons.Dequeue());
        }
    }
}
