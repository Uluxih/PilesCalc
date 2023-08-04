namespace ConsoleApp5
{
    public class SoilLayer
    {
        public SoilLayer(double E, double Nu, double l)
        {
            this.E = E; this.Nu = Nu; this.l = l;
        }
        public SoilLayer bottonLayer;
        public SoilLayer topLayer;
        //модуль сдвига
        public double G
        { 
            get
            { return E / (2 * (1 + Nu)); }
        }
        //коэффициент Пуассона
        public double Nu;
        public double E;
        public double l;

        public SoilLayer GetAverageBottomChar()
        {
            SoilLayer soilLayer = this;
            double averageL=0;
            //double averageGL=0;
            double averageEL=0;
            double averageNuL=0;
           
            while(soilLayer != null)
            {
                averageL += soilLayer.l;
                //averageGL += this.l * this.G;
                averageEL += soilLayer.l * soilLayer.E;
                averageNuL += soilLayer.l * soilLayer.Nu;
                soilLayer = soilLayer.bottonLayer;
            }
            return new SoilLayer(averageEL / averageL, averageNuL / averageL, averageL);
        }
        //public SoilLayer GetSoilInDeep(double l)
        //{

        //}
    }
}
