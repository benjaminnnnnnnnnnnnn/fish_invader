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
        public int x2 = -200;
        public int x3 = -200;
        private int v;
        private int _heights1;
        private int _heights2;
        private int _heights3;

        private int _widths1;
        private int _widths2;
        private int _widths3;

        private int _health1 = 50;
        private int _health2 = 50;
        private int _health3 = 25;


        private int _whalex = -1500;
        private int _whaley = 165;
        private int _heightwhale;
        private int _widthwhale;


        private Image whale = Image.FromFile("otherimage/whale2.png");

        public Event()
        {
            _heights1 = (shark1.Height /2);
            _heights2 = (shark2.Height /2);
            _heights3 = (babyshark.Height /2);

            _widths1 = (shark1.Width /2);
            _widths2 = (shark2.Width /2);
            _widths3 = (babyshark.Width /2);


            _heightwhale = (whale.Height / 2);
            _widthwhale = (whale.Width / 2);
        }
        public Image Shark1 { get => shark1; set => shark1 = value; }
        public Image Shark2 { get => shark2; set => shark2 = value; }
        public Image Babyshark { get => babyshark; set => babyshark = value; }
        public int Heights1 { get => _heights1; set => _heights1 = value; }
        public int Heights2 { get => _heights2; set => _heights2 = value; }
        public int Heights3 { get => _heights3; set => _heights3 = value; }
        public int Widths1 { get => _widths1; set => _widths1 = value; }
        public int Widths2 { get => _widths2; set => _widths2 = value; }
        public int Widths3 { get => _widths3; set => _widths3 = value; }
        public int Health1 { get => _health1; set => _health1 = value; }
        public int Health2 { get => _health2; set => _health2 = value; }
        public int Health3 { get => _health3; set => _health3 = value; }
        public int Whalex { get => _whalex; set => _whalex = value; }
        public int Heightwhale { get => _heightwhale; set => _heightwhale = value; }
        public int Widthwhale { get => _widthwhale; set => _widthwhale = value; }
        public int Whaley { get => _whaley; set => _whaley = value; }

        public void Render(BufferedGraphics drawingSpace)
        {

            if (AirSpace.eventtype == 0)
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




                if (Health1 > 0)
                {
                    drawingSpace.Graphics.TranslateTransform(x, 200); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(shark1, -shark1.Width / 2, -shark1.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }



                if (Health2 > 0)
                {
                    drawingSpace.Graphics.TranslateTransform(x2, 400); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(shark2, -shark2.Width / 2, -shark2.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }


                if (Health3 > 0)
                {
                    if (x > 150)
                    {


                        drawingSpace.Graphics.TranslateTransform(x3, 475); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(shark3, -shark3.Width / 2, -shark3.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation



                    }
                }


                x += 3;
                x2 += 3;
                x3 += 2;
            }

            if (AirSpace.eventtype == 1)
            {
                drawingSpace.Graphics.TranslateTransform(_whalex, _whaley); // Déplace l'origine du dessin au centre du fish
                drawingSpace.Graphics.DrawImage(whale, -whale.Width / 2, -whale.Height / 2);
                drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                if (!AirSpace.TalkingToPng)
                    _whalex+= 1;
            }



        }

    }
}
