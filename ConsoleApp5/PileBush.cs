using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class PileBush
    {
        public List<Pile> piles = new List<Pile>();
        double Mx;
        double My;
        double N;
        //count piles
        int n;
        double sumX;
        double sumY;
        public PileBush(double N, double My, double Mx,  int n)
        {
            this.Mx = Mx;
            this.My = My;
            this.N = N;
            switch(n)
            {
                case 1:
                    piles.Add(new Pile(0, 0));

                    sumX = 1;sumY = 1; break;
                case 2:
                    piles.Add(new Pile(-0.45, 0));
                    piles.Add(new Pile(0.45, 0));

                    sumX = Math.Pow(0.45, 2) * 2;
                    sumY = Math.Pow(0.45, 2) * 2;
                    break;
                case 3:
                    piles.Add(new Pile(-0.3, -0.45));
                    piles.Add(new Pile(-0.3, 0.45));
                    piles.Add(new Pile(0.6, 0));

                    sumX = Math.Pow(0.6, 2) * 2 + Math.Pow(1.2, 2);
                    sumY = Math.Pow(0.9, 2) * 2 + 0;
                    break;
                case 4:
                    piles.Add(new Pile(0.45, 0.45));
                    piles.Add(new Pile(-0.45, 0.45));
                    piles.Add(new Pile(-0.45, -0.45));
                    piles.Add(new Pile(0.45, -0.45));

                    sumX = Math.Pow(0.45, 2) * 4;
                    sumY = Math.Pow(0.45, 2) * 4;
                    break;
                case 5:
                    piles.Add(new Pile(0.65, 0.65));
                    piles.Add(new Pile(-0.65, 0.65));
                    piles.Add(new Pile(-0.65, -0.65));
                    piles.Add(new Pile(0.65, -0.65));
                    piles.Add(new Pile(0, 0));

                    sumX = Math.Pow(0.65, 2) * 4 + 0;
                    sumY = Math.Pow(0.65, 2) * 4 + 0;
                    break;
            }
            foreach(Pile pile in piles)
            {
                pile.GetNd(N, Mx, My, n, sumX, sumY);
            }

        }
    }
}
