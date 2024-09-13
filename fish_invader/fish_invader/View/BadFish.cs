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

            /*
            drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(X + 2, Y - 2, 15, 8));
            drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(X - 6, Y - 2, 5, 8));
            drawingSpace.Graphics.DrawEllipse(droneBrushblack, new Rectangle(X + 10, Y - 2, 4, 4));
            if (IsPng == true)
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushPNJ, ((X - 11) - (Name.Length / 2)), Y - 25);
            else
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, ((X - 11) - (Name.Length / 2)), Y - 25);
            */

            drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(BadFishImage, -BadFishImage.Width / 2, -BadFishImage.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

            if (IsPng == true)
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrushPNJ, ((X - 11) - (Name.Length / 2)), Y - 25);
            else
                drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, ((X - 11) - (Name.Length / 2)), Y - 25);

        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
