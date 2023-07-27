using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pileBush = new PileBush(-87.44, -6.62, 0.06, 2);
            // var pileBush = new PileBush(-40.08, -4.48, -0.78, 2);
            foreach (var pile in pileBush.piles)
            {
                Console.WriteLine(pile);
            }
        }
    }
}
