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
    public partial class Shop
    {
        public static int numberoffish = 0;
        private int g = 0;
        private Pen droneBrush = new Pen(new SolidBrush(Color.SandyBrown), 3);
        private Pen droneBrush2 = new Pen(new SolidBrush(Color.Black), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.DeepSkyBlue), 200);
        private Pen droneBrushred = new Pen(new SolidBrush(Color.Red), 40);
        private Pen droneBrushgreen = new Pen(new SolidBrush(Color.Green), 40);
        private Image fishimage;
        private int colorR;
        private int colorG;
        private int colorB;
        private string pngname;

        private double doucolorR;
        private double doucolorG;
        private double doucolorB;

        public int selectionX = 0;
        public int selectionY = 0;


        private Image[,] images = new Image[3, 5] 
            {
            {Image.FromFile("otherimage\\gun.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"),Image.FromFile("otherimage\\missing_texture.png")},
            {Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png")},
            {Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png"), Image.FromFile("otherimage\\missing_texture.png")},
            };

        private int[,] price = new int[3, 5]
        {
            {50,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}, 
        };


        public void Render(BufferedGraphics drawingSpace, List<Fish> fleet, List<BadFish> badfleet, List<Jellyfish> jellyfleet)
        {


            //load fish image
            g = 0;
            if (Jellyfish.PnjTouch)
            {
                foreach (Jellyfish jellyfish in jellyfleet)
                {
                    g++;

                    if (g == Fish.touchingjellyPngId)
                    {
                        fishimage = Image.FromFile($"originalfish\\jellyf1sh7.png");
                        pngname = jellyfish.Name;

                        var bmp = new Bitmap(fishimage);

                        doucolorR = jellyfish.ColorR;
                        doucolorG = jellyfish.ColorG;
                        doucolorB = jellyfish.ColorB;


                        metode.SwapColor(bmp, Color.FromArgb(207, 255, 255), Color.FromArgb(Convert.ToInt32(doucolorR), Convert.ToInt32(doucolorG), Convert.ToInt32(doucolorB)));
                        metode.SwapColor(bmp, Color.FromArgb(174, 251, 255), Color.FromArgb(Convert.ToInt32(Math.Round(doucolorR / 1.19)), Convert.ToInt32(Math.Round(doucolorG / 1.0159)), Convert.ToInt32(doucolorB)));
                        metode.SwapColor(bmp, Color.FromArgb(143, 234, 255), Color.FromArgb(Convert.ToInt32(Math.Round(doucolorR / 1.448)), Convert.ToInt32(Math.Round(doucolorG / 1.0897)), Convert.ToInt32(doucolorG)));
                        metode.SwapColor(bmp, Color.FromArgb(96, 205, 239), Color.FromArgb(Convert.ToInt32(doucolorR / 2.15625), Convert.ToInt32(doucolorG / 1.2439), Convert.ToInt32(doucolorB / 1.0661)));
                        metode.SwapColor(bmp, Color.FromArgb(73, 194, 214), Color.FromArgb(Convert.ToInt32(doucolorR / 2.8356), Convert.ToInt32(doucolorG / 1.3113), Convert.ToInt32(doucolorB / 1.1911)));
                        metode.SwapColor(bmp, Color.FromArgb(50, 173, 186), Color.FromArgb(Convert.ToInt32(doucolorR / 4.14), Convert.ToInt32(doucolorG / 1.4734), Convert.ToInt32(doucolorB / 1.3672)));



                        // Save the modified image
                        bmp.Save(@"otherimage\\fishpng.png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("otherimage\\fishpng.png"))
                        {
                            fishimage = new Bitmap(bmpTemp);
                        }





                    }
                }
            }
            else
            {
                foreach (BadFish badfish in badfleet)
                {
                    g++;

                    if (g == Fish.touchingPngId)
                    {
                        fishimage = Image.FromFile($"originalfish\\f{badfish.Type}sh7.png");
                        pngname = badfish.Name;

                        var bmp = new Bitmap(fishimage);

                        colorR = badfish.ColorR;
                        colorG = badfish.ColorG;
                        colorB = badfish.ColorB;


                        metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(badfish.ColorR, badfish.ColorG, badfish.ColorB));
                        metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(badfish.ColorR - (badfish.ColorR / 3), badfish.ColorG - (badfish.ColorG / 3), badfish.ColorB - (badfish.ColorB / 3)));
                        metode.SwapColor(bmp, Color.FromArgb(225, 55, 0), Color.FromArgb(badfish.ColorR - (badfish.ColorR / 2), badfish.ColorG - (badfish.ColorG / 2), badfish.ColorB - (badfish.ColorB / 2)));
                        if ((colorR + (colorR / 3)) > 255)
                        {
                            colorR = 255;
                        }
                        else
                            colorR += (colorR / 3);

                        if ((badfish.ColorG + (badfish.ColorG / 3)) > 255)
                        {
                            colorG = 255;
                        }
                        else
                            colorG += (colorG / 3);

                        if ((badfish.ColorB + (badfish.ColorB / 3)) > 255)
                        {
                            colorB = 255;
                        }
                        else
                            colorB += (colorB / 3);
                        metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(colorR, colorG, colorB));


                        // Save the modified image
                        bmp.Save(@"otherimage\\fishpng.png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("otherimage\\fishpng.png"))
                        {
                            fishimage = new Bitmap(bmpTemp);
                        }





                    }
                }
            }



            foreach (Fish fish in fleet)
            {
                drawingSpace.Graphics.DrawRectangle(droneBrushblack, 150, 475, 900, 1);
                drawingSpace.Graphics.DrawRectangle(droneBrush, 50, 375, 1100, 200);

                drawingSpace.Graphics.DrawRectangle(droneBrushblack, 150, 300, 900, 1);
                drawingSpace.Graphics.DrawRectangle(droneBrush, 50, 200, 1100, 200);

                drawingSpace.Graphics.DrawRectangle(droneBrushblack, 150, 125, 900, 1);
                drawingSpace.Graphics.DrawRectangle(droneBrush, 50, 25, 1100, 200);

                drawingSpace.Graphics.DrawString(pngname + "'s Shop", TextHelpers.drawbigFont, TextHelpers.writingBrush, 500, 30);
                drawingSpace.Graphics.DrawString(fish.Gold.ToString() + " Golds", TextHelpers.drawbigFont, TextHelpers.writingBrushGold, 1020, 30);

                drawingSpace.Graphics.TranslateTransform(100, 50); // Déplace l'origine du dessin au centre du fish
                drawingSpace.Graphics.DrawImage(fishimage, -fishimage.Width / 2, -fishimage.Height / 2);
                drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                for (int c = 0; c <= 2; c++)
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        if (c == selectionY && i == selectionX)
                        {
                            drawingSpace.Graphics.DrawRectangle(droneBrush2, (180 + (170 * i)), (105 + (c * 165)), 100, 100);
                        }
                        else
                            drawingSpace.Graphics.DrawRectangle(droneBrush, (180 + (170 * i)), (105 + (c * 165)), 100, 100);

                        drawingSpace.Graphics.TranslateTransform((230 + (170 * i)), (155 + (c * 165))); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(images[c,i], -images[c, i].Width / 2, -images[c, i].Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        drawingSpace.Graphics.DrawString(price[c,i].ToString(), TextHelpers.drawbigFont, TextHelpers.writingBrushGold, (210 + (170 * i)), (170 + (c * 165)));
                    }

                }




            }


        }
    }
}
