using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211018_3
{
    class Program
    {
        static List<Chinchilla> csincsillak = new List<Chinchilla>();
        static void Main()
        {
            using (var sr = new StreamReader(@"..\..\res\chi.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream) csincsillak.Add(new Chinchilla(sr.ReadLine()));
            }
            Console.WriteLine($"2. feladat:\nÖsszesen {csincsillak.Count} csincsilla van.\n");
            var szereti = csincsillak.Count(x => x.Simi);
            Console.WriteLine(
                "3. feladat:\nA csincsillák {0:0.00}%-a szereti, ha símogatják.\n",
                (float)szereti / csincsillak.Count * 100);
            var oscs = csincsillak
                .Where(x => x.Kor > 8 && x.Suly < 360)
                .FirstOrDefault();
            Console.WriteLine($"4. feladat:\n" +
                $"{(oscs is null ? "nincs ilyen csincsilla" : $"{oscs.Nev} {Math.Floor(oscs.Kor)} éves és {oscs.Suly} gramm")}\n");

            Console.WriteLine("5.feladat:");
            var rend = csincsillak.OrderByDescending(x => x.Suly).ToList();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0,-12} {1} g", rend[i].Nev, rend[i].Suly);
            }

            Console.WriteLine("\n6.feladat:");
            csincsillak
                .GroupBy(x => x.Szul.Year)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()}"));

            Console.ReadKey(true);
        }
    }
}
