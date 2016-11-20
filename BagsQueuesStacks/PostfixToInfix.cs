using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Exercise 1.3.9
    /// </summary>
    public class PostfixToInfix
    {
        public const string Input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        public const string ExpectedOutput = "( ( 1 + 2 ) * ( ( 3 - 4 ) * (5 - 6 ) ) )";
        private const string RightParentheses = ")";
        private const string LeftParentheses = "(";

        public static string Transform(string input)
        {
            var inputs = new Stack<string>();
            foreach (var elem in input.Split(' '))
            {
                if (elem != RightParentheses)
                {
                    inputs.Push(elem);
                }
                else
                {
                    var input1 = inputs.Pop();
                    var input2 = inputs.Pop();
                    var input3 = inputs.Pop();
                    inputs.Push(LeftParentheses + input3 + input2 + input1 + RightParentheses);
                }
            }
            return inputs.Pop();
        }
    }
}
