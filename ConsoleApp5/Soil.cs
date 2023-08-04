using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class Soil
    {
        public Soil(double G, double Nu)
        {
            this.G = G; this.Nu = Nu;
        }
        //модуль сдвига
        public double G;
        //коэффициент Пуассона
        public double Nu;
    }
}
