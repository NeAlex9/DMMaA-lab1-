using System.Drawing;
using KMeans;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var kMeansAlgo = new KMeansAlgorithm(2, 30000);
            kMeansAlgo.AssignAlgorithm();
        }
    }
}