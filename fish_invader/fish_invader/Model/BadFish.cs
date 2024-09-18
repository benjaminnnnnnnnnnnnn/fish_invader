using FishInvader.Helpers;
using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using Efundies;

namespace FishInvader
{
    public partial class BadFish
    {
        private string fishfilepath = "originalfish\\fish20.png";
        public static Image originalfish;
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private string _name;
        private int _speed;
        private bool _IsPng = false;
        private int _id;
        //public PictureBox badfishpicture;

        public Image BadFishImage { get; private set; }

        // Constructeur
        public BadFish(string name, int i)
        {
            for (int j = 1; j < 21; j++)
            {
                if (GlobalHelpers.alea.Next(1,3) == 2)
                {
                    fishfilepath = $"originalfish\\fish{j}.png";
                    break;
                }
            }
            originalfish = Image.FromFile(fishfilepath);


            _x = GlobalHelpers.alea.Next(0, 1200);
            _y = GlobalHelpers.alea.Next(0, 600);
            _name = name;
            _speed = GlobalHelpers.alea.Next(1, 6);
            if ((GlobalHelpers.alea.Next(0, 101)) == 100)
                _IsPng = true;

            //BadFishImage = Image.FromFile("fishpng\\fish" + i + ".png");
            //pour ne pas lock l'image

            using (var bmpTemp = new Bitmap(@"fishpng\fish" + i + ".png"))
            {
                BadFishImage = new Bitmap(bmpTemp);
            }

            //simuler l´hitbox 
            //badfishpicture = new PictureBox();
            //badfishpicture.Image = originalfish;




            _id = i;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }
        public bool IsPng { get { return _IsPng; } }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update()
        {
            _x += _speed;



            if (_x >= 1200)
            {

                _x = 0;
                _y = GlobalHelpers.alea.Next(0, 600);
                _speed = GlobalHelpers.alea.Next(1, 6);
                if ((GlobalHelpers.alea.Next(0, 101)) == 100)
                    _IsPng = true;
                else
                    _IsPng = false;

                _name = metode.RandomName();



                //changer la taile du poison
                for (int j = 1; j < 21; j++)
                {
                    if (GlobalHelpers.alea.Next(1, 3) == 2)
                    {
                        originalfish = Image.FromFile("originalfish\\fish" + j + ".png");
                        break;
                    }

                }

                //changer l'image du poisson
                // Load the bitmap
                var bmp = new Bitmap(originalfish);

                // Perform color swapping
                metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(31, 49, 125), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));

                // Save the modified image
                bmp.Save(@"fishpng\\fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


                //reprendre l'image après l'avoir changer
                using (var bmpTemp = new Bitmap("fishpng\\fish" + _id + ".png"))
                {
                    BadFishImage = new Bitmap(bmpTemp);
                }



            }

        }



    }
}
