using FishInvader.Helpers;
using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using System.Security.Cryptography;

namespace fish_invader
{
    public partial class Event
    {
        private Image shark1 = Image.FromFile("otherimage/shark1.png");
        private Image shark2 = Image.FromFile("otherimage/shark2.png");
        private Image babyshark = Image.FromFile("otherimage/babyshark.png");
        private Image shark3;
        public int x = -200;
        private int v;

        public Image Shark1 { get => shark1; set => shark1 = value; }
        public Image Shark2 { get => shark2; set => shark2 = value; }
        public Image Babyshark { get => babyshark; set => babyshark = value; }

        public void Render(BufferedGraphics drawingSpace)
        {
            if (x == -200)
            {
                v = GlobalHelpers.alea.Next(0, 5);

                var bmp = new Bitmap(babyshark);


                if (v == 0)
                {
                    //green
                    metode.SwapColor(bmp, Color.FromArgb(253, 86, 164), Color.FromArgb(166, 210, 39));
                    metode.SwapColor(bmp, Color.FromArgb(184, 23, 99), Color.FromArgb(146, 190, 19));
                }
                else if (v == 1)
                {
                    //yellow
                    metode.SwapColor(bmp, Color.FromArgb(253, 86, 164), Color.FromArgb(255, 214, 28));
                    metode.SwapColor(bmp, Color.FromArgb(184, 23, 99), Color.FromArgb(235, 194, 0));
                }
                else if (v == 2)
                {
                    //orange
                    metode.SwapColor(bmp, Color.FromArgb(253, 86, 164), Color.FromArgb(255, 165, 45));
                    metode.SwapColor(bmp, Color.FromArgb(184, 23, 99), Color.FromArgb(235, 145, 25));
                }
                else if (v == 3)
                {
                    //blue
                    metode.SwapColor(bmp, Color.FromArgb(253, 86, 164), Color.FromArgb(1, 93, 240));
                    metode.SwapColor(bmp, Color.FromArgb(184, 23, 99), Color.FromArgb(0, 73, 220));
                }


                // Save the modified image
                bmp.Save(@"otherimage\\babyshark1.png", System.Drawing.Imaging.ImageFormat.Png);

                //reprendre l'image après l'avoir changer
                using (var bmpTemp = new Bitmap(@"otherimage\babyshark1.png"))
                {
                    shark3 = new Bitmap(bmpTemp);
                }

            }






            

            drawingSpace.Graphics.TranslateTransform(x, 200); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(shark1, -shark1.Width / 2, -shark1.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

            drawingSpace.Graphics.TranslateTransform(x, 400); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(shark2, -shark2.Width / 2, -shark2.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


            if (x > 150)
            {





                x -= 250;

                drawingSpace.Graphics.TranslateTransform(x, 475); // Déplace l'origine du dessin au centre du fish
                drawingSpace.Graphics.DrawImage(shark3, -shark3.Width / 2, -shark3.Height / 2);
                drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                x += 250;


            }
            x += 3;

        }

    }
}
