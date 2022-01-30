using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace KMeans
{
    public class RandomGenerationService
    {
        private const int MaxValueVector = 1000;
        private static readonly Random RandomGen = new Random();

        public void Generate(ref KMeansData data)
        {
            data.Vectors
                .ToList()
                .ForEach(elem =>
                    elem.Point = new Point(RandomGen.Next(0, MaxValueVector), RandomGen.Next(0, MaxValueVector)));
            GenerateRandomCentres(ref data);
        }

        private void GenerateRandomCentres(ref KMeansData data)
        {
            for (int i = 0; i < data.Centers.Length; i++)
            {
                var elementsIndex = RandomGen.Next(0, data.FormCount);
                data.Vectors[elementsIndex].ClassIndex = i;
                data.Centers[i] = data.Vectors[elementsIndex];
            }
        }
    }
}