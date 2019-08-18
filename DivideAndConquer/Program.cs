using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {

            var url = @"C:\Users\chenqukun\Desktop\QuickSort.txt";
            var fileReader = System.IO.File.ReadAllLines(url);
            int[] arr = fileReader.Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(QuickSortSolution.QuickSort1(arr, 0, arr.Length - 1));
            Console.ReadKey();
        }
    }
}
