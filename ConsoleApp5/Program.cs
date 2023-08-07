using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pileBush = MaxPileNd(new PileBush(-103.37/100.0, 8.12 /100.0, -3.62 / 100.0, 2), 
                new PileBush(-83.85 / 100, 12.24 / 100, -2.39 / 100, 2));

            //SoilLayer soil1 = new SoilLayer(26.48, 0.35, 1.19);
            //SoilLayer soil2 = new SoilLayer(20.0, 0.3, 1.5);
            //SoilLayer soil3 = new SoilLayer(26.48, 0.35, 3.31);
            //SoilLayer soil4 = new SoilLayer(2.48, 0.35, 3.31);
            //soil2.bottonLayer = soil3;
            //soil1.bottonLayer = soil2;
            //Pile pile = new Pile(0, 0, 6);
            //pile.d = 0.35; pile.E = 30000; pile.Nd = 1;
            //Console.WriteLine(pile.GetS(soil1.GetAverageBottomChar(pile.l), soil1));

            Soil soilChar1 = new Soil (10.8,0.35);
            Soil soilChar2 = new Soil (6.1, 0.35);
            Soil soilChar3 = new Soil (9, 35);
            Soil soilChar4 = new Soil (26, 0.42);
            Soil soilChar5 = new Soil (30.4, 0.35);

            SoilLayer soilLayer1 = new SoilLayer(soilChar1, 1.258);
            SoilLayer soilLayer2 = new SoilLayer(soilChar2, 4.19, soilLayer1);
            SoilLayer soilLayer3 = new SoilLayer(soilChar3, 0.71, soilLayer2);
            SoilLayer soilLayer4 = new SoilLayer(soilChar5, 0.51, soilLayer3);
            SoilLayer soilLayer5 = new SoilLayer(soilChar4, 15, soilLayer4);
            soilLayer1.bottonLayer = soilLayer2;
            soilLayer1.H = 146.93;

            soilLayer5.BindLayer();
            soilLayer1.SetHLayer(146.93);

            foreach (var pile in pileBush.piles)
            {
                pile.H = 148.2;
                pile.l = 10.85;
                pile.soil1 = soilLayer1.GetAverageBottomChar(pile.l).soil;
                pile.soil2 = pile.GetFootLayer(soilLayer1).soil;
                //Console.WriteLine(pile.NdEq);
                Console.Write(pile);
                Console.WriteLine(" Si= "+pile.GetS(soilLayer1));
            }
            for (int i=0; i<pileBush.piles.Count;i++)
            {
                Console.WriteLine();
                for (int j = 0; j < pileBush.piles.Count; j++)
                {
                    pileBush.delta[i, j] = pileBush.piles[i].GetDelta(pileBush.piles[j]);
                    Console.Write(pileBush.delta[i,j]+"\t");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < pileBush.piles.Count; i++)
            {
                pileBush.Sfull[i] = pileBush.piles[i].GetS();
                for (int j = 0; j < pileBush.piles.Count; j++)
                {
                    pileBush.piles[i].fullS += pileBush.delta[i, j] * pileBush.piles[j].GetS();
                    pileBush.Sfull[i] += pileBush.delta[i, j] * pileBush.piles[j].GetS();
                }
            }
            Console.WriteLine();
            foreach (var s in pileBush.Sfull)
            {
                Console.WriteLine(s + "\t");
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