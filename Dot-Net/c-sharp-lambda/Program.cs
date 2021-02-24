// C# program to illustrate the Lambda Expression.
using System;
using System.Collections.Generic;
using System.Linq;

namespace c_sharp_lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to store numbers
            List<int> numbers = new List<int>()
            {
                36, 71, 12, 15, 29, 18, 27, 17, 9, 34
            };

            // Foreach loop to display the numbers
            Console.WriteLine("The List : ");
            foreach(var value in numbers)
            {
                Console.WriteLine("{0} ", value);
            }
            Console.WriteLine();

            // Using Lambda to calculate square of each value

            // Using Lambda to find all numbers divisible by three

            // Foreach loop to display divisible numbers
        }
    }
}
