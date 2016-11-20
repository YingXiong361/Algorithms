using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    /// <summary>
    /// Exercise 1.3.10
    /// </summary>
    public class InfixToPostfix
    {
        public const string Input = "( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )";
        public const string ExpectedOutput = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        private const string LeftParenthese = "(";
        private const string espace = " ";

        public static string Transform(string input)
        {
            var postfixExpression = new StringBuilder();
            foreach (var elem in input.Split(' '))
            {
                if (elem == LeftParenthese) { continue; }
                postfixExpression.Append(elem + espace);
            }
            return postfixExpression.Remove(postfixExpression.Length-1,1).ToString();
        }
    }
}
