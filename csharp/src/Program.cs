using System.Drawing;
using System.Text;
using raytracing.DataStructures;
using raytracing.Extentions;
using raytracing.Raycast;
using HitFloatList = System.Collections.Generic.List<
raytracing.Raycast.HitTable<float>>;

namespace raytracing
{
    class Program
    {

        public static Vec3<float> color(Ray<float> r, HitFloatList world)
        {
            HitRecord<float> rec = default;
            if(world.Hit(r,0.0f,float.MaxValue, ref rec)) {
                //return (rec.Normal + 1.0f) * 0.5f;
                Vec3<float> target = rec.P + rec.Normal + SphereRandom();
                return color(new Ray<float>(rec.P, target - rec.P), world) * 0.5f;
            }

            Vec3<float> unitDirection = r.direction().unitVector();
            float t = 0.5f * unitDirection.y + 1.0f;
            return Vec3<float>.genVector(1.0f) * (1.0f - t) + Vec3<float>.genVector(0.5f, 0.7f, 1.0f) * t;
        }
        public static float nextFloat(float min, float max){
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        public static float randomFloat() {
            return nextFloat(0.0f,1.0f);
        }

        public static Vec3<float> SphereRandom() {
            Vec3<float> p;
            do {
                p = Vec3<float>.genVector(randomFloat(), randomFloat(), randomFloat()) * 2.0f -
                Vec3<float>.genVector(1);
            }while(Math.Pow(p.length(),2) > 1.0f);
            return p;
        }

        static float clamp(float x, float min, float max) {
            if (x < min) return min;
            if (x > max) return max;
            return x;
        }
        static void Main(string[] args)
        {
            const int nx = 200;
            const int ny = 100;
            const int samplesPerPixel = 100;

            StringBuilder output = new();
            output.AppendLine($"P3\n{nx} {ny}\n255\n");

            var hitTableWorld = new HitFloatList();
            hitTableWorld.Add(new Sphere(Vec3<float>.genVector(0.0f, 0.0f, -1.0f), 0.5f));
            hitTableWorld.Add(new Sphere(Vec3<float>.genVector(0.0f, -100.5f, -1.0f), 100.0f));

            var cam = Camera<float>.Init();

            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    var col = Vec3<float>.genVector(0.0f);
                    for (int s = 0; s < samplesPerPixel; ++s) {
                        float u = (float)i / (float)nx;
                        float v = (float)j / (float)ny;
                        Ray<float> r = cam.GetRay(u,v);
                        col += color(r, hitTableWorld);
                    }
                    col /= samplesPerPixel;
                    col = Vec3<float>.genVector((float)Math.Sqrt(col.r), (float)Math.Sqrt(col.g), (float)Math.Sqrt(col.b));
                    int ir = (int)(255.99 * clamp(col.r, 0.0f, 0.999f));
                    int ig = (int)(255.99 * clamp(col.g, 0.0f, 0.999f));
                    int ib = (int)(255.99 * clamp(col.b, 0.0f, 0.999f));
                    output.AppendLine($"{ir} {ig} {ib}\n");
                }
            }
            Console.Out.NewLine = "\n";
            Console.WriteLine(output.ToString());
        }
    }
}