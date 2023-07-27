using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class Pile
    {
        double X;
        double Y;
        double Nd;
        public Pile(double X, double Y)
        {
            this.X = X; this.Y = Y;
        }
        public Pile(double X, double Y, double N, double My, double Mx, int n, double sumX, double sumY)
        {
            this.X = X; this.Y = Y;
            this.Nd = GetNd(N, Mx, My, n, sumX, sumY);
        }
        public double GetNd(double N, double Mx, double My, int n, double sumX, double sumY)
        {
            double Nd;
            Nd = N / n + Mx * Y / sumY + My * X / sumX;
            this.Nd = Nd;
            return Nd;
        }
        public override string ToString() { return "X: " + X + " Y: " + " Rd: " + Nd; }
    }
}