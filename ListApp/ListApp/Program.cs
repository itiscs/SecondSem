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

        public void Merge(List<T> ls)
        {

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
            List<int> lst1 = new List<int>(), lst2 = new List<int>(), lst3 = new List<int>();

            for(int i=0;i<10;i++)
            {
                lst1.AddLast(2 * i + 1);
                lst2.AddLast(3 * i);
            }
            
            lst1.ShowList();
            lst2.ShowList();

            Element<int> l1 = lst1.First, l2=lst2.First;

            while(l1!=null && l2!=null)
            {
                if(l1.Info < l2.Info)
                {
                    lst3.AddLast(l1.Info);
                    l1 = l1.Next;
                }
                else
                {
                    lst3.AddLast(l2.Info);
                    l2 = l2.Next;
                }
            }


            lst3.ShowList();



        }
    }
}
