using System;
using System.Collections.Generic;
using System.Diagnostics;
using Tool2.Databeheer;
using Tool2.Klas;

namespace Tool2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            Databeheerder d = new Databeheerder();
            List<Gemeente> GemeenteLijst = d.getGemeentes(); //duurt <0 seconden
            List<Provincie> provincieLijst = d.getProvincies(); //duurt < 0 seconden




            stopWatch.Stop();
            long duration = stopWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nRunTime " + duration + " Elapsed seconds");

            Console.ReadLine(); 
        }
    }
}
