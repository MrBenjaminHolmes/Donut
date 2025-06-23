using System;
using System.Threading;

class Program
{
    static void Main()
    {
         Random randInt = new Random();
        int width = 40;
        int height = 20;

        int cx = width / 2;
        int cy = height / 2;
        

        char[,] canvas = new char[height, width];
        Console.CursorVisible = false;

        while (true)
        {
            int radius = randInt.Next(1, 7);
            // Clear canvas
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    canvas[y, x] = ' ';

            // Draw circle
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double dx = (x - cx) / 2.0;
                    double dy = y - cy;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    if (Math.Abs(distance - radius) < 0.5)
                        canvas[y, x] = '.';
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
