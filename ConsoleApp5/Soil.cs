using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class Soil
    {
        public Soil (double E, double Nu)
        {
            this.Nu = Nu; this.E = E;
        }
        public double G
        {
            get
            { return E / (2 * (1 + Nu)); }
        }
        //коэффициент Пуассона
        public double Nu;
        public double E;

    }
}
