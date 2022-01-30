using System.Drawing;
using KMeans;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGeneration = new RandomGenerationService();
            var kMeansAlgo = new KMeansAlgorithm(6, 1000);
            kMeansAlgo.AssignAlgorithm();
        }
    }
}