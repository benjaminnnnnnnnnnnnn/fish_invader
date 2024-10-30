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
        public static int wepontype = 0;

        public Image WeponImage { get; private set; }
        public Image WeponImageGun { get; private set; }
        public Image WeponImageUsi { get; private set; }
        public Image WeponImageShotgun { get; private set; }
        public Image WeponImageScar { get; private set; }
        public Image WeponImageMini { get; private set; }
        public Image WeponImageSniper { get; private set; }
        public Image WeponImageTuret { get; private set; }
        public Image WeponImageKelp { get; private set; }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Damage { get => _damage; set => _damage = value; }


        public Wepon()
        {
            WeponImage = Image.FromFile("images/otherimage/sward.png");
            WeponImageGun = Image.FromFile("images/otherimage/gun.png");
            WeponImageUsi = Image.FromFile("images/otherimage/usi.png");
            WeponImageShotgun = Image.FromFile("images/otherimage/shotgun.png");
            WeponImageScar = Image.FromFile("images/otherimage/scar.png");
            WeponImageMini = Image.FromFile("images/otherimage/minigun.png");
            WeponImageSniper = Image.FromFile("images/otherimage/sniper.png");
            WeponImageTuret = Image.FromFile("images/otherimage/turet.png");
            WeponImageKelp = Image.FromFile("images/otherimage/kelp.png");
            _damage = 3;

            _height = (WeponImage.Height / 2);
            _width = (WeponImage.Width / 2);
        }



        public void update(Fish fish)
        {


            if (wepontype == 0)
            {
                if (Fish.facing_left)
                {
                    if (hiting)
                    {
                        _x = (fish.X - 10);
                        _y = (fish.Y + 20);
                    }
                    else
                    {
                        _x = (fish.X - 10);
                        _y = (fish.Y + 5);
                    }
                }
                else
                {
                    if (hiting)
                    {
                        _x = (fish.X + fish.Width + 10);
                        _y = (fish.Y + 20);
                    }
                    else
                    {
                        _x = (fish.X + fish.Width+ 10);
                        _y = (fish.Y + 5);
                    }
                }

            }
            else if (wepontype == 1)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X + 25);
                    _y = (fish.Y + 6);

                }
                else
                {

                    _x = (fish.X + fish.Width - 25);
                    _y = (fish.Y + 6);

                }
            }
            else if (wepontype == 2)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X + 25);
                    _y = (fish.Y +5);

                }
                else
                {

                    _x = (fish.X + fish.Width - 25);
                    _y = (fish.Y +5);

                }
            }
            else if (wepontype == 3)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X - 5);
                    _y = (fish.Y + 10);

                }
                else
                {

                    _x = (fish.X + fish.Width + 5);
                    _y = (fish.Y + 10);

                }
            }
            else if (wepontype == 4)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X + fish.Width / 2);
                    _y = (fish.Y - 2);

                }
                else
                {

                    _x = (fish.X + 20);
                    _y = (fish.Y - 2);

                }
            }
            else if (wepontype == 5)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X - 20);
                    _y = (fish.Y + 9);

                }
                else
                {

                    _x = (fish.X + fish.Width + 20);
                    _y = (fish.Y + 9);

                }
            }
            else if (wepontype == 6)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X - 25);
                    _y = (fish.Y + 11);

                }
                else
                {

                    _x = (fish.X + fish.Width + 25);
                    _y = (fish.Y + 11);

                }
            }
            else if (wepontype == 7)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X - 30);
                    _y = (fish.Y + 5);

                }
                else
                {

                    _x = (fish.X + fish.Width + 30);
                    _y = (fish.Y + 5);

                }
            }
            else if (wepontype == 8)
            {
                if (Fish.facing_left)
                {

                    _x = (fish.X - 10);
                    _y = (fish.Y + 3);

                }
                else
                {

                    _x = (fish.X + fish.Width + 10);
                    _y = (fish.Y + 3);

                }
            }


        }
    }
}
