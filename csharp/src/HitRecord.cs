﻿using System;
using System.Numerics;
using raytracing.DataStructures;

namespace raytracing.Raycast
{
    public struct HitRecord<V> where V : INumber<V>
    {
        public V T { get; set; }
        public Vec3<V> P { get; set; }
        public Vec3<V> Normal { get; set; }
    }
}
