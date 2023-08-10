using Aspose.Cells;

using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {

        static void Main(string[] args)
        {
            Soil soilChar1 = new Soil(12.499, 0.25);
            Soil soilChar2 = new Soil(37.5, 0.25);


            SoilLayer soilLayer1 = new SoilLayer(soilChar1, 18);
            SoilLayer soilLayer2 = new SoilLayer(soilChar2, 18, soilLayer1);

            soilLayer1.bottonLayer = soilLayer2; soilLayer2.topLayer = soilLayer1;
            soilLayer1.H = -18;
            PileBush pb = new PileBush(9);
            pb.piles = new List<Pile> { new Pile(2.4,-2.4), new Pile(0, -2.4), new Pile(-2.4, -2.4),
            new Pile(2.4,0), new Pile(0, 0), new Pile(-2.4, 0),
            new Pile(2.4,2.4), new Pile(0, 2.4), new Pile(-2.4, 2.4) };
            foreach(Pile i in pb.piles)
            {
                i.d = 0.5316; i.soil1 = soilLayer1.soil;
                i.soil2 = soilChar2;
                i.l = 18; i.Nd = 2;
            }
            pb.SetDelta();
            foreach (Pile i in pb.piles)
            {
                Console.WriteLine(i.GetS());
            }
            Console.WriteLine();
            for(int i=0; i<9;i++)
            {
                pb.piles[i].fullS += pb.piles[i].GetS();
                for(int j=0;j<9;j++)
                {
                    double a = pb.piles[i].GetSad(pb.piles[j]);
                    var b = pb.piles[i].GetDelta(pb.piles[j]);
                    var c = pb.piles[i].GetS();
                    pb.piles[i].fullS += pb.piles[i].GetSad(pb.piles[j]);
                }
            }
            Console.WriteLine();
        }
    }
}