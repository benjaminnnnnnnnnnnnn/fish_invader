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
    }
}
