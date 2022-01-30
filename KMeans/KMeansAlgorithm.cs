using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class KMeansAlgorithm
    {
        private readonly string Directory = "..\\..\\Iterations";
        public readonly int ClassCount;
        public readonly int FormCount;
        private const int TotalAttempts = 40;
        private const int bitmapSize = 1000;

        public KMeansAlgorithm(int classCount, int formCount)
        {
            this.ClassCount = classCount;
            this.FormCount = formCount;
        }

        public void AssignAlgorithm()
        {
            var painter = new Painter();
            var randomizer = new RandomGenerationService(bitmapSize);
            var data = new KMeansData(this.ClassCount, this.FormCount);
            randomizer.Generate(ref data);
            var actualData = data.Clone();
            var attempt = 1;
            do
            {
                data = actualData.Clone();
                this.CalculateArea(ref actualData);
                this.CalculateCenter(ref actualData);
                var image = painter.MakeImage(actualData, bitmapSize);
                var path = Path.Combine(this.Directory, attempt.ToString() + ".bmp");
                image.Save(path, ImageFormat.Bmp);
                attempt++;
            } while (TotalAttempts >= attempt && !data.Equals(actualData));
        }

        private void CalculateArea(ref KMeansData actualData)
        {
            for (int i = 0; i < actualData.Vectors.Length; i++)
            {
                double minDistance = bitmapSize * bitmapSize;
                var classIndex = actualData.Vectors[i].ClassIndex;
                foreach (var center in actualData.Centers)
                {
                    var dist = GetDistance(actualData.Vectors[i].Point, center.Point);
                    if (minDistance > dist)
                    {
                        minDistance = dist;
                        classIndex = center.ClassIndex;
                    }
                }

                actualData.Vectors[i].ClassIndex = classIndex;
            }
        }

        private void CalculateCenter(ref KMeansData actualData)
        {
            for (int i = 0; i < actualData.Centers.Length; i++)
            {
                var sumX = 0;
                var sumY = 0;
                var count = 0;
                for (int j = 0; j < actualData.Vectors.Length; j++)
                {
                    if (actualData.Vectors[j].ClassIndex == i)
                    {
                        sumX += actualData.Vectors[j].Point.X;
                        sumY += actualData.Vectors[j].Point.Y;
                        count++;
                    }
                }

                actualData.Centers[i].Point.X = sumX / count;
                actualData.Centers[i].Point.Y = sumY / count;
            }
        }

        private static double GetDistance(Point a, Point b) =>
            Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}