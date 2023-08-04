using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pileBush = MaxPileNd(new PileBush(-103.37, 8.12, -3.62, 4), new PileBush(-83.85, 12.24, -2.39, 4));

            foreach (var pile in pileBush.piles)
            {
                Console.WriteLine(pile.NdEq);
                Console.WriteLine(pile);
                Console.WriteLine(pile.GetS(new Soil(
                    ));
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
