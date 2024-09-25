using FishInvader.Helpers;
using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishInvader
{
    public partial class Wepon
    {

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {

            if (Fish.facing_left)
            {


                if (hiting)
                {
                    using (Image Flippedfish = Image.FromFile("otherimage\\sward.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.Rotate180FlipX);



                        drawingSpace.Graphics.TranslateTransform((_x - 20), (_y + 10)); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else
                {
                    drawingSpace.Graphics.TranslateTransform((_x - 20), _y); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImage, -WeponImage.Width / 2, -WeponImage.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
            }
            else
            {

                if (hiting)
                {
                    using (Image Flippedfish = Image.FromFile("otherimage\\sward.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.Rotate90FlipY);



                        drawingSpace.Graphics.TranslateTransform((_x + 20), (_y + 10)); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else
                {
                    using (Image Flippedfish = Image.FromFile("otherimage\\sward.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform((_x + 20), _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }


            }








        }
    }
}
