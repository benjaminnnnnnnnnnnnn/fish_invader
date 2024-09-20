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
        private bool _IsPnj = false;
        private int _id;
        private int _width;
        private int _height;
        public  static bool PnjTouch = false;
        public static Image PressE = Image.FromFile("PressE.png");
        //public PictureBox badfishpicture;

        public Image BadFishImage { get; private set; }

        // Constructeur
        public BadFish( int i)
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



            //set pos to ramdom location
            _x = GlobalHelpers.alea.Next(0, 1200);
            _y = GlobalHelpers.alea.Next(0, 600);
            





            //if badfish is a png
            if ((GlobalHelpers.alea.Next(0, 25)) == 1)
            {
                _IsPnj = true;
                _name = metode.RandomName();
                _speed = GlobalHelpers.alea.Next(1, 3);
            }
            else
            {
                _speed = GlobalHelpers.alea.Next(1, 6);
                _name = "";
            }




            //pour ne pas lock l'image
            using (var bmpTemp = new Bitmap(@"fishpng\fish" + i + ".png"))
            {
                BadFishImage = new Bitmap(bmpTemp);
            }


            //set image hight and width (for hitbox)
            _height = (BadFishImage.Height / 2);
            _width = (BadFishImage.Width / 2);



            _id = i;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }
        public bool IsPnj { get { return _IsPnj; } }

        public int Height { get { return _height; } }
        public int Width { get { return _width; } }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update()
        {
            _x += _speed;



            if (_x >= 1200)
            {

                _x = 0;
                _y = GlobalHelpers.alea.Next(0, 600);
                if ((GlobalHelpers.alea.Next(0, 25)) == 1)
                {
                    _IsPnj = true;
                    _name = metode.RandomName();
                    _speed = GlobalHelpers.alea.Next(1, 3);
                }
                else
                {
                    _name = "";
                    _speed = GlobalHelpers.alea.Next(1, 6);
                }




                //changer la taile du poison
                for (int j = 1; j < 21; j++)
                {
                    if (GlobalHelpers.alea.Next(1, 3) == 2)
                    {
                        originalfish = Image.FromFile("originalfish\\fish" + j + ".png");
                        break;
                    }

                }

                _height = (originalfish.Height / 2);
                _width = (originalfish.Width / 2);

                //changer l'image du poisson
                // Load the bitmap
                var bmp = new Bitmap(originalfish);

                // Perform color swapping
                int ColorR = GlobalHelpers.alea.Next(0, 256);
                int ColorG = GlobalHelpers.alea.Next(0, 256);
                int ColorB = GlobalHelpers.alea.Next(0, 256);


                metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(ColorR, ColorG, ColorB));
                metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(ColorR - (ColorR / 3), ColorG - (ColorG / 3), ColorB - (ColorB / 3)));

                if ((ColorR + (ColorR / 3)) > 255)
                {
                    ColorR = 255;
                }
                else
                    ColorR += (ColorR / 3);

                if ((ColorG + (ColorG / 3)) > 255)
                {
                    ColorG = 255;
                }
                else
                    ColorG += (ColorG / 3);

                if ((ColorB + (ColorB / 3)) > 255)
                {
                    ColorB = 255;
                }
                else
                    ColorB += (ColorB / 3);

                metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(ColorR, ColorG, ColorB));
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
