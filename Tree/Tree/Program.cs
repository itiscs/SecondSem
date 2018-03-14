using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Left { get; set; }
        public Elem<T> Right { get; set; }
    }

    class Tree<T>
    {
        public Elem<T> Root { get; set; }

        private void ShowElem(Elem<T> t)
        {
            if (t == null) return;
            if (t.Left == t.Right)
                Console.Write(t.Info);
            else
            {
                Console.Write($"({t.Info},");
                ShowElem(t.Left);
                Console.Write(",");
                ShowElem(t.Right);
                Console.Write(")");
            }
        }

        public void ShowTree()
        {
            ShowElem(Root);
        }

        
    }

    class Elem
    {
        public int Info { get; set; }
        public Elem Left { get; set; }
        public Elem Right { get; set; }
    }

    class Tree
    {
        public Elem Root { get; set; }

        private void ShowElem(Elem t)
        {
            if (t == null) return;
            if (t.Left == t.Right)
                Console.Write(t.Info);
            else
            {
                Console.Write($"({t.Info},");
                ShowElem(t.Left);
                Console.Write(",");
                ShowElem(t.Right);
                Console.Write(")");
            }
        }

        public void ShowTree()
        {
            ShowElem(Root);
            Console.WriteLine();
        }

        private int SumElem(Elem t)
        {
            if (t == null)
                return 0;
            else
                return SumElem(t.Left) + SumElem(t.Right) + t.Info;
            
        }

        public int SumTree()
        {
            return SumElem(Root);
        }

        private Elem CreateElem(string[] str, ref int k)
        {

            if (!str[k].Contains('('))
            {
                return new Elem() { Info = int.Parse(str[k]) };
            }
            else
            {
                Elem t = new Elem();
                t.Info = int.Parse(str[k].Remove(0, 1));//убрали '(' 
                k++;
                if (str[k] != "")
                    t.Left = CreateElem(str, ref k);
                k++;
                if (str[k] != "")
                    t.Right = CreateElem(str, ref k);
                k++;
                return t;
            }
            
        }

        public void CreateTree(string inputStr)
        {
            String[] str = inputStr.Split(new char[] { ',', ')' });
            int k = 0;

            Root = CreateElem(str,ref k);
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            //Tree<int> t = new Tree<int>();

            //t.Root = new Elem<int>()
            //{
            //    Info = 1,
            //    Left = new Elem<int>() { Info = 2,
            //        Left  = new Elem<int>() { Info = 4},
            //        Right = new Elem<int>() { Info = 5}
            //    },
            //    Right = new Elem<int>() { Info = 3,
            //        //Left  = new Elem<int>() { Info = 6 },
            //        Right = new Elem<int>() { Info = 7,
            //            Left  = new Elem<int>() { Info = 8 },
            //            Right = new Elem<int>() { Info = 9 }
            //        }
            //    }
            //};

            //t.ShowTree();
            //Console.WriteLine();

            //Tree t1 = new Tree();

            //t1.Root = new Elem()
            //{
            //    Info = 1,
            //    Left = new Elem()
            //    {
            //        Info = 2,
            //        Left = new Elem() { Info = 4 },
            //        Right = new Elem() { Info = 5 }
            //    },
            //    Right = new Elem()
            //    {
            //        Info = 3,
            //        Left = new Elem() { Info = 6 },
            //        Right = new Elem()
            //        {
            //            Info = 7,
            //            Left = new Elem() { Info = 8 },
            //            Right = new Elem() { Info = 9 }
            //        }
            //    }
            //};

            //Console.WriteLine($"Sum = {t1.SumTree()}");


            String str = Console.ReadLine();

            Tree t = new Tree();
            t.CreateTree(str);

            t.ShowTree();
            Console.WriteLine(t.SumTree());


        }
    }
}
