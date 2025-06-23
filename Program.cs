using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int width = 80;
        int height = 40;


        double K1 = 2.0;
        double r1 = 10;
        double r2 = 5;

        double thetaSpacing = 0.07;
        double phiSpacing = 0.02;

        char[,] canvas = new char[height, width];
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            // Clear canvas
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    canvas[y, x] = ' ';

            for(double theta = 0; theta < 2 * Math.PI; theta+= thetaSpacing)
            {
                for(double phi = 0; phi < 2 * Math.PI; phi += phiSpacing)
                {
                    double x = (r1 + r2 * Math.Cos(theta)) * Math.Cos(phi);
                    double y = (r1 + r2 * Math.Cos(theta)) * Math.Sin(phi);
                    double z = r2 * Math.Sin(theta);

                    int x_proj = (int)((width / 2) + K1 * x);
                    int y_proj = (int)((height / 2) - K1 * y);

                    if (x_proj >= 0 && x_proj < width && y_proj >= 0 && y_proj < height)
                    {
                        canvas[y_proj, x_proj] = '.';
                    }

                }
            }
            

            // Render to console
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Console.Write(canvas[y, x]);
                Console.WriteLine();
            }

            Thread.Sleep(100);
        }
    }
}
