using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class Projectile
    {
        private int _x;
        private int _y;
        private Image _bullet = Image.FromFile("otherimage\\bullet.png");

        public Projectile(int x, int y)
        {
            _x = x;
            _y = y;
        }


        public void Update()
        {
            if (Fish.facing_left)
                _x-= 5;
            else
                _x+= 5;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
            drawingSpace.Graphics.DrawImage(_bullet, -_bullet.Width / 2, -_bullet.Height / 2);
            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
        }
    }
}
