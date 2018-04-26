using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInqApp
{

    class Fitness
    {
        public int ClientID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Duration { get; set; }

    }

    class Zadolgn
    {
        public string FIO { get; set; }
        public decimal Debt { get; set; }
        public int Flat { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var kls = new List<Fitness>();
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2018, Month = 1, Duration = 100 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2018, Month = 2, Duration = 200 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2018, Month = 3, Duration = 150 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2018, Month = 4, Duration = 250 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2016, Month = 5, Duration = 100 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2018, Month = 6, Duration = 300 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2017, Month = 1, Duration = 0 });
            kls.Add(new Fitness()
            { ClientID = 1, Year = 2017, Month = 2, Duration = 450 });

            //
            var res = kls.Where(k => k.Duration > 0).GroupBy(k => k.Year, (k, s) => new { Year = k,
                MinDur = s.First(f => f.Duration == s.Min(g => g.Duration)) });//.OrderBy(g=>g.MinDur);

            foreach(var kl in res)
            {
                Console.WriteLine($"{kl.Year} {kl.MinDur.Month} {kl.MinDur.Duration}");
            }

            Random r = new Random();
            var zds = new List<Zadolgn>();
            for(int i=1;i<145;i++)
            {
                zds.Add(new Zadolgn()
                {
                    FIO = $"Name {i}",
                    Debt = Convert.ToDecimal(r.Next()),
                    Flat = i
                });
            }

            var res1 = zds.Select(z => new { z.FIO, z.Flat, Ent = (z.Flat-1) / 36 + 1,
                Floor = (z.Flat - 1) % 36 / 4 + 1 , z.Debt });

            foreach(var r1 in res1)
            {
                Console.WriteLine($"Entr={r1.Ent}   Floor={r1.Floor} ");
            }

            //Исходная последовательность содержит сведения об оценках учащихся по трем предметам: 
            //алгебре, геометрии и информатике.Каждый элемент последовательности содер-жит данные 
            //об одной оценке и включает следующие поля:
            //< Класс > < Фамилия > < Инициалы > < Название предмета > < Оценка >
            //Полных однофамильцев(с совпадающей фамилией и ини - циалами) среди учащихся нет.
            //Класс задается целым числом, оценка — целое число в диапазоне 2–5.Название предмета 
            //указывается с заглавной буквы.Для каждого класса найти злостных двоечников — учащихся,
            //получивших в данном классе максимальное суммарное число двоек по всем предметам(число 
            //не должно быть нулевым). Вывести сведения о каждом из злостных двоечников: фамилию, 
            //инициалы, номер класса и полученное число двоек. Сведения о каждом двоечнике выводить 
            //на отдельной строке и располагать в алфавит-ном порядке их фамилий и инициалов
            //(сортировку по классам не проводить).Если в наборе исходных данных нет ни одной 
            //двойки, то записать в результирующий файл текст «Требуемые учащиеся не найдены».



        }
    }
}
