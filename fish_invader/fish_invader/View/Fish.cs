using FishInvader.Helpers;

namespace FishInvader
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Fish
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.DeepSkyBlue), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.Black), 1);
        private Pen droneBrushdeep = new Pen(new SolidBrush(Color.DeepSkyBlue), 75);
        private Pen droneBrushdark = new Pen(new SolidBrush(Color.DarkCyan), 30);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {

            drawingSpace.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;


            drawingSpace.Graphics.DrawRectangle(droneBrushdeep, 1060, 38, 90, 25);

            drawingSpace.Graphics.DrawString($"helth : {this}", TextHelpers.drawbigFont, TextHelpers.writingBrushPink , 1040, 10);
            drawingSpace.Graphics.DrawString($"Gold : {Gold}", TextHelpers.drawbigFont, TextHelpers.writingBrushGold, 1040, 50);

            if (facing_left)
            {
                using (Image Flippedfish = Image.FromFile("images/originalfish/f2sh1.png"))
                {
                    // Flip the image
                    Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);


                    drawingSpace.Graphics.DrawImage(Flippedfish, new Rectangle(X, Y, _width, _height));
                    /*
                    drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du poisson
                    drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                    */
                }

            }
            else
            {
                /*
                drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du poisson
                drawingSpace.Graphics.DrawImage(FishImage, -FishImage.Width / 2, -FishImage.Height / 2);
                drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                */
                drawingSpace.Graphics.DrawImage(FishImage, new Rectangle(X, Y, _width, _height));
            }

            if (Wepon.wepontype == 1 || Wepon.wepontype == 2 || Wepon.wepontype == 3 || Wepon.wepontype == 4 || Wepon.wepontype == 5 || Wepon.wepontype == 6)
            {
                drawingSpace.Graphics.DrawRectangle(droneBrushdark, 0, 15, 85, 3);

                if (AirSpace.reloding)
                    drawingSpace.Graphics.DrawString("Reloding", TextHelpers.drawNormalFont, TextHelpers.writingBrushwhite, 5, 5);
                else
                    drawingSpace.Graphics.DrawString($"Bullets : {AirSpace.progectilcapacity}", TextHelpers.drawNormalFont, TextHelpers.writingBrushwhite, 5, 5);
            }


        }
        // De manière textuelle
        public override string ToString()
        {
            return $"{helth}";
        }
    }
}
