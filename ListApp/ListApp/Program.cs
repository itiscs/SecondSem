using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    class Element
    {
        public int Info { get; set; }
        public Element Next { get; set; }
    }

    class List
    {
        public Element First { get; set; }

        public void AddFirst(int x)
        {
            Element elem = new Element();
            elem.Info = x;
            elem.Next = First;

            First = elem;
        }

        public void AddLast(int x)
        {
            if(First==null)
            {
                First = new Element() { Info = x };
            }
            else
            {
               Element last = First;
               while (last.Next != null)
                    last = last.Next;

                last.Next = new Element() { Info = x };
            }
        }


        public void ShowList()
        {
            Element elem = First;
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
            List lst = new List();

            for(int i=10;i>0;i--)
            {
                lst.AddLast(i);
            }

            lst.ShowList();
        }
    }
}
