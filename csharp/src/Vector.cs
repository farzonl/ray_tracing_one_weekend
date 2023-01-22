using System.Numerics;

namespace raytracing
{
    namespace DataStructures
    {
        public class Vec3<T> where T : INumber<T>
        {

            List<T> arr = new List<T>(3);
            public T x
            {
                get => arr[0];
                set => arr[0] = value;
            }
            public T y
            {
                get => arr[1];
                set => arr[1] = value;
            }
            public T z
            {
                get => arr[2];
                set => arr[2] = value;
            }

            public T r
            {
                get => arr[0];
                set => arr[0] = value;
            }
            public T g
            {
                get => arr[1];
                set => arr[1] = value;
            }
            public T b
            {
                get => arr[2];
                set => arr[2] = value;
            }

            public T this[int i]
            {
                get
                {
                    if (i > 2 || i < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i), "index for three items cannot be greater than two.");
                    }
                    return arr[i];
                }
                set
                {
                    if (i > 2 || i < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i), "index for three items cannot be greater than two.");
                    }
                    arr[i] = value;
                }
            }

            public Vec3(T x, T y, T z)
            {
                this.arr = Enumerable.Repeat(default(T), 3).Where(t => t != null).Cast<T>().ToList();
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Vec3(T a) : this(a,a,a)
            {
               
            }

            public static Vec3<T> genVector(T x, T y, T z)
            {
                return new Vec3<T>(x, y, z);
            }

            public static Vec3<T> genVector(T a)
            {
                return new Vec3<T>(a);
            }

            public Vec3<T> unitVector()
            {
                return this / this.length();
            }

            public static Vec3<T> Zero() { return new Vec3<T>(T.Zero, T.Zero, T.Zero); }

            public static double Pow(T n, double p) => Math.Pow((double)(object)n, p);

            public T length() => (T)(object)Math.Sqrt(Pow(x, 2) + Pow(y, 2) + Pow(z, 2));

            public static Vec3<T> operator -(Vec3<T> a) => new Vec3<T>(-a.x, -a.y, -a.z);

            public static Vec3<T> operator +(Vec3<T> a, Vec3<T> b)
                => new Vec3<T>(a.x + b.x, +a.y + b.y, a.z + b.z);

            public static Vec3<T> operator -(Vec3<T> a, Vec3<T> b)
                => a + (-b);

            public static Vec3<T> operator *(Vec3<T> a, Vec3<T> b) =>
            new Vec3<T>(a.x * b.x, a.y * b.y, a.z * b.z);

            public static Vec3<T> operator /(Vec3<T> a, Vec3<T> b) =>
            new Vec3<T>(a.x / b.x, a.y / b.y, a.z / b.z);

            public static Vec3<T> operator *(Vec3<T> a, T n) => new Vec3<T>(a.x * n, a.y * n, a.z * n);

            public static Vec3<T> operator /(Vec3<T> a, T n) => new Vec3<T>(a.x / n, a.y / n, a.z / n);
        }
    }
}