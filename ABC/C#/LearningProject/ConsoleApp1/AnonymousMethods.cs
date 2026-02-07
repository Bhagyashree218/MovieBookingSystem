using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate string GreetingsDelegate(string name);

    //public delegate void GreetingsDelegate(string name);
    internal class AnonymousMethods
    {

        static void Main(string[] args)
        {
            //GreetingsDelegate g = new GreetingsDelegate(Greetings);
            GreetingsDelegate g = delegate (string name)
            {
                return "Hello " + name + " from Anonymous function!";
            };

            string str = g("Bhagyashree");
            Console.WriteLine(str);


            //GreetingsDelegate g = delegate (string name)
            //{
            //    Console.WriteLine( "Hello " + name + " from Anonymous function!");
            //};

            //g("Bhagyashree");

        }
    }
}
