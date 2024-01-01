using BenchmarkDotNet.Running;
using parallel_processing_mandelbrot_cs.mandelbrot;

namespace parallel_processing_mandelbrot_cs
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!!!");
            int a = 10;
            int b = 20;
            Console.WriteLine($"{a} + {b} = {Math.Add(a, b)}");
            Console.WriteLine($"{a} - {b} = {Math.Sub(a, b)}");

            BenchmarkRunner.Run<Mandelbrot>();
        }
    }
}
