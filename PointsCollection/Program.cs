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
            Console.Write("Point multiply: 2 * ");
            p1.WriteState();
            p1 = p1 * 2;
            Console.Write("equal to:");
            p1.WriteState();
            Console.WriteLine();
            
            p1.WriteState();
            Console.Write("plus ");
            p2.WriteState();
            p1 = p1 + p2;
            Console.Write("equal to:");
            p1.WriteState();
            Console.WriteLine();

            p1.WriteState();
            Console.Write("minus ");
            p2.WriteState();
            p1 = p1 + p2;
            Console.Write("equal to:");
            p1.WriteState();
            Console.WriteLine();

            Console.Write("Is ");
            p1.WriteState();
            Console.Write("equal to ");
            p2.WriteState();
            Console.WriteLine(p1 == p2);

            Console.WriteLine();
            Console.Write("Is ");
            p.WriteState();
            Console.Write("equal to ");
            p2.WriteState();
            Console.WriteLine(p == p2);
            Console.WriteLine();
            
            Console.WriteLine("Collection functionality");
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine("Points Collection is sorted - {0}",points.Sorted);
            Console.WriteLine();
            points.WriteState();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            points.Sort();
            Console.WriteLine();
            Console.WriteLine("Points Collection is sorted - {0}", points.Sorted);
            Console.WriteLine();
            points.WriteState();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            points.Remove(p);
            points.Remove(p1);
            points.WriteState();

            Console.WriteLine();
            Console.WriteLine("These points were removed from Collection:");
            p.WriteState();
            p1.WriteState();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
