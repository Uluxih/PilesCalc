
using Aspose.Cells;
using System;
using System.Collections.Generic;

namespace PileCalc1_2
{ 
    class Program
    {

        static void Main(string[] args)
        {

            var pileBushes = new List<PileBush>();
            Soil soilChar1 = new Soil(10.8, 0.35);
            Soil soilChar2 = new Soil(6.1, 0.35);
            Soil soilChar3 = new Soil(9, 0.35);
            Soil soilChar4 = new Soil(26, 0.42);
            Soil soilChar5 = new Soil(30.4, 0.35);

            SoilLayer soilLayer1 = new SoilLayer(soilChar1, 1.258);
            SoilLayer soilLayer2 = new SoilLayer(soilChar2, 4.19, soilLayer1);
            SoilLayer soilLayer3 = new SoilLayer(soilChar3, 0.71, soilLayer2);
            SoilLayer soilLayer4 = new SoilLayer(soilChar5, 0.51, soilLayer3);
            SoilLayer soilLayer5 = new SoilLayer(soilChar4, 15, soilLayer4);
            soilLayer1.bottonLayer = soilLayer2;
            soilLayer1.H = 146.93;

            soilLayer5.BindLayer();
            soilLayer1.SetHLayer(146.93);

            Workbook wb = new Workbook("excel.xlsx");
            WorksheetCollection collection = wb.Worksheets;
            Worksheet worksheet = collection[0];
            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;
            for (int i = 1; i < rows; i++)
            {
                var pileBush = MaxPileNd(new PileBush(
                    Convert.ToDouble(worksheet.Cells[i, 1].Value) / 100.0,
                    Convert.ToDouble(worksheet.Cells[i, 2].Value) / 100.0,
                    Convert.ToDouble(worksheet.Cells[i, 3].Value) / 100.0,
                    Convert.ToInt32(worksheet.Cells[i, 10].Value)),
                new PileBush(
                     Convert.ToDouble(worksheet.Cells[i, 4].Value) / 100.0,
                    Convert.ToDouble(worksheet.Cells[i, 5].Value) / 100.0,
                    Convert.ToDouble(worksheet.Cells[i, 6].Value) / 100.0,
                    Convert.ToInt32(worksheet.Cells[i, 10].Value)));

                foreach (var pile in pileBush.piles)
                {
                    pile.H = 148.2;
                    pile.l = 10.85;
                    pile.soil1 = soilLayer1.GetAverageBottomChar(pile.l).soil;
                    pile.soil2 = pile.GetFootLayer(soilLayer1).soil;
                    //Console.WriteLine(pile.NdEq);
                    //Console.Write(pile);
                    //Console.WriteLine(" Si= " + pile.GetS(soilLayer1));
                }
                for (int j = 0; j < pileBush.piles.Count; j++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < pileBush.piles.Count; k++)
                    {
                        pileBush.delta[j, k] = pileBush.piles[j].GetDelta(pileBush.piles[k]);
                        Console.Write(pileBush.delta[j, k] + "\t");
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < pileBush.piles.Count; j++)
                {
                    pileBush.piles[j].fullS= pileBush.piles[j].GetS();
                    pileBush.Sfull[j] = pileBush.piles[j].GetS();
                    for (int k = 0; k < pileBush.piles.Count; k++)
                    {
                        pileBush.piles[j].fullS += pileBush.delta[j, k] * pileBush.piles[k].GetS();
                        pileBush.Sfull[j] += pileBush.delta[j, k] * pileBush.piles[k].GetS();
                    }
                }
                Console.WriteLine();
                foreach (var s in pileBush.piles)
                {
                    Console.WriteLine(s);
                }
                pileBushes.Add(pileBush);
                // Распечатать разрыв строки
                  Console.WriteLine(" "+i);
            }
        }
        public static PileBush MaxPileNd(PileBush pileBush1, PileBush pileBush2)
        {
            PileBush pileBushRes = new PileBush(pileBush1.n);
            for (int i=0; i<pileBush1.n; i++)
            {
                if (Math.Abs(pileBush1.piles[i].Nd) < Math.Abs(pileBush2.piles[i].Nd))
                {
                    pileBushRes.piles.Add(pileBush2.piles[i]);
                }
                else
                {
                    pileBushRes.piles.Add(pileBush1.piles[i]);
                }
            }
            return pileBushRes;
        }
    }
}