using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoinAndEvents
{

    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
    }


    public delegate void Deleg1(int k);

    public class MyEvent
    {

        public event Deleg1 UserEvent;

        public void OnUserEvent(int k)
        {
            if (UserEvent != null)
                UserEvent(k);

        }
    }



    class Program
    {


        public static void Handler1(int k)
        {
            Console.WriteLine($"Обработчик 1 Параметр - {k}");
        }

        public static void Handler2(int k)
        {
            Console.WriteLine($"Обработчик 2 Параметр - {k}");
        }

        static void Main(string[] args)
        {

            //List<Customer> custs = new List<Customer>()
            //{ new Customer() { ID = 1, Name = "Иванов", City = "Москва" },
            //  new Customer() { ID = 2, Name = "Сидоров", City = "Казань" },
            //  new Customer() { ID = 3, Name = "Петров", City = "СПб" },
            //  new Customer() { ID = 4, Name = "Попов", City = "Самара" }
            //};

            //List<Order> orders = new List<Order>()
            //{
            //    new Order(){ID=1, CustomerID=1,ProductID=1,Count=100, Amount=1000m},
            //    new Order(){ID=2, CustomerID=1,ProductID=1,Count=50, Amount=500m},
            //    new Order(){ID=3, CustomerID=1,ProductID=1,Count=60, Amount=600m},
            //    new Order(){ID=4, CustomerID=2,ProductID=1,Count=70, Amount=700m},
            //    new Order(){ID=5, CustomerID=2,ProductID=1,Count=150, Amount=1500m},
            //    new Order(){ID=6, CustomerID=4,ProductID=1,Count=250, Amount=2500m}

            //};


            //var lst = orders.Join(custs, o => o.CustomerID, c => c.ID,
            //    (o, c) => new {c.Name,c.City,o.ProductID, o.Count, o.Amount });

            //var lst2 = custs.GroupJoin(orders, с => с.ID, o => o.CustomerID,
            //    (c, o) => new { c.Name, c.City, Orders = o });


            //Console.WriteLine(lst.Count());
            //foreach(var l in lst )
            //{
            //    Console.WriteLine($"{l.Name} {l.City} {l.ProductID} {l.Count} {l.Amount}");

            //}
            //Console.WriteLine("***********************************");


            //foreach (var l1 in lst2)
            //{
            //    Console.WriteLine($"{l1.Name} {l1.City}");
            //    foreach (var g in l1.Orders)
            //           Console.WriteLine($"                   {g.ProductID} {g.Count} {g.Amount}");

            //}




            MyEvent ev = new MyEvent();

            ev.UserEvent += Handler1;
            ev.UserEvent += Handler2;


            for (int i = 0; i < 100; i++)
            {
                if (i == 42)
                    ev.OnUserEvent(i);
            }


        }
    }
}
