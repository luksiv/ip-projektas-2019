using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApp1.DataFormating;

namespace WindowsFormsApp1.kNN
{
    class KNearestNeighbor
    {
        int k = 3;
        List<Glass> trainingData = new List<Glass>();

        public KNearestNeighbor(int k, List<Glass> trainingData)
        {
            this.k = k;
            this.trainingData = trainingData;
        }

        public int classify(Glass unknown)
        {
            // calculate distances to all points in the trainingData
            var distances = new List<Tuple<Glass, double>>();
            foreach (Glass item in trainingData)
            {
                var distance = calculateDistance(unknown.GetMainValues(), item.GetMainValues());
                distances.Add(Tuple.Create(item, distance));
            }
            // sort
            distances.OrderBy(x => x.Item2);
            // get k nearest glasses from trainingData
            var kNearest = distances.GetRange(0, k);
            // determine what class unknown is nearest to
            var classesNearest = kNearest.Select(x => x.Item1.group_type);
            var map = new Dictionary<int, int>();
            foreach (int c in classesNearest)
            {
                if (map.Keys.Contains(c))
                {
                    map[c] = map[c] + 1;
                }
                else
                {
                    map.Add(c, 1);
                }
                
            }
            int max = map.Max(x => x.Value);
            return max;
        }

        private double calculateDistance(List<double> a, List<double> b)
        {
            var unio = a.Zip(b, (x1,x2) => Tuple.Create(x1, x2));
            return Math.Sqrt(unio.Sum(t => Math.Pow(t.Item2 - t.Item1, 2)));
        }
    }
}
