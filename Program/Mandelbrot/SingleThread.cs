using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace parallel_processing_mandelbrot_cs.mandelbrot
{
    public partial class Mandelbrot
    {
        [Benchmark]
        public void SingleThread()
        {
            // 変数の定義。
            var width = 1024;
            var height = 1024;

            var x_min = -2.5;
            var x_max = 1.5;
            var y_min = -2.0;
            var y_max = 2.0;

            var max_iter = 256;
            var threshold = 50;

            // 画像の生成。
            var image = new Image<Rgba32>(width, height);

            // ピクセルの計算。
            for (var y = 0; y < height; y++)
            {
                var c_im = y_min + (y_max - y_min) * y / height;

                for (var x = 0; x < width; x++)
                {
                    var c_re = x_min + (x_max - x_min) * x / width;

                    var z_re = c_re;
                    var z_im = c_im;

                    var is_inside = true;
                    var iter = 0;

                    while (iter < max_iter)
                    {
                        var z_re2 = z_re * z_re;
                        var z_im2 = z_im * z_im;

                        if (z_re2 + z_im2 > threshold * threshold)
                        {
                            is_inside = false;
                            break;
                        }

                        z_im = 2.0 * z_re * z_im + c_im;
                        z_re = z_re2 - z_im2 + c_re;

                        iter++;
                    }

                    if (is_inside)
                    {
                        image[x, y] = new Rgba32(0, 0, 0);
                    }
                    else
                    {
                        var color = iter * 16 % 256;
                        image[x, y] = new Rgba32(color, color, color);
                    }
                }
            }

            // 画像の保存。
            image.Save("mandelbrot_singlethread.png");
        }
    }
}
