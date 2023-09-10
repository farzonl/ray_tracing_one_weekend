using System;
using System.Numerics;
using raytracing.DataStructures;

namespace raytracing.Raycast
{
    public class Camera<T> where T : INumber<T> {
        public Vec3<T> Origin { get; private set; }
        public Vec3<T> Horizontal { get; private set; }
        public Vec3<T> Vertical { get; private set; }
        public Vec3<T> LowerLeftCorner { get; private set; }

        public Camera(Vec3<T> origin, Vec3<T> horizontal, Vec3<T> vertical, 
        Vec3<T> lowerLeftCorner) {
            Origin = origin;
            Horizontal = horizontal;
            Vertical = vertical;
            LowerLeftCorner = lowerLeftCorner;
        }

        public static Camera<float> Init() {
            var origin = Vec3<float>.genVector(0.0f, 0.0f, 0.0f);
            var horizontal = Vec3<float>.genVector(4.0f, 0.0f, 0.0f);
            var vertical = Vec3<float>.genVector(0.0f, 2.0f, 0.0f);
            var lowerLeftCorner = Vec3<float>.genVector(-2.0f, -1.0f, -1.0f);

            return new Camera<float>(origin,horizontal,vertical,lowerLeftCorner);
        }

        public Ray<T> GetRay(T u, T v) {
            return new Ray<T>(Origin, LowerLeftCorner + Horizontal * u + Vertical * v - Origin);
        }
    }
}