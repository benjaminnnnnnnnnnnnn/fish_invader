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
        private Pen droneBrush = new Pen(new SolidBrush(Color.DeepSkyBlue), 3);
        private int _x;
        private int _y;
        private Image _bullet = Image.FromFile("images/otherimage/bullet.png");
        private Image _slimeball = Image.FromFile("images/otherimage/slime-ball.png");
        private bool _direction;
        private int _height;
        private int _width;
        private int _way;
        private int _damage;
        private int _bullettype;

        private int _slimeheight;
        private int _slimewidth;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Slimeheight { get => _slimeheight; set => _slimeheight = value; }
        public int Slimewidth { get => _slimewidth; set => _slimewidth = value; }
        public int Damage { get => _damage; set => _damage = value; }

        public Projectile(int x, int y, int damage, int wepontype, Fish fish)
        {
            _slimeheight = _slimeball.Height;
            _slimewidth = _slimeball.Width;

            _height = _bullet.Height;
            _width = _bullet.Width;

            _direction = Fish.facing_left;
            if (Wepon.wepontype == 2)
                _way = GlobalHelpers.alea.Next(-4, 5);
            else if (Wepon.wepontype == 3)
                _way = GlobalHelpers.alea.Next(-3, 4);
            else
                _way = GlobalHelpers.alea.Next(-1, 2);
            _damage = damage;
            _bullettype = wepontype;

            if (_direction && _bullettype == 1)
            {
                _x = (x - 12);
                _y = (y - 5);  
            }
            else if (_bullettype == 1)
            {
                _x = (x + fish.Width + 12);
                _y= (y - 5);
            }
            else if (_direction && _bullettype == 2)
            {
                _x = (x + 5);
                _y = (y - 2);
            }
            else if (_bullettype == 2)
            {
                _x = (x + fish.Width - 5);
                _y = (y - 2);
            }
            else if (_direction && _bullettype == 3)
            {
                _x = (x - 22);
                _y = (y + 12);

            }
            else if (_bullettype == 3)
            {
                _x = (x + fish.Width + 22);
                _y = (y + 12);

            }
            else if (_direction && _bullettype == 4)
            {
                _x = (x - 8);
                _y = (y - 1);
            }
            else if (_bullettype == 4)
            {
                _x = (x + fish.Width + 8);
                _y = (y - 1);

            }
            else if (_direction && _bullettype == 5)
            {
                _x = (x - 60);
                _y = (y + 14);
            }
            else if (_bullettype == 5)
            {
                _x += (x + fish.Width + 60);
                _y += (y + 14);

            }
            else if (_direction && _bullettype == 6)
            {
                _x = (x - 45);
                _y = (y + 12);
            }
            else if (_bullettype == 6)
            {
                _x = (x + fish.Width + 45);
                _y = (y + 12);
            }
            else if (_bullettype == 7)
            {
                _x = (x - 5);
                _y = (y + 8);
            }
        }

        public int bulletdistance = 0;
        public void Update()
        {
            
            if (_direction && _bullettype == 1)
                _x -= 5;
            else if (_bullettype == 1)
                _x += 5;
            else if (_direction && _bullettype == 2)
            {
                _x -= 6;
                _y += _way;
            }
            else if (_bullettype == 2)
            {
                _x += 6;
                _y += _way;
            }
            else if (_direction && _bullettype == 3)
            {
                _x -= GlobalHelpers.alea.Next(7,10);
                _y += _way;
                bulletdistance++;
            }
            else if (_bullettype == 3)
            {
                _x += GlobalHelpers.alea.Next(7, 10);
                _y += _way;
                bulletdistance++;
            }
            else if (_direction && _bullettype == 4)
            {
                _x -= GlobalHelpers.alea.Next(7, 10);
                _y += _way;
            }
            else if (_bullettype == 4)
            {
                _x += GlobalHelpers.alea.Next(7, 10);
                _y += _way;

            }
            else if (_direction && _bullettype == 5)
            {
                _x -= GlobalHelpers.alea.Next(7, 10);
                _y += _way;
            }
            else if (_bullettype == 5)
            {
                _x += GlobalHelpers.alea.Next(7, 10);
                _y += _way;

            }
            else if (_direction && _bullettype == 6)
            {
                _x -= 15;
            }
            else if (_bullettype == 6)
            {
                _x += 15;
            }
            else if (_bullettype == 7)
            {
                _x -= 5;
            }
            
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            if (_bullettype == 7)
            {
                using (Image Flippedfish = Image.FromFile("images/otherimage/bullet.png"))
                {
                    // Flip the image
                    Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


                }
            }
            else if (_direction)
            {
                if (_bullettype == 1 || _bullettype == 4 || _bullettype == 5 || _bullettype == 6)
                {
                    using (Image Flippedfish = Image.FromFile("images/otherimage/bullet.png"))
                    {
                        // Flip the image
                        Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);

                        drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
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

                        drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


                    }
                }

            }
            else
            {
                if (_bullettype == 1 || _bullettype == 4 || _bullettype == 5 || _bullettype == 6)
                {
                    drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(_bullet, -_bullet.Width / 2, -_bullet.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else
                {
                    drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(_slimeball, -_slimeball.Width / 2, -_slimeball.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }

            }
        }        
    }
}
