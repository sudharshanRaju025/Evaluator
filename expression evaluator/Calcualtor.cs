using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace expression_evaluator
{
    internal class Calcualtor
    {
        public static void Main(string[] args) {

            if (args.Length == 0 || args[0].Length == 0)
        {
            Console.WriteLine("Enter an expression like 5+2*3-1 as a command-line argument.");
            return;
        }

        string name = args[0].Replace(" ", ""); // remove spaces if any

        List<double> numbers = new List<double>();
        List<char> operators = new List<char>();

        string num = "";

        for (int i = 0; i < name.Length; i++)
        {
            char ch = name[i];
            if (char.IsDigit(ch) || ch == '.')
            {
                num += ch;
            }
            else
            {
                numbers.Add(double.Parse(num));
                num = "";
                operators.Add(ch);
            }
        }
        numbers.Add(double.Parse(num));

        for (int i = 0; i < operators.Count;)
        {
            if (operators[i] == '*' || operators[i] == '/')
            {
                double left = numbers[i];
                double right = numbers[i + 1];
                double result = operators[i] == '*' ? left * right : left / right;

                numbers[i] = result;
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        double finalResult = numbers[0];

        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == '+')
                finalResult += numbers[i + 1];
            else
                finalResult -= numbers[i + 1];
        }

        Console.WriteLine("Result: " + finalResult);
        }
    }
        
    }


