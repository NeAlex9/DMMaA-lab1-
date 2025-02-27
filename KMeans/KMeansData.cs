﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace KMeans
{
    public struct KMeansData : IEquatable<KMeansData>
    {
        public readonly int ClassCount;
        public readonly int FormCount;

        public KMeansData(int classCount, int formCount)
        {
            this.ClassCount = classCount;
            this.FormCount = formCount;
            this.Vectors = new (Point, int)[this.FormCount];
            this.Centers = new (Point point, int classIndex)[this.ClassCount];
        }

        public (Point Point, int ClassIndex)[] Vectors { get; private set; }
        public (Point Point, int ClassIndex)[] Centers { get; private set; }

        public KMeansData Clone()
        {
            var vectors = new (Point, int)[this.FormCount];
            var centers = new (Point point, int classIndex)[this.ClassCount];
            Array.Copy(this.Vectors, vectors, this.FormCount);
            Array.Copy(this.Centers, centers, this.ClassCount);
            return new KMeansData(this.ClassCount, this.FormCount) {Vectors = vectors, Centers = centers};
        }

        public bool Equals(KMeansData other) =>
            this.FormCount == other.FormCount
            && this.ClassCount == other.ClassCount
            && other.Centers.SequenceEqual(this.Centers, new EqualityComparer());

        private class EqualityComparer : IEqualityComparer<(Point Point, int ClassIndex)>
        {
            public bool Equals((Point Point, int ClassIndex) x, (Point Point, int ClassIndex) y) =>
                x.Point.X == y.Point.X && x.Point.Y == y.Point.Y && x.ClassIndex == y.ClassIndex;

            public int GetHashCode((Point Point, int ClassIndex) obj) =>
                obj.ClassIndex;
        }
    }
}