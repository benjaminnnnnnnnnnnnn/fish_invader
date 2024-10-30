using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class Kelp
    {
        private Image kelpimage = Image.FromFile("images/otherimage/kelp.png");
        private int _x;
        private int _y;
        private int _height;
        private int _width;
        private int _size;

        public Kelp(int x, int y, int size)
        {
            _size = size;
            _x = x;
            _y = y;
            _height = (kelpimage.Height * _size);
            _width = (kelpimage.Width * _size);

        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public void Render(BufferedGraphics drawingSpace)
        {
            if (!AirSpace.TalkingToPng)
            {
                //pour pas que l'image deviene flou (anti ailashing off)
                drawingSpace.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                drawingSpace.Graphics.DrawImage(kelpimage, new Rectangle(X, Y, _width, _height));
            }
        }
    }
}
