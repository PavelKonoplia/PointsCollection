using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(-2, -1);
            Point p1 = new Point(-3, 5);
            Point p2 = new Point(-2, -1);
            Point p3 = new Point(2, -1);
            Point p4 = new Point(5, -2);
            Point p5 = new Point(-5, 3);
            Point p6 = new Point(-1, 2);
            Point p7 = new Point(2, 2);
            Point p8 = new Point(1, -1);
            Point p9 = new Point(1, -1);

            PointsCollection points = new PointsCollection();
            points.Add(p);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            points.Add(p6);
            points.Add(p7);
            points.Add(p8);
            points.Add(p9);
            
            Console.WriteLine("Point functionality:");
            Console.WriteLine("********************");
            Console.WriteLine();

            Console.WriteLine("2 * ({0}) = ({1})",p1, p1 * 2);
            Console.WriteLine();
            
            Console.WriteLine("({0}) + ({1}) = ({2}) ",p1, p2, p1 + p2);
            Console.WriteLine();;

            Console.WriteLine("({0}) - ({1}) =({2}) ", p1, p2, p1 + p2);
            Console.WriteLine();

            Console.WriteLine("Is {0} == {1} => {2} ", p1, p2, p1 == p2);
            Console.WriteLine();

            Console.WriteLine("Is {0} == {1} => {2} ", p, p2, p == p2);
            Console.WriteLine();
            
            Console.WriteLine("Collection functionality");
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine("Points Collection is sorted - {0}",points.Sorted);
            Console.WriteLine();
            Console.WriteLine(points.ToString()); 
            Console.WriteLine("--------------------------------------");
            points.Sort();
            Console.WriteLine();
            Console.WriteLine("Points Collection is sorted - {0}", points.Sorted);
            Console.WriteLine();
            Console.WriteLine(points.ToString());

            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            points.Remove(p);
            points.Remove(p1);
            Console.WriteLine(points.ToString());
            Console.WriteLine("These points were removed from Collection:");
            Console.WriteLine();
            Console.WriteLine(p.ToString());
            Console.WriteLine(p1.ToString());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
