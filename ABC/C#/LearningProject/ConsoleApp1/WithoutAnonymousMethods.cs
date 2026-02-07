//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    public delegate string GreetingsDelegate(string name);
//    internal class WithoutAnonymousMethods
//    {

//        public static string Greetings(string name)
//        {
//            return "Hello " + name + " from Anonymous function!";
//        }
//        static void Main(string[] args)
//        {
//            GreetingsDelegate g = new GreetingsDelegate(Greetings);

//            //Console.WriteLine(g("Bhagyashree"));

//            string str = g("Bhagyashree");      //g.Invoke("Bhagyashree");
//            Console.WriteLine(str);

//        }
//    }
//}
