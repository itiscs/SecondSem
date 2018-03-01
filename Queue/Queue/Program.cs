using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Element<T>
    {
        public T Info { get; set; }
        public Element<T> Next { get; set; }
    }

    class Queue<T>
    {
        public Element<T> BeQueue { get; set; }
        public Element<T> EnQueue { get; set; }

        public bool IsEmpty()
        {
            return EnQueue == null;
        }

        public T Pop()
        {
            T beg = BeQueue.Info;
            BeQueue = BeQueue.Next;
            if (BeQueue == null)
                EnQueue = null;
            return beg;            
        }

        public void Push(T info)
        {
            Element<T> elem = new Element<T>();
            elem.Info = info;
            if (EnQueue == null)
            {
                BeQueue = elem;
                EnQueue = elem;
            }
            else
            {
                EnQueue.Next = elem;
                EnQueue = elem;
            }
        }

    }

   
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();
           


            Queue<int> q = new Queue<int>();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            q.Push(4);
            q.Push(5);
            Console.WriteLine($"{q.Pop()}***********");
            q.Push(6);
            while(!q.IsEmpty())
            {
                int k;
                k = q.Pop();
                Console.WriteLine(k);
            }

        }
    }
}
