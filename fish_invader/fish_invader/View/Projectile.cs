using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishInvader
{
    public partial class Projectile
    {
        private int _x;
        private int _y;
        private Image _bullet = Image.FromFile("images/otherimage/bullet.png");
        private Image _slimeball = Image.FromFile("images/otherimage/slime-ball.png");
        private bool _direction;
        private int _height;
        private int _width;
        private int _way;

        private int _slimeheight;
        private int _slimewidth;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Slimeheight { get => _slimeheight; set => _slimeheight = value; }
        public int Slimewidth { get => _slimewidth; set => _slimewidth = value; }

        public Projectile(int x, int y)
        {
            _slimeheight = _slimeball.Height;
            _slimewidth = _slimeball.Width;

            _height = _bullet.Height;
            _width = _bullet.Width;
            _x = x;
            _y = y;
            _direction = Fish.facing_left;
            if (Wepon.wepontype == 2)
                _way = GlobalHelpers.alea.Next(-4,5);
            else
                _way = GlobalHelpers.alea.Next(-3, 4);
        }

        public int bulletdistance = 0;
        public void Update()
        {
            if (_direction && Wepon.wepontype == 1)
                _x -= 5;
            else if (Wepon.wepontype == 1)
                _x += 5;
            else if (_direction && Wepon.wepontype == 2)
            {
                _x -= 6;
                _y += _way;
            }
            else if (Wepon.wepontype == 2)
            {
                _x += 6;
                _y += _way;
            }
            else if (_direction && Wepon.wepontype == 3)
            {
                _x -= GlobalHelpers.alea.Next(7,10);
                _y += _way;
                bulletdistance++;
            }
            else if (Wepon.wepontype == 3)
            {
                _x += GlobalHelpers.alea.Next(7, 10);
                _y += _way;
                bulletdistance++;
            }

        }

        public void Render(BufferedGraphics drawingSpace)
        {
            if (_direction)
            {
                if (Wepon.wepontype == 1)
                {
                    using (Image Flippedfish = Image.FromFile("images/otherimage/bullet.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);

                        drawingSpace.Graphics.TranslateTransform(_x - 50, _y - 12); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


                    }
                }
                else
                {
                    using (Image Flippedfish = Image.FromFile("images/otherimage/slime-ball.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);

                        drawingSpace.Graphics.TranslateTransform(_x - 50, _y - 12); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


                    }
                }

            }
            else
            {
                if (Wepon.wepontype == 1)
                {
                    drawingSpace.Graphics.TranslateTransform(_x + 50, _y - 12); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(_bullet, -_bullet.Width / 2, -_bullet.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else
                {
                    drawingSpace.Graphics.TranslateTransform(_x + 50, _y - 12); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(_slimeball, -_slimeball.Width / 2, -_slimeball.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }

            }

        }
    }
}
