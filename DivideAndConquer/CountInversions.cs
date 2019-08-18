using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer
{
    public class CountInversionSolutions
    {
        public static Int64 CountInversions(int[] arr)
        {
            int size = arr.Length;
            int[] tempArr = new int[size];
            return CountInversion(arr, tempArr, 0, size - 1);
        }

        private static Int64 CountInversion(int[] arr, int[] temp, int left, int right)
        {
            if (left == right) return 0;
            int mid = (left + right) / 2;
            Int64 a = CountInversion(arr, temp, left, mid);
            Int64 b = CountInversion(arr, temp, mid + 1, right);
            int c = 0;
            int i = left;
            int j = mid + 1;
            for (int k = left; k <= right; k++)
            {
                if (j > right || (i <= mid && arr[i] <= arr[j]))
                {
                    temp[k] = arr[i++];
                }
                else
                {
                    temp[k] = arr[j++];
                    c += (i <= mid ? mid + 1 - i : 0);
                }
            }

            for (int k = left; k <= right; k++)
            {
                arr[k] = temp[k];
            }

            return a + b + c;
        }
    }
}
