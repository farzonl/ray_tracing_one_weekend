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
                return (rec.Normal + 1.0f) * 0.5f;
            }

            Vec3<float> unitDirection = r.direction().unitVector();
            float t = 0.5f * unitDirection.y + 1.0f;
            return Vec3<float>.genVector(1.0f) * (1.0f - t) + Vec3<float>.genVector(0.5f, 0.7f, 1.0f) * t;
        }

        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;
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
                    float u = (float)i / (float)nx;
                    float v = (float)j / (float)ny;
                    Ray<float> r = cam.GetRay(u,v);
                    
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