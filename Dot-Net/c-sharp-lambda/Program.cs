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
            // --- Here is a basic example --- 

            // List to store numbers
            List<int> numbers = new List<int>()
            {
                36, 71, 12, 15, 29, 18, 27, 17, 9, 34
            };

            // Foreach loop to display the numbers
            Console.Write("The List : ");
            foreach(var value in numbers)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            // Using Lambda to calculate square of each value
            var squares = numbers.Select(x => x * x);

            // Foreach loop to display squares
            Console.Write("Squares : ");
            foreach(var value in squares)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            // Using Lambda to find all numbers divisible by three
            List<int> divBy3 = numbers.FindAll(x => (x % 3) == 0);

            // Foreach loop to display divisible numbers
            Console.Write("Numbers divisible by 3 : ");
            foreach(var value in divBy3)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            // --- Here is an example with Classes ---

            // List of students
            List<Student> details = new List<Student>()
            {
                new Student{ rollNo = 1, name = "Paul"},
                new Student{ rollNo = 2, name = "Amy"},
                new Student{ rollNo = 3, name = "Chris"},
                new Student{ rollNo = 4, name = "Jamie"},
                new Student{ rollNo = 5, name = "Eugene"}
            };

            // Use Lambda to sort details list based on name in ascending order
        }
    }

    // User defined student class
    class Student
    {
        public int rollNo
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }

}
