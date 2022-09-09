using System;
using System.Linq;

namespace Screening
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Press a for Part 1");
                Console.WriteLine("Press b for Part 2");
                Console.WriteLine("Press x for  Exit");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "A")
                {
                    Console.WriteLine("Enter Expression");
                    string expression = Console.ReadLine();
                    Console.WriteLine(expression + " = " + ScientificCalculator.EvaluateExpression(expression));
                }
                else if (choice == "B")
                {
                    Console.WriteLine("Enter number: ");
                    Console.WriteLine("Output: " + findPeterNumber(Console.ReadLine()));
                }
                else if (choice == "X")
                    break;


            }
        }
        static string findPeterNumber(string number)
        {
         
            int i = 0;
            while (i+1<number.Length)
            {
                if (number[i] > number[i + 1])
                {
                    number = number.Substring(0,i) + number[i + 1] + String.Concat(Enumerable.Repeat("9", number.Length - (i + 1)));;
                    i = 0;
                }
                else
                    i += 1;
            }
            return number;
        }
    }
    
}
