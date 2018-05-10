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
            points.Sort(new PointsComparer());
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
                if (p.GetHashCode() == p1.GetHashCode())
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

        public void WriteState()
        {
            foreach (Point p in points)
            {
                p.WriteState();
            }
        }

        public IEnumerator<Point> GetEnumerator()
        {
            //return new PointsEnumerator(this);
            for (int i = 0; i < points.Count; i++)
            {
                yield return points[i];
            }
        }
        /*
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PointsEnumerator(this);
        }    
        */

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < points.Count; i++)
            {
                yield return points[i];
            }
        }


    }

    public class PointsEnumerator : IEnumerator<Point>
    {
        private PointsCollection _collection;
        private int curIndex;
        private Point curPoint;

        public PointsEnumerator(PointsCollection collection)
        {
            _collection = collection;
            curIndex = -1;
            curPoint = default(Point);
        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // Set current point to next item in collection.
                curPoint = _collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public Point Current
        {
            get { return curPoint; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }

    public class PointsComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            if (p1.DistanceToCenter() > p2.DistanceToCenter())
                return 1;
            else if (p1.DistanceToCenter() < p2.DistanceToCenter())
                return -1;
            else
                return 0;
        }
    }
}
