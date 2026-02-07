//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    public delegate void myDelegate();
//    class Delegates
//    {
//        public void showMessage()
//        {
//            Console.WriteLine("show message");
//        }
//        public void printMessage()
//        {
//            Console.WriteLine("print message");
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hii from Delegates");

//            Delegates d = new Delegates();

//            myDelegate del = d.showMessage;
//            del();


//            //multicast delegate +=
//            del += d.printMessage;
//            del();
//        }
//    }
//}
