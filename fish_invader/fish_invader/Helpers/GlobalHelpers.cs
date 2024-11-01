using Efundies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    internal static class GlobalHelpers
    {
        public static Random alea = new Random();

    }


    class metode
    {

        public static string RandomName()
        {
            string line;
            int i = 0;

            StreamReader sr = new StreamReader("images/first-names.txt");
            string[] Names = new string[4946];

            line = sr.ReadLine();


            while (line != null)
            {
                Names[i++] = line;

                //Read the next line
                line = sr.ReadLine();
            }

            Random rnd = new Random();

            string randomName = Names[rnd.Next(4946)];

            return randomName;
        }


        public static void SwapColor(Bitmap bmp, Color oldColor, Color newColor)
        {

            var lockedBitmap = new LockBitmap(bmp);
            lockedBitmap.LockBits();

            try
            {
                for (int y = 0; y < lockedBitmap.Height; y++)
                {
                    for (int x = 0; x < lockedBitmap.Width; x++)
                    {
                        if (lockedBitmap.GetPixel(x, y) == oldColor)
                        {
                            lockedBitmap.SetPixel(x, y, newColor);
                        }
                    }
                }
            }
            finally
            {
                lockedBitmap.UnlockBits(); // Ensure unlock even if an exception occurs
            }
        }




        // function for rounding off the pixels 
        public static int Round(float n)
        {
            if (n - (int)n < 0.5)
                return (int)n;
            return (int)(n + 1);
        }

        // Function for line generation 
        public static int[,] DDALine(int x0, int y0, int x1,int y1)
        {
            // Calculate dx and dy 
            int dx = x1 - x0;
            int dy = y1 - y0;

            int step;

            // If dx > dy we will take step as dx 
            // else we will take step as dy to draw the complete 
            // line 
            if (Math.Abs(dx) > Math.Abs(dy))
                step = Math.Abs(dx);
            else
                step = Math.Abs(dy);

            // Calculate x-increment and y-increment for each 
            // step 
            float x_incr = (float)dx / step;
            float y_incr = (float)dy / step;

            // Take the initial points as x and y 
            float x = x0;
            float y = y0;

            int[,] direction = new int[2, (step + 1)];

            for (int i = 0; i < step; i++)
            {
                direction[0,i] = Round(x);
                direction[1,i] = Round(y);
                // putpixel(round(x), round(y), WHITE); 
                //Console.WriteLine(Round(x) + " " + Round(y));
                x += x_incr;
                y += y_incr;
                // delay(10); 
            }
            direction[0,step] = x1;
            direction[1,step] = y1;
            return direction;
        }

        // Driver code 

    }

}
