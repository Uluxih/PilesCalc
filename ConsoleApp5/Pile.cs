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

        /// <summary>
        /// Длина сваи
        /// </summary>
        public double l;

        /// <summary>
        /// Абсолютная отметка верха сваи
        /// </summary>
        public double H;
        //нагрузка, МН
        public double Nd;
        public string NdEq;
        //осадка, м
        public double fullS;
        //Мпа
        public double E=30000;
        public double d=0.3;
        public double A
        {
            get
            { return d * d; }
        }
        /// <summary>
        /// Грунт у боковой поверхности
        /// </summary>
        /// 
        public Soil soil1;

        /// <summary>
        /// Грунт у подошвы сваи
        /// </summary>
        public Soil soil2;

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
            double kNu = 2.82 - 3.78 * (soil1.soil.Nu + soil2.soil.Nu) / 2 
                + 2.18 * Math.Pow((soil1.soil.Nu + soil2.soil.Nu)/2,2);
            double kNu1 = 2.82 - 3.78 * (soil1.soil.Nu) + 2.18 * Math.Pow(soil1.soil.Nu,2);
            double dExexute = Math.Pow(4 * A / Math.PI, 0.5);
            double chi = E * A / (soil1.soil.G * l * l);
            double lambda1 = (2.12 * Math.Pow(chi, 0.75) / (1 + 2.12 * Math.Pow(chi, 0.75)));
            double alpha1 = 0.17 * (Math.Log(kNu1 * l / dExexute));
            double betta1 = 0.17 * Math.Log((kNu * soil1.soil.G * l) / (soil2.soil.G * dExexute));
            double betta = betta1 / lambda1 + (1 - (betta1 / alpha1)) / chi;
            double Si = betta * Nd / (soil1.soil.G * l);
            return Si;
        }
        public double GetS(SoilLayer soil)
        {
            SoilLayer footSoilLayer = this.GetFootLayer(soil);
            return this.GetS(soil.GetAverageBottomChar(l), footSoilLayer);
        }
        public double GetS()
        {
            SoilLayer footSoilLayer = new SoilLayer(this.soil2, 0);
            SoilLayer bodySoilLayer = new SoilLayer(this.soil1, this.l);
            return this.GetS(bodySoilLayer, footSoilLayer);
        }
        public double GetSad(Pile pile)
        {
            return this.GetDelta(pile) * pile.GetS();
        }
        public double GetDelta(Pile pile2)
        {
            double kNu = 2.82 - 3.78 * (soil1.Nu + soil2.Nu) / 2
               + 2.18 * Math.Pow((soil1.Nu + soil2.Nu) / 2, 2);
            double a = Math.Pow(Math.Pow(pile2.Y - this.Y, 2) + Math.Pow(pile2.Z - this.Z, 2), 0.5);
            if (a == 0)
                return 0;
            double multiplies = kNu * this.soil1.G * this.l / (2 * this.soil2.G * a);
            if (multiplies>1)
            {
                return 0.17 * Math.Log(multiplies);
            }

            else 
                return 0;
        }
        public void SetSoil(Soil soil1, Soil soil2)
        {
            this.soil1 = soil1; this.soil2 = soil2;
        }
        public SoilLayer GetFootLayer(SoilLayer soilLayer)
        {
            while (soilLayer.H < this.H - this.l)
            {
                if (soilLayer.bottonLayer != null)
                { 
                    soilLayer = soilLayer.bottonLayer; 
                }
                else
                { break; }
            }
            soil2 = soilLayer.soil;
            return soilLayer;
        }
    }
}