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
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushPNJ, ((X - 11) - (Name.Length / 2)), Y - 25);
            else
                drawingSpace.Graphics.DrawString($"{this}",TextHelpers.drawFont, TextHelpers.writingBrush, ((X - 11) - (Name.Length / 2)), Y - 25);

            if (PnjTouch == true)
            {
                drawingSpace.Graphics.TranslateTransform(1160, 565); // Déplace l'origine du dessin au centre du fish
                drawingSpace.Graphics.DrawImage(PressE, -PressE.Width / 2, -PressE.Height / 2);
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
