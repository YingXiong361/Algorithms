using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Exercise 1.3.45
    /// </summary>
    public static class StackGenerabilityTester
    {
        public static readonly string GoodSample="to be or not to - be - - that - - - is";
        public static readonly string BadSample = "to - be - - that - - - is";
        public static bool CanPermutationBeGenerated(this string sample)
        {
            int leftElementNum = 0;
            foreach (var item in sample.Split(' ').ToList())
            {
                if (item != "-")
                {
                    leftElementNum++;
                }
                else
                {
                    if (leftElementNum == 0)
                    {
                        return false;
                    }
                    leftElementNum--;
                }
            }
            return true;
        }
    }
}
