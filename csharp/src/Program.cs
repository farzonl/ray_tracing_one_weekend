using System.Text;
namespace raytracing {
class Program {
    static void Main(string[] args) {
        int nx = 200;
        int ny = 100;
        StringBuilder output = new();
       output.AppendLine($"P3\n{nx} {ny}\n255\n");
        for(int j = ny-1; j >= 0; j--) {
            for(int i = 0; i < nx; i++) {
                float r = i/((float)nx);
                float g = j/((float)ny);
                float b = 0.2f;
                int ir = (int)(255.99*r);
                int ig = (int)(255.99*g);
                int ib = (int)(255.99*b);
                output.AppendLine($"{ir} {ig} {ib}\n");
            }
        }
        Console.WriteLine(output.ToString());
    }
    }
}