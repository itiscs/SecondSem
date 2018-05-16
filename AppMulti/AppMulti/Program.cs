using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppMulti
{
    class Program
    {
        static int N = 5000000, kol = 4;
        static object ob = new object();
        static int[] a = new int[N];

        static void Main(string[] args)
        {

            //Thread t1 = new Thread(Func1);
            //Thread t2 = new Thread(Func2);

            //t1.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.Lowest;

            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            //timer.Stop();

            //t1.Start();
            //t2.Start();
            //lock (ob)
            //{
            //    for (int i = 0; i < 340; i++)
            //        sum += i;
            //}
            //           Thread.Sleep(1000);
            //t1.Join();
            //t2.Join();
            //Console.Write($"Sum = {sum}\n");   

            //long time1, time2;

            Random r = new Random();
            for (int i = 0; i < N; i++)
            {

                a[i] = r.Next();

            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            int sump = 0;
            for (int i = 0; i < N; i++)
            {
                sump += a[i];
            }
            timer.Stop();
            var time1 = timer.ElapsedMilliseconds;

            timer.Restart();


            Task<int> t1 = new Task<int>(Func1);
            Task<int> t2 = new Task<int>(Func1);
            Task<int> t3 = new Task<int>(Func1);
            Task<int> t4 = new Task<int>(Func1);


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            //Task.WaitAll();
            var sum = t1.Result + t2.Result + t3.Result + t4.Result;
            timer.Stop();
            var time2 = timer.ElapsedMilliseconds;

            Console.WriteLine($"Sum={sum}  sump={sump} ");
            Console.WriteLine($"посл - {time1} с тасками - {time2} ");


            //List<int> li = new List<int>();

            //li.AsParallel().Sum();

            //Parallel.Invoke(Act1, Act2);


        }

        static int Func1()
        {
            int k = N / kol, sum = 0;
            int id = Convert.ToInt32(Task.CurrentId) - 1;
            int i1 = k * id;
            int i2 = k * (id + 1);
            //Console.WriteLine($"{id} - {i1} - {i2}");

            for (int i = i1; i < i2; i++)
                sum += a[i];// Console.Write($"{i} from thread 1\n");
            return sum;
        }

        static void Act2()
        {
        }
        static void Act1()
        {
        }






    }
}
