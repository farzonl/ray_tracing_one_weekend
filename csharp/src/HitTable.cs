using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raytracing
{
    namespace DataStructures
    {
        public abstract class HitTable<T> where T : INumber<T>
        {
            public abstract bool Hit(Ray<T> r, float tMin, float tMax, ref HitRecord rec);
        }
    }
}
