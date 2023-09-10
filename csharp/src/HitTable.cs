using System;
using System.Numerics;
using raytracing.DataStructures;


namespace raytracing.Raycast
{
    public abstract class HitTable<T> where T : INumber<T>
    {
        public abstract bool Hit(Ray<T> r, T tMin, T tMax, ref HitRecord<T> rec);
    }
}
