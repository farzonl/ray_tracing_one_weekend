using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raytracing
{
    namespace DataStructures
    {
        public struct HitRecord
        {
            public float T { get; set; }
            public Vec3<float> P { get; set; }
            public Vec3<float> Normal { get; set; }
        }
    }
}
