using System;

namespace c_sharp_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Users
    {
        // Class fields
        public int id = 0;
        public string name = string.Empty;

        // Class Constructor Statement
        public Users()
        {

        }

        public void GetUserDetails(int userid, string username)
        {
            id = userid;
            username = name;
            Console.WriteLine("Id: {0}, Name: {1}", id, name);
        }

        // Class Properties
        public int Designation { get; set; }
        public int Location { get; set; }
    }
}
