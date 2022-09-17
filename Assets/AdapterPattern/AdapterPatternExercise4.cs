using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace NPS
{
    public class AdapterPatternExercise4 : MonoBehaviour
    {
        private List<VectorObject> vectorObjects = new List<VectorObject>
        {
          new VectorRectangle(1, 1, 10, 10),
          new VectorRectangle(3, 3, 6, 6)
        };

        private void Start()
        {
            Draw();
        }

        private void Draw()
        {
            foreach (VectorObject vo in vectorObjects)
            {
                foreach (Line line in vo)
                {
                    var adapter = new LineToPointAdapter(line);

                    string str = "";
                    foreach (Point point in adapter)
                    {
                        str += ".";
                    }

                    Debug.Log(str);
                }
            }
        }

        public class Point
        {
            public int X;
            public int Y;

            public Point(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }

        public class Line
        {
            public Point Start;
            public Point End;

            public Line(Point Start, Point End)
            {
                this.Start = Start;
                this.End = End;
            }
        }

        public class VectorObject : Collection<Line>
        {

        }

        public class VectorRectangle : VectorObject
        {
            public VectorRectangle(int x, int y, int width, int height)
            {
                Add(new Line(new Point(x, y), new Point(x + width, y)));
                Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
                Add(new Line(new Point(x, y), new Point(x, y + height)));
                Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
            }
        }

        public class LineToPointAdapter : IEnumerable<Point>
        {
            private static int count = 0;
            private static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();

            public LineToPointAdapter(Line line)
            {
                var hash = line.GetHashCode();
                if (cache.ContainsKey(hash)) return;

                Debug.Log($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}] (no caching)");

                int left = Math.Min(line.Start.X, line.End.X);
                int right = Math.Max(line.Start.X, line.End.X);
                int top = Math.Min(line.Start.Y, line.End.Y);
                int bottom = Math.Max(line.Start.Y, line.End.Y);

                int dx = right - left;
                int dy = top - bottom;

                List<Point> points = new List<Point>();

                if (dx == 0)
                {
                    for (int y = top; y <= bottom; ++y)
                    {
                        points.Add(new Point(left, y));
                    }
                }
                else if (dy == 0)
                {
                    for (int x = left; x <= right; ++x)
                    {
                        points.Add(new Point(x, top));
                    }
                }

                cache.Add(hash, points);
            }

            public IEnumerator<Point> GetEnumerator()
            {
                return cache.Values.SelectMany(x => x).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}