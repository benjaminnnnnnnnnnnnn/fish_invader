using FishInvader.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishInvader
{
    public partial class BadFish
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.DeepSkyBlue), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.Black), 1);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {



            drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(BadFishImage, -BadFishImage.Width / 2, -BadFishImage.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation



            if (IsPnj == true)
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushPNJ, (X - (Name.Length * 3)), (Y  - Height - 15));

            
            if (PnjTouch == true)
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
