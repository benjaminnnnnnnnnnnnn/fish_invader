using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class turet
    {
        private Image turetimage = Image.FromFile("images/otherimage/turet.png");
        private int _x;
        private int _y;
        private int _height;
        private int _width;
        
        public turet(int x, int y)
        {

            _height = turetimage.Height;
            _width = turetimage.Width;

            _x = (x - (_width / 2));
            _y = (y - (_height / 2));
        }
        int k;
        public void Update(List<Projectile> projectiles, Fish fish)
        {
            k++;
            if (k == 50)
            {
                projectiles.Add(new Projectile(_x,_y, 5,7, fish));
                k = 0;
            }
        }
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(turetimage, new Rectangle(_x, _y, _width, _height));
        }
    }
}
