using System;

namespace c_sharp_inheritance
{
    // Base class
    public class User
    {
        public string Name;

        private string Location;

        // Base class constructor
        public User()
        {
            Console.WriteLine("Base Class Constructor");
        }

        // Base class method
        public void GetUserInfo(string loc)
        {
            Location = loc;

            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Location: {0}", Location);
        }
    }

    // Child class (inherited)
    public class Details : User
    {
        public int Age;

        // Child class constructor
        public Details()
        {
            Console.WriteLine("Child Class Constructor");
        }

        // Child method
        public void GetAge()
        {
            Console.WriteLine("Age: {0}", Age);
        }
    }

    // Second child class (inherited)
    public class Jobdetails : Details
    {
        public string Job;

        // Constructor
        public Jobdetails()
        {
            Console.WriteLine("Tertiary Class Constructor");
        }

        // Child method
        public void GetJob()
        {
            Console.WriteLine("Job: {0}", Job);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Details details = new Details();
            details.Name = "Paul";
            details.Age = 35;

            details.GetUserInfo("Wirral");
            details.GetAge();

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadLine();
        }
    }
}
