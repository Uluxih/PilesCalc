using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class Pile
    {
        public int num;
        public double Y;
        public double Z;
        //длина сваи
        public double l;
        //нагрузка
        public double Nd;
        public string NdEq;
        //осадка
        public double s;
        public double E;
        public double d;
        public Pile(double Y, double Z)
        {
            this.Y = Y; this.Z = Z;
        }
        public Pile(double Y, double Z, double l)
        {
            this.Y = Y; this.Z = Z; this.l = l;
        }
        public Pile(double X, double Y, double N, double My, double Mx, int n, double sumX, double sumY)
        {
            this.Y = X; this.Z = Y;
            this.Nd = GetNd(N, Mx, My, n, sumX, sumY);
        }
        public override string ToString() { return num + " Y: " + Y + " Z: " + Z + " Nd: " + Nd; }
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
        public double GetS(SoilLayer soil1, SoilLayer soil2)
        {
            double kNu = 2.82 - 3.78 * (soil1.Nu + soil2.Nu) / 2 + 2.18 * (soil1.Nu + soil2.Nu);
            double kNu1 = 2.82 - 3.78 * (soil1.Nu) / 2 + 2.18 * (soil1.Nu);
            double chi = E * d * d / (soil1.G * l * l);
            double lambda1 = (2.12 * Math.Pow(chi, 0.75) / (1 + 2.12 * Math.Pow(chi, 0.75)));
            double alpha1 = 0.17 * (Math.Log(kNu1 * l / d));
            double betta1 = 0.17 * Math.Log((kNu * soil1.G * l) / (soil2.G * d));
            double betta = betta1 / lambda1 + (1 - (betta1 / alpha1)) / chi;
            double Si = betta * Nd / (soil1.G * l);
            return Si;
        }
    }
}