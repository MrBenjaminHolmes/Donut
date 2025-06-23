//Spinning Donut!
using System;
class Program
{
    static void Main()
    {
        int width = 20;
        int height =20;
        char[,] canvas = new char[height, width];

        //Clear Canvas Before Frame
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
                if(x == y)
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
    }
}