using System;
using System.Text;
using System.Threading;

namespace Donut
{
    class Program
    {
        static void Main()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            double K1 = 2.0;
            double r1 = 8;
            double r2 = 4;
            string brightnessMap = ".,-~:;=!*#$@";

            double thetaSpacing = 0.07;
            double phiSpacing = 0.02;
            double A = 0;
            double B = 0;

            char[,] canvas = new char[height, width];
            Console.CursorVisible = false;

            while (true)
            {
                double cosA = Math.Cos(A);
                double sinA = Math.Sin(A);
                double cosB = Math.Cos(B);
                double sinB = Math.Sin(B);

                // Clear canvas
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                        canvas[y, x] = ' ';

                for (double theta = 0; theta < 2 * Math.PI; theta += thetaSpacing)
                {
                    for (double phi = 0; phi < 2 * Math.PI; phi += phiSpacing)
                    {
                        // Torus Calculation
                        double x = (r1 + r2 * Math.Cos(theta)) * Math.Cos(phi);
                        double y = (r1 + r2 * Math.Cos(theta)) * Math.Sin(phi);
                        double z = r2 * Math.Sin(theta);

                        // X Rotation
                        double y1 = y * cosA - z * sinA;
                        double z1 = y * sinA + z * cosA;
                        double x1 = x;

                        // Y Rotation
                        double x2 = x1 * cosB + z1 * sinB;
                        double z2 = -x1 * sinB + z1 * cosB;
                        double y2 = y1;

                        int x_proj = (int)((width / 2) + K1 * x2);
                        int y_proj = (int)((height / 2) - K1 * y2 * 0.5);

                        if (x_proj >= 0 && x_proj < width && y_proj >= 0 && y_proj < height)
                        {
                            canvas[y_proj, x_proj] = '.';
                        }
                    }
                }

                Console.SetCursorPosition(0, 0);

                // Render to console
                StringBuilder sb = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                        sb.Append(canvas[y, x]);

                    if (y < height - 1)
                        sb.Append('\n');
                }
                Console.Write(sb.ToString());

                Thread.Sleep(100);

                A += 0.5;
                B += 0.5;
            }
        }
    }
}
