using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectDetector.Types
{
    public struct Segment3D
    {
        public required Vector3D Start { get; init; }

        public required Vector3D End { get; init; }

        public override string ToString()
        {
            return $"({Start}) - ({End})";
        }
    }
}
