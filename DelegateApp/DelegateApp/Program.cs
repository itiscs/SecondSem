using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    
    class Program
    {
        delegate int ArOper(int a, int b);
        delegate void Hello();

        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        public static int Mult(int a, int b)
        {
            return a * b;
        }
        public static int Div(int a, int b)
        {
            return a / b;
        }

        public static void Hello1()
        {
            Console.WriteLine("Hello 1");
        }
        public static void Hello2()
        {
            Console.WriteLine("Hello 2");
        }


        static void Main(string[] args)
        {
            //ArOper ar = new ArOper(Sum);
            Func<int, int, int> ar = new Func<int, int, int>(Sum);
            //Console.WriteLine(ar(13, 5));

            //ar = delegate (int a, int b)
            //{
            //    return a % b;
            //};
            ar = (a, b) => a % b;

            Console.WriteLine(ar(13, 5));

            ar = (c, d) => c - d; 
            Console.WriteLine(ar(13, 5));

            //ar = Mult;
            //Console.WriteLine(ar(13, 5));

            //ar = Div;
            //Console.WriteLine(ar(13, 5));


            //Hello he = new Hello(Hello1);
            //he();
            Action he = new Action(Hello1);

            he += Hello2;
            he += () => { Console.WriteLine("Hello 3"); };
            
            //he -= Hello2;
            he();




        }
    }
}
