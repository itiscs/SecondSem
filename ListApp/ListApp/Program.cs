using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    class Element<T>
    {
        public T Info { get; set; }
        public Element<T> Next { get; set; }
    }

    class List<T>
    {
        public Element<T> First { get; set; }

        public void AddFirst(T x)
        {
            Element<T> elem = new Element<T>();
            elem.Info = x;
            elem.Next = First;

            First = elem;
        }

        public void AddLast(T x)
        {
            if(First==null)
            {
                First = new Element<T>() { Info = x };
            }
            else
            {
               Element<T> last = First;
               while (last.Next != null)
                    last = last.Next;

                last.Next = new Element<T>() { Info = x };
            }
        }


        public void ShowList()
        {
            Element<T> elem = First;
            while(elem != null)
            {
                Console.Write($"{elem.Info}->");
                elem = elem.Next;
            }
            Console.WriteLine("null");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int>();

            for(int i=10;i>0;i--)
            {
                lst.AddLast(i);
            }

            lst.ShowList();
        }
    }
}
