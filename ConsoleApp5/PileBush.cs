using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class PileBush
    {
        public List<Pile> piles = new List<Pile>();
        Soil soil;
        double My;
        double Mz;
        double N;
        //count piles
        public int n;
        public double sumY;
        public double sumZ;
        double[,] delta;
        
        public PileBush(int n)
        {
            this.n = n;
        }

        public PileBush(double N, double My, double Mz,  int n)
        {
            this.My = My;
            this.Mz = Mz;
            this.N = N;
            this.n = n;
            switch(n)
            {
                case 1:
                    piles.Add(new Pile(0, 0));

                    break;
                case 2:
                    piles.Add(new Pile(0, -0.45));
                    piles.Add(new Pile(0, 0.45));

                    break;
                case 3:
                    piles.Add(new Pile(0.45, - 0.3));
                    piles.Add(new Pile(-0.45, -0.3));
                    piles.Add(new Pile(0, 0.6));

                    break;
                case 4:
                    piles.Add(new Pile(0.45, -0.45));
                    piles.Add(new Pile(-0.45, -0.45));
                    piles.Add(new Pile(0.45, 0.45));
                    piles.Add(new Pile(-0.45, 0.45));

                    break;
                case 5:
                    piles.Add(new Pile(0.65, -0.65));
                    piles.Add(new Pile(-0.65, -0.65));
                    piles.Add(new Pile(0, 0));
                    piles.Add(new Pile(0.65, 0.65));
                    piles.Add(new Pile(-0.65, 0.65));

                    break;
                case 6:
                    piles.Add(new Pile(0.9, -0.45));
                    piles.Add(new Pile(0, -0.45));
                    piles.Add(new Pile(-0.9, -0.45));
                    piles.Add(new Pile(0.9, 0.45));
                    piles.Add(new Pile(0, 0.45));
                    piles.Add(new Pile(-0.9, 0.45));

                    break;
            }
            foreach (Pile pile in piles)
            {
                sumY += Math.Pow(pile.Y, 2);
                sumZ += Math.Pow(pile.Z, 2);

            }
            foreach (Pile pile in piles)
            {
                pile.GetNd(N, My, Mz, n, sumY, sumZ);
            }
            for (int i=1;i<=piles.Count;i++)
            {
                piles[i-1].num = i;
            }

        }
    }
}
