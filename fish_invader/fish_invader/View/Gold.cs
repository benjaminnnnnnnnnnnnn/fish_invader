using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class Gold
    {
        private int _x;
        private int _y;
        private int _height;
        private int _width;
        private int _amount;

        public Image HeartImage { get; private set; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Amount { get => _amount; set => _amount = value; }

        public Gold(int x, int y, int sizefish)
        {
            HeartImage = Image.FromFile("images/otherimage/gold.png");

            _height = (HeartImage.Height / 2);
            _width = (HeartImage.Width / 2);

            _x = x;
            _y = y;

            _amount = GlobalHelpers.alea.Next(1,(sizefish * 2));
        }

        public void Render(BufferedGraphics drawingSpace)
        {

            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(HeartImage, -HeartImage.Width / 2, -HeartImage.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

        }
    }
}
