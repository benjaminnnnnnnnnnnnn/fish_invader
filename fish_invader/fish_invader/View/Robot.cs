using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class Robot
    {
        private Image robotimage = Image.FromFile("images/otherimage/robot.png");
        private int _x;
        private int _y;
        private int _height;
        private int _width;
        private int _id;

        public Robot(int x, int y, int id)
        {
            _x = x;
            _y = y;
            _height = (robotimage.Height / 5);
            _width = (robotimage.Width / 5);
            _id = id;
        }

        int oldh;
        int h;
        int g;
        double closestgold;
        int xx;
        int yy;
        int s;
        int[,] direction = new int[2, 1500];
        public void Update(List<Gold> golds, Fish fish)
        {
            closestgold = 999999999;
            g = 0;

            

            foreach (Gold gold in golds)
            {
                xx = (gold.X - _x);
                yy = (gold.Y - _y);

                g++;
                if (Math.Sqrt((xx * xx) + (yy * yy)) < closestgold && gold.LockedID == _id || Math.Sqrt((xx * xx) + (yy * yy)) < closestgold && gold.LockedID == -1)
                {
                    closestgold = (Math.Sqrt((xx * xx) + (yy * yy)));
                    h = g;
                }

                
            }

            g = 0;
            if (oldh != h) 
            {
                s = 0;
                foreach(Gold gold in golds)
                {
                    g++;
                    if (oldh == g)
                    { 
                        gold.LockedID = -1;
                    }
                }
            }

            g = 0;
            foreach (Gold gold in golds)
            {
                g++;
                if (h == g)
                {
                    gold.LockedID = _id;

                    if (s == 0)
                    {
                        direction = metode.DDALine(_x, _y, gold.X, gold.Y);
                    }

                    _x = direction[0, s];
                    _y = direction[1, s];











                    s++;
                    if ((gold.X - _x) == 0 && (gold.Y - _y) == 0 || s == (direction.Length / 2))
                    {
                        fish.Gold += gold.Amount;
                        golds.Remove(gold);
                        s = 0;
                    }
                    break;
                }



            }
            oldh = h;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            if (!AirSpace.TalkingToPng)
            {
                //pour pas que l'image deviene flou (anti ailashing off)
                drawingSpace.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                drawingSpace.Graphics.DrawImage(robotimage, new Rectangle(_x - (_width /2), _y - (_height / 2), _width, _height));
            }
        }

    }



}
