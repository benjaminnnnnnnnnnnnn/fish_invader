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
            drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(X - 6, Y - 2, 15, 8));
            drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(X +10, Y - 2, 5, 8));
            drawingSpace.Graphics.DrawEllipse(droneBrushblack, new Rectangle(X - 5, Y , 4, 4));
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X -25, Y - 25);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ({((int)((double)_charge / FULLCHARGE * 100)).ToString()}%)";
        }

    }
}
