using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCollection
{
    public class Point : EqualityComparer<Point>, IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

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
            if (DistanceToCenter() > p.DistanceToCenter())
                return 1;
            else if (DistanceToCenter() < p.DistanceToCenter())
                return -1;
            else
                return 0;
        }

        public double DistanceToCenter()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public void WriteState()
        {
            Console.WriteLine("Point state X={0}, Y={1}, Z={2}", X, Y, Z);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if ((Math.Abs(p1.X) == Math.Abs(p2.X)) && (Math.Abs(p1.Y) == Math.Abs(p2.Y)) && (p1.Z == p2.Z))
            {
                return true;
            }
            return false;
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

        public static bool operator !=(Point p1, Point p2)
        {
            if ((Math.Abs(p1.X) != Math.Abs(p2.X)) || (Math.Abs(p1.Y) != Math.Abs(p2.Y)) || (p1.Z != p2.Z))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(Point p1, Point p2)
        {
            if ((Math.Abs(p1.X) == Math.Abs(p2.X)) && (Math.Abs(p1.Y) == Math.Abs(p2.Y)) && (p1.Z == p2.Z))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode(Point p)
        {
            int hCode = p.X ^ p.Y ^ p.Z;
            return hCode.GetHashCode();
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        public override bool Equals(object o)
        {
            Point p = o as Point;
            if ((Math.Abs(p.X) == Math.Abs(X)) && (Math.Abs(p.Y) == Math.Abs(Y)) && (p.Z == Z))
            {
                return true;
            }
            return false;
        }
    }
}
