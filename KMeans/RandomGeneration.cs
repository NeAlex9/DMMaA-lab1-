using System;
using System.Drawing;


namespace KMeans
{
    public class RandomGenerationService
    {
        private readonly int maxValueVector;
        private static readonly Random RandomGen = new Random();

        public RandomGenerationService(int maxVectorValue)
        {
            this.maxValueVector = maxVectorValue;
        }
        
        public void Generate(ref KMeansData data)
        {
            this.GenerateRandomForms(ref data);
            this.GenerateRandomCentres(ref data);
        }

        private void GenerateRandomForms(ref KMeansData data)
        {
            for (int i = 0; i < data.FormCount; i++)
            {
                data.Vectors[i].Point = new Point(RandomGen.Next(0, maxValueVector), RandomGen.Next(0, maxValueVector));
                data.Vectors[i].ClassIndex = 1;
            }
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