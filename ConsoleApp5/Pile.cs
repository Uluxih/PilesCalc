using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class Pile
    {
        public double Y;
        public double Z;
        public double Nd;
        public string NdEq;
        public int num;
        public Pile(double Y, double Z)
        {
            this.Y = Y; this.Z = Z;
        }
        public Pile(double X, double Y, double N, double My, double Mx, int n, double sumX, double sumY)
        {
            this.Y = X; this.Z = Y;
            this.Nd = GetNd(N, Mx, My, n, sumX, sumY);
        }
        public double GetNd(double N, double My, double Mz, int n, double sumY, double sumZ)
        {
            double Nd;
            if (sumY == 0) sumY = 1;
            if (sumZ == 0) sumZ = 1;
            Nd = N / n + My * Z / sumZ + Mz * Y / sumY;
            this.Nd = Nd;
            string res;
            res = "Nd= " + N + "/" + n + " + " + My + " * " + Z + " / " + sumZ + " + " + Mz + " * " + Y + " / " + sumY;
            NdEq = res;
            return Nd;
        }

        public override string ToString() { return num+" Y: " + Y + " Z: " + Z + " Nd: " + Nd; }
    }
}