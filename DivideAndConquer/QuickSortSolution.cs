using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer
{
    public class QuickSortSolution
    {
        public static int QuickSort1(int[] arr, int left, int right)
        {
            if (left >= right) return 0;

            //chose pivot
            var pivot = arr[left];
            var a = right - left;

            int j = left + 1;
            //partition
            for (int i = left + 1; i <= right; i++)
            {
                if (arr[i] < pivot)
                {
                    var temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    j++;
                }
            }

            var temp1 = arr[left];
            arr[left] = arr[j - 1];
            arr[j - 1] = temp1;

            var b = QuickSort1(arr, left, j - 2);
            var c = QuickSort1(arr, j, right);


            //recursive call


            return a + b + c;
        }

        public static int QuickSort2(int[] arr, int left, int right)
        {
            if (left >= right) return 0;

            //chose pivot
            var a = right - left;
            var pivot = arr[right];

            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            int j = left + 1;
            //partition
            for (int i = left + 1; i <= right; i++)
            {
                if (arr[i] < pivot)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    j++;
                }
            }

            temp = arr[left];
            arr[left] = arr[j - 1];
            arr[j - 1] = temp;

            var b = QuickSort2(arr, left, j - 2);
            var c = QuickSort2(arr, j, right);


            //recursive call


            return a + b + c;
        }

        public static int QuickSort3(int[] arr, int left, int right)
        {
            if (left >= right) return 0;

            //chose pivot
            var a = right - left;
            var mid = (left + right) / 2;
            int pivotIndex = 0;

            //find median
            int[] mins = new int[2];
            if(arr[left]<arr[right])
            {
                mins[0] = left;
                mins[1] = right;
            }
            else
            {
                mins[0] = right;
                mins[1] = left;
            }

            if(arr[mid]<arr[mins[1]])
            {
                mins[1] = mid;
            }

            if(arr[mins[1]]>arr[mins[0]])
            {
                pivotIndex = mins[1];
            }
            else
            {
                pivotIndex = mins[0];
            }

            var pivot = arr[pivotIndex];

            var temp = arr[left];
            arr[left] = arr[pivotIndex];
            arr[pivotIndex] = temp;

            int j = left + 1;
            //partition
            for (int i = left + 1; i <= right; i++)
            {
                if (arr[i] < pivot)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    j++;
                }
            }

            temp = arr[left];
            arr[left] = arr[j - 1];
            arr[j - 1] = temp;

            var b = QuickSort3(arr, left, j - 2);
            var c = QuickSort3(arr, j, right);


            //recursive call


            return a + b + c;
        }
    }
}
