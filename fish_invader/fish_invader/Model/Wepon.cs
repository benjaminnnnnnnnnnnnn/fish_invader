using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class Wepon
    {
        private int _x;
        private int _y;
        public static bool hiting = false;
        private int _height;
        private int _width;
        private int _damage;

        public Image WeponImage { get; private set; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Damage { get => _damage; set => _damage = value; }

        public Wepon()
        {
            WeponImage = Image.FromFile("otherimage\\sward.png");

            _damage = 3;

            _height = (WeponImage.Height /2);
            _width = (WeponImage.Width /2);
        }



        public void update(List<Fish> fishfleet)
        {
            foreach (Fish fish in fishfleet)
            {
                _x = fish.X;
                _y = fish.Y;
            }

        }
    }
}
