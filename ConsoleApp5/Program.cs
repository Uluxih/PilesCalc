using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pileBush = MaxPileNd(new PileBush(-103.37/100.0, 8.12 /100.0, -3.62 / 100.0, 4), 
                new PileBush(-83.85 / 100, 12.24 / 100, -2.39 / 100, 4));

            SoilLayer soil1 = new SoilLayer(100, 0.3, 10);
            SoilLayer soil2 = new SoilLayer(1, 0.3, 10);
            //soil1.bottonLayer = soil2;
            foreach (var pile in pileBush.piles)
            {
                pile.l = 10;
                pile.d = 0.3;
                pile.E = 30000;
                Console.WriteLine(pile.NdEq);
                Console.WriteLine(pile);
                Console.WriteLine(pile.GetS(soil1.GetAverageBottomChar(),
                    soil2.GetAverageBottomChar())) ;
            }
        }
        public static PileBush MaxPileNd(PileBush pileBush1, PileBush pileBush2)
        {
            PileBush pileBushRes = new PileBush(pileBush1.n);
            for (int i=0; i<pileBush1.n; i++)
            {
                if (Math.Abs( pileBush1.piles[i].Nd) < Math.Abs(pileBush2.piles[i].Nd))
                {
                    pileBushRes.piles.Add(pileBush2.piles[i]);
                }
                else
                {
                    pileBushRes.piles.Add(pileBush1.piles[i]);
                }
            }
            return pileBushRes;
        }
    }
}