using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCollection
{
    public class PointsCollection : ICollection<Point>
    {
        List<Point> points;

        public PointsCollection()
        {
            points = new List<Point>();
        }

        private bool _sorted = false;

        public bool Sorted { get { return _sorted; } }

        public Point this[int index]
        {
            get
            {
                return points[index];
            }
            set
            {
                points[index] = value;
            }
        }

        public int Count
        {
            get { return points.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Sort()
        {
            points.Sort();
            _sorted = true;
        }

        public void Add(Point p)
        {
            if (!points.Contains(p))
            {
                points.Add(p);
            }
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < points.Count; i++)
            {
                array[i + arrayIndex] = points[i];
            }
        }

        public bool Remove(Point p)
        {
            return points.Remove(p);
        }

        public bool Contains(Point p1)
        {
            foreach (Point p in points)
            {
                // Equality defined by the Point
                if (p.Equals(p1))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            points.Clear();
        }

        public override string ToString()
        {
            string s = "";
            foreach (Point p in points)
            {
                s+= p.ToString() + "\n";
            }
            return s;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            for (int i = 0; i < points.Count; i++)
            {
                yield return points[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
