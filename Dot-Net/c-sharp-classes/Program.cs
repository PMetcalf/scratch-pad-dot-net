using System;

namespace c_sharp_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Users user = new Users("Paul", 35);
            user.GetUserDetails();

            Console.WriteLine("Press Enter Key to Exit ...");
            Console.ReadLine();
        }
    }

    public class Users
    {
        // Class fields
        public int id = 0;

        // Class Properties
        public string Name { get; set; }
        public int Age { get; set; }

        // Class Constructor Statement
        public Users(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void GetUserDetails()
        {
            Console.WriteLine("Name: {0}, Age: {1}", Name, Age);
        }
    }
}
