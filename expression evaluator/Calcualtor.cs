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

         /// <summary>
         /// Taking the one expression as input and return the result.
         /// </summary>
         /// <param name="args">the expression input.</param>
        public static void Main(string[] args) {

            if (args.Length == 0 || args[0].Length == 0)
        {
            Console.WriteLine("Enter an expression like 5+2*3-1 as a command-line argument.");
            return;
        }

        string name = args[0].Replace(" ", ""); // remove spaces if any



        List<double> numbers = new List<double>(); //Taking numbers into one list.
        List<char> operators = new List<char>();   //Taking operators into another list.

        if (numbers.Count == 5)
            {
                Console.WriteLine("this is the invalid expression with the four operators.");
            }

        
        string num = "";

        for (int i = 0; i < name.Length; i++)    //parsing
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

        for (int i = 0; i < operators.Count;)     //here we are adding the process like * and / operations will done before going to + and -.
        {
            if (operators[i] == '*' || operators[i] == '/')
            {
                double left = numbers[i];
                double right = numbers[i + 1];
                    double result;

                    if (operators[i] == '*')
                    {
                        result = left * right;
                    }
                    else if (right == 0)
                    {
                        result = left / right;
                        Console.WriteLine("divison by zero is undefined");
                        return;
                    }
                    else
                    {
                         result = (int) left / (int) right;
                    }

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

        for (int i = 0; i < operators.Count; i++)    //here is the process of the + and - operation.
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


