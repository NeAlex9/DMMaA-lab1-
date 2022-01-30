using System.Drawing;
using KMeans;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kMeansAlgo = new KMeansAlgorithm(6, 30000);
            kMeansAlgo.AssignAlgorithm();
        }
    }
}