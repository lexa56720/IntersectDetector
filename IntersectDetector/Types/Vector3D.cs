using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectDetector.Types
{
    public class Vector3D
    {
        public required double X { get => this[0]; init => this[0] = value; }

        public required double Y { get => this[1]; init => this[1] = value; }

        public required double Z { get => this[2]; init => this[2] = value; }

        public double Length => Math.Sqrt(LengthSquared);
        public double LengthSquared => Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);

        public static Vector3D Empty => new(0, 0, 0);

        private readonly double[] values = new double[3];

        [SetsRequiredMembers]
        public Vector3D(double x, double y, double z)
        {
            this[0] = x;
            this[1] = y;
            this[2] = z;
        }

        [SetsRequiredMembers]
        public Vector3D(Vector3D matrix)
        {
            values = (double[])matrix.values.Clone();
        }
        public Vector3D()
        {
        }

        public double this[int i]
        {
            get => values[i];
            set => values[i] = value;
        }


        public static Vector3D operator -(Vector3D vector)
        {
            var result = new Vector3D(vector);
            for (int i = 0; i < 3; i++)
                result[i] = -result[i];
            return result;
        }

        public static Vector3D operator +(Vector3D vector)
        {
            var result = new Vector3D(vector);
            return result;
        }

        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            var result = new Vector3D(a);

            for (int i = 0; i < 3; i++)
                result[i] -= b[i];
            return result;
        }

        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            var result = new Vector3D(a);

            for (int i = 0; i < 3; i++)
                result[i] += b[i];
            return result;
        }

        public static bool operator ==(Vector3D a, Vector3D b)
        {
            for (int i = 0; i < 3; i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }
        public static bool operator !=(Vector3D a, Vector3D b)
        {
            for (int i = 0; i < 3; i++)
                if (a[i] != b[i])
                    return true;

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Vector3D other)
                return false;

            for (int i = 0; i < 3; i++)
            {
                if (!values[i].Equals(other[i]))
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;

            for (int i = 0; i < 3; i++)
            {
                hash = hash * 31 + values[i].GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            return $"x:{X}; y:{Y}; z:{Z}";
        }
    }
}
