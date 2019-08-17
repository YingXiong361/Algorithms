using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public static class Search
    {
        public static void BubbleSort0(int[] lst)
        {
            for (int i = 0; i < lst.Length - 1; i++)
            {
                for (int j = i + 1; j < lst.Length; j++)
                {
                    if (lst[j] < lst[i])
                    {
                        lst.Switch(i, j);
                    }
                }
            }
        }

        //两两比较 相邻记录 的关键字，反序则交换
        //stable
        public static void BubbleSort1(int[] lst)
        {
            for (int i = 0; i < lst.Length - 1; i++)
            {
                bool noSwitch = true;
                for (int j = lst.Length - 2; j >= i; j--)
                {
                    if (lst[j] > lst[j + 1])
                    {
                        lst.Switch(j, j + 1);
                        noSwitch = false;
                    }
                }

                Console.WriteLine("Iterate {0}", i);
                if (noSwitch)
                {
                    break;
                }
            }
        }

        public static void SelectionSort(int[] lst)
        {
            for (int i = 0; i < lst.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < lst.Length; j++)
                {
                    if (lst[j] < lst[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    lst.Switch(i, minIndex);
                }
            }
        }

        public static void InsertionSort(int[] lst)
        {
            for (int i = 1; i < lst.Length; i++)
            {
                int toBeInsertValue = lst[i];
                int j;
                for ( j = i - 1; j >= 0 && lst[j] > toBeInsertValue; j--)
                {

                    lst[j + 1] = lst[j];
                }
                lst[j + 1] = toBeInsertValue;
            }

        }

        #region Extension

        private static void Switch(this int[] lst, int i, int j)
        {
            var temp = lst[i];
            lst[i] = lst[j];
            lst[j] = temp;
        }

        public static void Print(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write("{0} ", item);
            }
        }

        #endregion
    }
}
