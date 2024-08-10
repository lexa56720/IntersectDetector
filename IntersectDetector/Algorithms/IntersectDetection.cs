using IntersectDetector.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IntersectDetector.Algorithms
{
    //Based on https://paulbourke.net/geometry/pointlineplane/
    //The shortest line between two lines in 3D algorithm
    public static class IntersectDetection
    {
        public static Vector3D? IsSegmentsIntersect(Segment3D a, Segment3D b)
        {
            (Vector3D resultA, Vector3D resultB)? result =
                GetMinimalLineBetweenSegments(a.Start, a.End, b.Start, b.End);

            if (result is not null && (result.Value.resultA - result.Value.resultB).LengthSquared < double.Epsilon)
                return result.Value.resultA;

            return null;
        }

        private static (Vector3D resultA, Vector3D resultB)? GetMinimalLineBetweenSegments(Vector3D p1,
                                                                   Vector3D p2, Vector3D p3, Vector3D p4)
        {
            var p43 = p4 - p3;
            if (p43.LengthSquared < double.Epsilon)
            {
                return null;
            }

            var p21 = p2 - p1;
            if (p21.LengthSquared < double.Epsilon)
            {
                return null;
            }
            var p13 = p1 - p3;

            double d1343 = p13.X * (double)p43.X + (double)p13.Y * p43.Y + (double)p13.Z * p43.Z;
            double d4321 = p43.X * (double)p21.X + (double)p43.Y * p21.Y + (double)p43.Z * p21.Z;
            double d1321 = p13.X * (double)p21.X + (double)p13.Y * p21.Y + (double)p13.Z * p21.Z;
            double d4343 = p43.X * (double)p43.X + (double)p43.Y * p43.Y + (double)p43.Z * p43.Z;
            double d2121 = p21.X * (double)p21.X + (double)p21.Y * p21.Y + (double)p21.Z * p21.Z;

            double denom = d2121 * d4343 - d4321 * d4321;
            if (Math.Abs(denom) < double.Epsilon)
            {
                return null;
            }
            double numer = d1343 * d4321 - d1321 * d4343;

            double mua = numer / denom;
            double mub = (d1343 + d4321 * (mua)) / d4343;

            var resultA = new Vector3D()
            {
                X = (p1.X + mua * p21.X),
                Y = (p1.Y + mua * p21.Y),
                Z = (p1.Z + mua * p21.Z),
            };

            var resultB = new Vector3D()
            {
                X = (float)(p3.X + mub * p43.X),
                Y = (float)(p3.Y + mub * p43.Y),
                Z = (float)(p3.Z + mub * p43.Z),
            };

            return (resultA, resultB);
        }

    }
}
