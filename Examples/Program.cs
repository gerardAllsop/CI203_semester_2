using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Examples
{
    class Program
    {    
        static void Main(string[] args)
        {
            string[] cars = { "BMW", "Ford",
                "Mercedes", "Jaguar",
                "Audi", "Fiat" };
            int[] engineSize = { 1000, 2000, 2500, 3000, 35000 };
            ArrayList drivers = new ArrayList();
            drivers.Add(new RacingDriver("Lewis", 5));
            drivers.Add(new RacingDriver("Nigel", 1));
            drivers.Add(new RacingDriver("Damon", 1));
            //simpleQCars(cars);
            //vowelQuery(cars);
            //List<int> temp = intArrayQ(engineSize);
            //temp.ForEach(e => WriteLine(e.ToString()));
            arrayListQ(drivers);
            ReadKey();
        }

        static void arrayListQ(ArrayList drivers)
        {
            var driversEnum = drivers.OfType<RacingDriver>();
            var champions = from d in driversEnum
                          where d.Wins > 0
                          orderby d.Wins descending
                          select d;
            foreach(var champion in champions)
            {
                WriteLine($"{champion.Name} has won {champion.Wins} time[s]");
            }
        }

        public class RacingDriver
        {
            public String Name { get; set; }
            public int Wins { get; set; }
            public RacingDriver(String n,int w) { Name = n;Wins = w; }
        }

        static List<int> intArrayQ(int[] engineSize)
        {
            var sports = from es in engineSize
                         where es > 1800
                         orderby es
                         select es;
            WriteLine($"Type is: {sports.GetType()}");
            var esList = sports.ToList<int>();
            return esList;
        }

        static void vowelQuery(string[] cars)
        {
            var carVowel = from car in cars
                           where car.Contains("a")
                           orderby car descending
                           select car; 
            foreach(var c in carVowel)
            {
                WriteLine(c);
            }
        }

        static void simpleQCars(string[] cars)
        {

            var list = from c in cars
                       select c;
            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.Append($"{s}\n");
            }
            Console.WriteLine(sb.ToString(), "Cars");
            Console.ReadLine();
        }
    }
}
