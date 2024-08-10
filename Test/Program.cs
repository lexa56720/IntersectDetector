using IntersectDetector.Algorithms;
using IntersectDetector.Types;
using System.ComponentModel;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Intersect();
            Console.ReadLine();
        }

        private static void Intersect()
        {
            var a = new Segment3D()
            {
                Start = GetVector(1, 1),
                End = GetVector(2, 1),
            };
            Console.WriteLine();
            var b = new Segment3D()
            {
                Start = GetVector(1, 2),
                End = GetVector(1, 2)
            };
            var intersectPoint = IntersectDetection.IsSegmentsIntersect(a, b);

            if (intersectPoint is null)
            {
                Console.WriteLine($"Отрезки {a} и {b} не пересекаются");
            }
            else
            {
                Console.WriteLine($"Отрезки {a} и {b} пересекаются в точке {intersectPoint}");
            }
        }

        private static Vector3D GetVector(int point, int segment)
        {
            Console.WriteLine($"Введите координату X точки {point} отрезка {segment}");
            var x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Введите координату Y точки {point} отрезка {segment}");
            var y = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Введите координату Z точки {point} отрезка {segment}");
            var z = Convert.ToDouble(Console.ReadLine());

            return new Vector3D(x, y, z);
        }
    }
}
