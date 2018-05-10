using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCollection
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class Point : IComparable<Point>
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        public int X { get; set; }
        public int Y { get; set; }

        public double AbsoluteValue { get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)); } }

        public int Z
        {
            get
            {
                if (X >= 0)
                {
                    return Y >= 0 ? 1 : 4;
                }
                return Y >= 0 ? 2 : 3; ;
            }
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(Point p)
        {
            if (AbsoluteValue > p.AbsoluteValue)
                return 1;
            else if (AbsoluteValue < p.AbsoluteValue)
                return -1;
            else
                return 0;
        }

        public bool Equals(Point p)
        {
            if ((Math.Abs(p.X) == Math.Abs(X)) && (Math.Abs(p.Y) == Math.Abs(Y)) && (p.Z == Z))
            {
                return true;
            }
            return false;
        }

        public override string ToString ()
        {
            return $"X={X}, Y={Y}, Z={Z}";
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public static Point operator *(Point p, int a)
        {
            return new Point(p.X*a, p.Y*a);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
    }
}
