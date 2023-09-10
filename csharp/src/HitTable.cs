using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raytracing.DataStructures
{
    public abstract class HitTable<T> where T : INumber<T>
    {
        public abstract bool Hit(Ray<T> r, T tMin, T tMax, ref HitRecord<T> rec);
    }
}
