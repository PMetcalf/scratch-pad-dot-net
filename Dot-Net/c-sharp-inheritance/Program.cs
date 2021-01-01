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


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
