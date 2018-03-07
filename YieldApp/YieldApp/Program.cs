using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldApp
{
    class Program
    {

        public static IEnumerable<int> Fibonacci
        {
            get
            {
                var a = 1;
                var b = 1;
                yield return 1;
                yield return 1;
                while (true)
                {
                    var c = a + b;
                    a = b;
                    b = c;
                    // if (c > max)
                    //   yield break;
                    yield return c;
                }
            }
            
        }
        
        static void Main(string[] args)
        {

            foreach(int i in Fibonacci)
            {
                if (i > 10000) break;
                Console.WriteLine(i);
            }


        }
    }
}
