//Spinning Donut!
using System;
using System.Threading;
class Program
{
    static void Main()
    {
        int width = 10;
        int height =10;
        char[,] canvas = new char[height, width];
        Console.CursorVisible = false;
        Random rnd = new Random();
        while (true)
        {
            int rndInt = rnd.Next(1, 7);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    canvas[y, x] = ' ';
                }
            }
            
            //Line Render
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x ==rndInt)
                    {
                        canvas[y, x] = '.';
                    }
                }
            }

            //Canvas render
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(canvas[y, x]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
            Thread.Sleep(50);
        }
    }
}