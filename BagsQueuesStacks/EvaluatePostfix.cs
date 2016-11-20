using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsQueuesStacks
{
    public static class EvaluatePostfix
    {
        public const string Input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        private const string RightParenthese = ")";
        private static readonly Dictionary<string, Func<double, double, double>> ArithmeticHandler = new Dictionary<string, Func<double, double, double>>{
            {"+",(x,y)=>x+y},
            {"-",(x,y)=>x-y},
            {"*",(x,y)=>x*y},
            {"/",(x,y)=>x/y}
        };

        private static readonly HashSet<string> Operators = new HashSet<string> { "+", "-", "*", "/" };

        private static bool IsOperator(this string elem)
        {
            return Operators.Contains(elem);
        }

        public static double Evaluate(string input)
        {
            var operators = new Stack<string>();
            var operands = new Stack<string>();
            foreach (var elem in input.Split(' '))
            {
                if (elem != RightParenthese)
                {
                    if (elem.IsOperator())
                    {
                        operators.Push(elem);
                    }
                    else
                    {
                        operands.Push(elem);
                    }
                }
                else
                {
                    var operatorStr = operators.Pop();
                    var operandsRight = double.Parse(operands.Pop());
                    var operandsLeft = double.Parse(operands.Pop());
                    operands.Push(ArithmeticHandler[operatorStr](operandsLeft, operandsRight).ToString());
                }
            }

            return double.Parse(operands.Pop());
        }
    }
}
