using System.Drawing;
using System.Text;
using raytracing.DataStructures;
using raytracing.Extentions;
using HitFloatList = System.Collections.Generic.List<
raytracing.DataStructures.HitTable<float>>;

namespace raytracing
{
    class Program
    {

        public static Vec3<float> color(Ray<float> r, HitFloatList world)
        {
            HitRecord<float> rec = default;
            if(world.Hit(r,0.0f,float.MaxValue, ref rec)) {
                return (rec.Normal + 1.0f) * 0.5f;
            }

            /*float t = hitSphere(Vec3<float>.genVector(0, 0, -1), .5f, r);
            
            if(t > 0.0) {
                var N = (r.point_at_parameter(t) - Vec3<float>.genVector(0, 0, -1)).unitVector();
                return Vec3<float>.genVector(N.x + 1, N.y + 1, N.z + 1) * 0.5f;
            }*/

            Vec3<float> unitDirection = r.direction().unitVector();
            float t = 0.5f * unitDirection.y + 1.0f;
            return Vec3<float>.genVector(1.0f) * (1.0f - t) + Vec3<float>.genVector(0.5f, 0.7f, 1.0f) * t;
        }

        /*public static float hitSphere(Vec3<float> center, float radius, Ray<float> r)
        {
            Vec3<float> oc = r.origin() - center;
            float a = r.direction().dot();
            float b = 2.0f * r.direction().dot(oc);
            float c = oc.dot() - (float)Math.Pow(radius, 2);
            float discriminant = (float)Math.Pow(b, 2) - 4 * a * c;
            if(discriminant < 0 ){
                return -1.0f;
            }

            return (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
        }*/

        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;
            StringBuilder output = new();
            output.AppendLine($"P3\n{nx} {ny}\n255\n");
            Vec3<float> lowerLeftCorner = Vec3<float>.genVector(-2.0f, -1.0f, -1.0f);
            Vec3<float> horizontal = Vec3<float>.genVector(4.0f, 0.0f, 0.0f);
            Vec3<float> vertical = Vec3<float>.genVector(0.0f, 2.0f, 0.0f);
            Vec3<float> origin = Vec3<float>.genVector(0.0f, 0.0f, 0.0f);
            var hitTableWorld = new HitFloatList();
            
            hitTableWorld.Add(new Sphere(Vec3<float>.genVector(0.0f, 0.0f, -1.0f), 0.5f));
            hitTableWorld.Add(new Sphere(Vec3<float>.genVector(0.0f, -100.5f, -1.0f), 100.0f));

            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    float u = (float)i / (float)nx;
                    float v = (float)j / (float)ny;
                    Ray<float> r = new Ray<float>(origin, lowerLeftCorner + horizontal * u + vertical * v);
                    
                    Vec3<float> col = color(r, hitTableWorld);
                    int ir = (int)(255.99 * col.r);
                    int ig = (int)(255.99 * col.g);
                    int ib = (int)(255.99 * col.b);
                    output.AppendLine($"{ir} {ig} {ib}\n");
                }
            }
            Console.Out.NewLine = "\n";
            Console.WriteLine(output.ToString());
        }
    }
}