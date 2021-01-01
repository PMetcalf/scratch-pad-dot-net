﻿using System;

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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
