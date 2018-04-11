using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    class Elem
    {
        public readonly int LeftIndex; //{ get; private set; }
        public readonly int RightIndex;// { get; private set; }
        public int Info { get; set; }
        public Elem Left { get; set; }
        public Elem Right { get; set; }

        public Elem(int li, int ri)
        {
            LeftIndex = li;
            RightIndex = ri;
        }

    }
    class SegmentTree
    {
        public Elem Root { get; set; }

        private Elem CreateElem(int[] x, int li, int ri, Func<int, int, int> func)
        {
            Elem el = new Elem(li, ri);
            if (li == ri)
            {
                el.Info = x[li];                
            }
            else
            {
                int mi = (li + ri) / 2;
                el.Left = CreateElem(x, li, mi, func);
                el.Right = CreateElem(x, mi + 1, ri, func);
                el.Info = func(el.Right.Info,el.Left.Info);
            }
            return el;
        }
        public void CreateTree(int[] x, Func<int,int,int> func)
        {
            int n = x.Count();
            Root = CreateElem(x, 0, n - 1, func);
        }

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


    }




    class Program
    {
        static void Main(string[] args)
        {
            int N = 15;
            int[] x = new int[N];
            for (int i = 0; i < N; i++)
                x[i] = i;

            SegmentTree t = new SegmentTree();
            t.CreateTree(x, (a,b) => a>b?a:b);
            t.ShowTree();

        }
    }
}
