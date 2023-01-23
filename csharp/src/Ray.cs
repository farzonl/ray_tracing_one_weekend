using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace raytracing
{
    namespace DataStructures
    {
        public class Ray<T> where T : INumber<T>
        {
            public Vec3<T> A { get; private set; }
            public Vec3<T> B { get; private set; }

            public Ray() {
                A = Vec3 < T >.Zero();
                B = Vec3 < T >.Zero();
            }

            public Ray(Vec3<T> a, Vec3<T> b)
            {
                A = a;
                B = b;
            }

            public Vec3<T> origin() { return A; } 
            public Vec3<T> direction() { return B; }
            public Vec3<T> point_at_parameter(T t) { return A + (B  *  t); } 
        }
    }
}
