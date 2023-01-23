namespace raytracing
{
    namespace DataStructures
    {
        public class Sphere : HitTable<float>
        {
            public Vec3<float> Center { get; private set; }
            public float Radius { get; private set; }
            public Sphere() { }

            public Sphere(Vec3<float> c, float r) {
                Center = c;
                Radius = r;
            }

            private bool isMinMaxBounded(float temp, float tMin, float tMax) => temp < tMax && temp > tMin;
            private float getSqrt(float a, float b, float c) => (float)Math.Sqrt(Math.Pow(b, 2) - a * c);
            private float computePlus(float a, float b, float c) =>  (-b + getSqrt(a, b, c)) / a;
            private float computeMinus(float a, float b, float c) => (-b - getSqrt(a, b, c)) / a;


            public override bool Hit(Ray<float> r, float tMin, float tMax, ref HitRecord rec)
            {
                Vec3<float> oc = r.origin() - Center;
                float a = r.direction().dot();
                float b = r.direction().dot(oc);
                float c = oc.dot() - (float)Math.Pow(Radius, 2);
                float discriminant = (float)Math.Pow(b, 2) - 4 * a * c;

                var setHitRecord = (Func<float, float, float, float> compute, ref HitRecord rec) =>
                {
                    float temp = compute(a, b, c);
                    if (isMinMaxBounded(temp, tMin, tMax))
                    {
                        rec.T = temp;
                        rec.P = r.point_at_parameter(rec.T);
                        rec.Normal = (rec.P - Center) / Radius;
                        return true;
                    }
                    return false;
                };

                if (discriminant > 0)
                {
                    return setHitRecord(computePlus, ref rec) || setHitRecord(computeMinus, ref rec);

                }
                return false;
            }
        }
    }
}
