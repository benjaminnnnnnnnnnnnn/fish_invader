using FishInvader.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishInvader
{
    public partial class Jellyfish
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.DeepSkyBlue), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.Black), 1);

        private Image shopimage = Image.FromFile("images/otherimage/shop.png");

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            //pour pas que l'image deviene flou (anti ailashing off)
            drawingSpace.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (v == 1)
            {
                drawingSpace.Graphics.DrawImage(JellyFishImage2, new Rectangle(X, Y, _width, _height));
            }
            else
            {
                drawingSpace.Graphics.DrawImage(JellyFishImage, new Rectangle(X, Y, _width, _height));

            }





            if (IsPnj == true)
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushPNJ, (X + _width / 2 - (Name.Length * 3)), (Y + _height / 20) - 40);

            if (IsShop == true)
            {
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushGold, (X + _width / 2 - (Name.Length * 3)), (Y + _height / 20) - 40);

                drawingSpace.Graphics.DrawImage(shopimage, new Rectangle(X + _width / 4, Y + Height / 5, _width / 2, _height / 3));

            }


            if (PnjTouch == true || ShopTouch == true)
            {
                drawingSpace.Graphics.TranslateTransform(1160, 565);
                if (Fish.pressingE == true)
                {
                    drawingSpace.Graphics.DrawImage(PressEdown, -PressEdown.Width / 2, -PressEdown.Height / 2);
                }
                else
                {
                    drawingSpace.Graphics.DrawImage(PressE, -PressE.Width / 2, -PressE.Height / 2);
                }
                drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

            }




        }


        // De manière textuelle
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
