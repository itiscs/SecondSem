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



        public static Tree<T> CreateTree(string str)
        {
            return null;
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
        
    }




    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> t = new Tree<int>();

            t.Root = new Elem<int>()
            {
                Info = 1,
                Left = new Elem<int>() { Info = 2,
                    Left  = new Elem<int>() { Info = 4},
                    Right = new Elem<int>() { Info = 5}
                },
                Right = new Elem<int>() { Info = 3,
                    //Left  = new Elem<int>() { Info = 6 },
                    Right = new Elem<int>() { Info = 7,
                        Left  = new Elem<int>() { Info = 8 },
                        Right = new Elem<int>() { Info = 9 }
                    }
                }
            };

            t.ShowTree();
            Console.WriteLine();

            Tree t1 = new Tree();

            t1.Root = new Elem()
            {
                Info = 1,
                Left = new Elem()
                {
                    Info = 2,
                    Left = new Elem() { Info = 4 },
                    Right = new Elem() { Info = 5 }
                },
                Right = new Elem()
                {
                    Info = 3,
                    Left = new Elem() { Info = 6 },
                    Right = new Elem()
                    {
                        Info = 7,
                        Left = new Elem() { Info = 8 },
                        Right = new Elem() { Info = 9 }
                    }
                }
            };

            Console.WriteLine($"Sum = {t1.SumTree()}");



        }
    }
}
