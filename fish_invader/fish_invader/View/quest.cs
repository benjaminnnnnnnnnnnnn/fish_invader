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
    public partial class Quest
    {

        private int g = 0;
        private Pen droneBrush = new Pen(new SolidBrush(Color.SandyBrown), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.DeepSkyBlue), 200);
        private Pen droneBrushred = new Pen(new SolidBrush(Color.Red), 40);
        private Pen droneBrushgreen = new Pen(new SolidBrush(Color.Green), 40);
        private string[,] strings = new string[,]
        {
            {"Hello", "Can you... ...for 600 gold", ":(","thank you :>"},
            {"hi", "Can you...   ...for 3 gold","...", "thanks"},
            {"yo", "I*m in a bit of a hurry...   ...of 10 gold", "too bad", "chers mate"},
            {"", "", "(*sad*)", ""},
            {"", "", "", ""},
            {"", "", "", ""},

        };
        private Image fishimage;
        private int colorR;
        private int colorG;
        private int colorB;

        public void Render(BufferedGraphics drawingSpace, List<Fish> fleet, List<BadFish> badfleet)
        {
            //load fish image
            g = 0;
            foreach (BadFish badfish in badfleet)
            {
                g++;

                if (g == Fish.touchingPngId)
                {
                    fishimage = Image.FromFile($"originalfish\\f{badfish.Type}sh15.png");

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


            foreach (Fish fish in fleet)
            {
                if (fish.Y < 300)
                {
                    drawingSpace.Graphics.DrawRectangle(droneBrushblack, 150, 475, 900, 1);
                    drawingSpace.Graphics.DrawRectangle(droneBrush, 50, 375, 1100, 200);
                    drawingSpace.Graphics.DrawString(strings[AirSpace.QuestType, AirSpace.dialogNum], TextHelpers.drawbigFont, TextHelpers.writingBrush, 300, 425);


                    drawingSpace.Graphics.TranslateTransform(75, 400); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(fishimage, -fishimage.Width / 2, -fishimage.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    if (AirSpace.dialogNum == 1)
                    {
                        drawingSpace.Graphics.DrawRectangle(droneBrushgreen, 900, 450, 75, 1);
                        drawingSpace.Graphics.DrawString("ok (y)", TextHelpers.drawbigFont, TextHelpers.writingBrush, 900, 431);
                        drawingSpace.Graphics.DrawRectangle(droneBrushred, 900, 525, 75, 1);
                        drawingSpace.Graphics.DrawString("no (n)", TextHelpers.drawbigFont, TextHelpers.writingBrush, 900, 506);
                    }

                }
                else
                {
                    drawingSpace.Graphics.DrawRectangle(droneBrushblack, 150, 125, 900, 1);
                    drawingSpace.Graphics.DrawRectangle(droneBrush, 50, 25, 1100, 200);

                    drawingSpace.Graphics.DrawString(strings[AirSpace.QuestType, AirSpace.dialogNum], TextHelpers.drawbigFont, TextHelpers.writingBrush, 300, 100);


                    drawingSpace.Graphics.TranslateTransform(75, 50); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(fishimage, -fishimage.Width / 2, -fishimage.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    if (AirSpace.dialogNum == 1)
                    {
                        drawingSpace.Graphics.DrawRectangle(droneBrushgreen, 900, 100, 75, 1);
                        drawingSpace.Graphics.DrawString("ok (y)", TextHelpers.drawbigFont, TextHelpers.writingBrush, 900, 81);
                        drawingSpace.Graphics.DrawRectangle(droneBrushred, 900, 175, 75, 1);
                        drawingSpace.Graphics.DrawString("no (n)", TextHelpers.drawbigFont, TextHelpers.writingBrush, 900, 159);
                    }
                }
            }

        }
    }
}
