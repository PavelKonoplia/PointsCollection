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
        private List<Point> _points;

        public PointsCollection()
        {
            _points = new List<Point>();
        }

        private bool _sorted = false;

        public bool Sorted { get { return _sorted; } }

        public Point this[int X, int Y]
        {
            get
            {
                try
                {
                    int i = 0;
                    while (true)
                    {
                        if (_points[i].Equals(new Point(X, Y)))
                        {
                            return _points[i];
                        }
                        i++;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Wrong index!");
                    throw null;
                }
            }
            set
            {
                try
                {
                    int i = 0;
                    while (true)
                    {
                        if (_points[i].Equals(new Point(X, Y)))
                        {
                            _points[i] = value;
                            break;
                        }
                        i++;
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Wrong index!");
                }
            }
        }

        public int Count
        {
            get { return _points.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Sort()
        {
            _points.Sort();
            _sorted = true;
        }

        public void Add(Point p)
        {
            if (!_points.Contains(p))
            {
                _points.Add(p);
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

            for (int i = 0; i < _points.Count; i++)
            {
                array[i + arrayIndex] = _points[i];
            }
        }

        public bool Remove(Point p)
        {
            return _points.Remove(p);
        }

        public bool Contains(Point p1)
        {
            foreach (Point p in _points)
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
            _points.Clear();
        }

        public override string ToString()
        {
            string s = "";
            foreach (Point p in _points)
            {
                s += p.ToString() + "\n";
            }
            return s;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                yield return _points[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
