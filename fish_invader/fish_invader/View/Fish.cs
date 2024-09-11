using FishInvader.Helpers;

namespace FishInvader
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Fish
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.DeepSkyBlue), 3);
        private Pen droneBrushblack = new Pen(new SolidBrush(Color.Black), 1);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {


            drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du cowboy
            drawingSpace.Graphics.DrawImage(FishImage, -FishImage.Width / 2, -FishImage.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation



        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ({((int)((double)_charge / FULLCHARGE * 100)).ToString()}%)";
        }

    }
}
