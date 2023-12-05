namespace PileCalc1_2
{
    public class SoilLayer
    {
        public SoilLayer(double E, double Nu, double l)
        {
            this.soil = new Soil(E, Nu);
            this.soil.E = E; this.soil.Nu = Nu; this.l = l;
        }
        public SoilLayer(Soil soil, double l)
        {
            this.soil = soil;
            this.l = l;
        }
        public SoilLayer(Soil soil, double l, SoilLayer topLayer)
        {
            this.topLayer = topLayer;
            this.soil = soil;
            this.l = l;
        }
        public SoilLayer bottonLayer;
        public SoilLayer topLayer;
        //модуль сдвига
        public Soil soil;

        /// <summary>
        /// Мощность слоя
        /// </summary>
        public double l;

        /// <summary>
        /// Абсолютная отметка подошвы слоя
        /// </summary>
        public double H;
        public SoilLayer GetAverageBottomChar(double l)
        {
            SoilLayer soilLayer = this;
            double averageL=0;
            //double averageGL=0;
            double averageEL=0;
            double averageNuL=0;
            
            while(soilLayer != null && averageL<=l)
            {
                averageL += soilLayer.l;
                //averageGL += this.l * this.G;
                averageEL += soilLayer.l * soilLayer.soil.E;
                averageNuL += soilLayer.l * soilLayer.soil.Nu;
                soilLayer = soilLayer.bottonLayer;
            }
            return new SoilLayer(averageEL / averageL, averageNuL / averageL, averageL);
        }
        /// <summary>
        /// Метод пересчитает абсолютные отметки нижележащих слоев
        /// </summary>
        /// <param name="H"> Глубина подошвы первого слоя </param>
        public void SetHLayer(double H)
        {
            this.H = H;
            SoilLayer soilLayer = this;
            while(soilLayer.bottonLayer != null)
            {
                soilLayer.bottonLayer.H = soilLayer.H - soilLayer.bottonLayer.l;
                soilLayer = soilLayer.bottonLayer;
            }
        }
        public void BindLayer()
        {
            SoilLayer soilLayer = this;
            while (soilLayer.topLayer != null)
            {
                soilLayer.topLayer.bottonLayer = soilLayer;
                soilLayer = soilLayer.topLayer;
            }
        }
        //public SoilLayer GetSoilInDeep(double l)
        //{

        //}
    }
}
