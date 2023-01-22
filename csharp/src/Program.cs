﻿using System.Drawing;
using System.Text;
using raytracing.DataStructures;

namespace raytracing {
class Program {

    public static Vec3<float> color(Ray<float> r) {
        Vec3<float> unitDirection = r.direction().unitVector();
        float t = 0.5f * unitDirection.y + 1.0f;
        return Vec3<float>.genVector(1.0f) * (1.0f - t) + Vec3<float>.genVector(0.5f, 0.7f, 1.0f) * t;
    }
    static void Main(string[] args) {
        int nx = 200;
        int ny = 100;
        StringBuilder output = new();
        output.AppendLine($"P3\n{nx} {ny}\n255\n");
        Vec3<float> lowerLeftCorner = Vec3<float>.genVector(-2.0f, -1.0f, -1.0f);
        Vec3<float> horizontal = Vec3<float>.genVector(4.0f, 0.0f, 0.0f);
        Vec3<float> vertical = Vec3<float>.genVector(0.0f, 2.0f, 0.0f);
        Vec3<float> origin = Vec3<float>.genVector(0.0f, 0.0f, 0.0f);

        for (int j = ny-1; j >= 0; j--) {
            for(int i = 0; i < nx; i++) {
                float u = (float)i / (float) nx;
                float v = (float)j / (float) ny;
                Ray<float> r = new Ray<float>(origin, lowerLeftCorner + horizontal * u + vertical * v);
                Vec3<float> col = color(r);
                int ir = (int)(255.99*col.r);
                int ig = (int)(255.99*col.g);
                int ib = (int)(255.99*col.b);
                output.AppendLine($"{ir} {ig} {ib}\n");
            }
        }
        Console.WriteLine(output.ToString());
    }
    }
}