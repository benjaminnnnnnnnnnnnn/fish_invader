namespace FishInvader
{
    public partial class BadFish
    {
        private int type = GlobalHelpers.alea.Next(1, 20);
        public static Image originalfish;
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private string _name;
        private int _speed;
        private bool _IsPnj = false;
        private bool _isShop = false;
        private int _id;
        private int _width;
        private int _height;
        public static bool PnjTouch = false;
        public static bool ShopTouch = false;
        public static Image PressE = Image.FromFile("PressE.png");
        public static Image PressEdown = Image.FromFile("PressEdown.png");
        private int _colorR = GlobalHelpers.alea.Next(0, 256);
        private int _colorG = GlobalHelpers.alea.Next(0, 256);
        private int _colorB = GlobalHelpers.alea.Next(0, 256);
        public int helth;
        private int _size;
        //public PictureBox badfishpicture;

        public Image BadFishImage { get; private set; }


        // Constructeur
        public BadFish(int i, int x, int y)
        {
            originalfish = Image.FromFile($"originalfish\\f{type}sh20.png");
            helth = 20;

            for (_size = 5; _size < 16; _size++)
            {


                if (GlobalHelpers.alea.Next(1, 3) == 2)
                {
                    originalfish = Image.FromFile($"originalfish\\f{type}sh" + _size + ".png");
                    helth = _size;
                    break;
                }
            }











            //if badfish is a png
            if ((GlobalHelpers.alea.Next(0, 25)) == 0)
            {
                _IsPnj = true;
                _name = metode.RandomName();
                _speed = GlobalHelpers.alea.Next(1, 3);
            }
            else if ((GlobalHelpers.alea.Next(0, 25)) == 0)
            {
                _isShop = true;
                _name = metode.RandomName();
                _speed = GlobalHelpers.alea.Next(1, 3);
            }
            else
            {
                _speed = GlobalHelpers.alea.Next(1, 6);
                _name = "";
            }





            var bmp = new Bitmap(originalfish);

            metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(_colorR, _colorG, _colorB));
            metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(_colorR - (_colorR / 3), _colorG - (_colorG / 3), _colorB - (_colorB / 3)));
            metode.SwapColor(bmp, Color.FromArgb(225, 55, 0), Color.FromArgb(_colorR - (_colorR / 2), _colorG - (_colorG / 2), _colorB - (_colorB / 2)));

            if ((_colorR + (_colorR / 3)) > 255)
            {
                _colorR = 255;
            }
            else
                _colorR += (_colorR / 3);

            if ((_colorG + (_colorG / 3)) > 255)
            {
                _colorG = 255;
            }
            else
                _colorG += (_colorG / 3);

            if ((_colorB + (_colorB / 3)) > 255)
            {
                _colorB = 255;
            }
            else
                _colorB += (_colorB / 3);

            metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(_colorR, _colorG, _colorB));
            metode.SwapColor(bmp, Color.FromArgb(31, 49, 125), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));

            // Save the modified image
            bmp.Save(@"fishpng\\fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //reprendre l'image après l'avoir changer
            using (var bmpTemp = new Bitmap("fishpng\\fish" + _id + ".png"))
            {
                BadFishImage = new Bitmap(bmpTemp);
            }








            //set image hight and width (for hitbox)
            _height = (BadFishImage.Height / 2);
            _width = (BadFishImage.Width / 2);



            //set pos to ramdom location
            if (type == 14)
                _y = 600 - _height;
            else
                _y = y;

            _x = x;


            _id = i;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }
        public bool IsPnj { get { return _IsPnj; } }
        public bool IsShop {  get {  return _isShop; } }

        public int Height { get { return _height; } }
        public int Width { get { return _width; } }

        public int ColorR { get => _colorR; set => _colorR = value; }
        public int ColorG { get => _colorG; set => _colorG = value; }
        public int ColorB { get => _colorB; set => _colorB = value; }
        public int Type { get => type; set => type = value; }
        public int Id { get => _id; set => _id = value; }
        public int Size { get => _size; set => _size = value; }



        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update()
        {
            
            if (!AirSpace.TalkingToPng)
            {

                if (AirSpace.eventtype == 0 && AirSpace.ramdomEvent)
                {
                    _x += (_speed * 3);
                }
                else
                    _x += _speed;






                if (_x >= 1300)
                {
                    if (AirSpace.eventtype == 0 && AirSpace.ramdomEvent && AirSpace.EventTime > 1000)
                    {
                        _x = 1500;
                    }
                    else
                    {

                        //is pnj
                        if ((GlobalHelpers.alea.Next(0, 25)) == 0)
                        {
                            _isShop = false;
                            _IsPnj = true;
                            _name = metode.RandomName();
                            _speed = GlobalHelpers.alea.Next(1, 3);
                        }
                        else if ((GlobalHelpers.alea.Next(0, 25)) == 0)
                        {
                            _IsPnj = false;
                            _isShop = true;
                            _name = metode.RandomName();
                            _speed = GlobalHelpers.alea.Next(1, 3);
                        }
                        else
                        {
                            _isShop = false;    
                            _IsPnj = false;
                            _name = "";
                            _speed = GlobalHelpers.alea.Next(1, 6);
                        }


                        originalfish = Image.FromFile($"originalfish\\f{type}sh20.png");
                        helth = 20;
                        //changer la taile du poison
                        type = GlobalHelpers.alea.Next(1, 20);
                        for (_size = 5; _size < 16; _size++)
                        {
                            if (GlobalHelpers.alea.Next(1, 4) == 2)
                            {
                                originalfish = Image.FromFile($"originalfish\\f{type}sh" + _size + ".png");
                                helth = _size;
                                break;
                            }

                        }

                        _height = (originalfish.Height / 2);
                        _width = (originalfish.Width / 2);


                        if (type == 14)
                            _y = 600 - _height;
                        else if (AirSpace.eventtype == 1 && AirSpace.ramdomEvent)
                            _y = GlobalHelpers.alea.Next(380, 600);
                        else
                            _y = GlobalHelpers.alea.Next(0, 600);
                        _x = -100;

                        //changer l'image du poisson
                        // Load the bitmap
                        var bmp = new Bitmap(originalfish);

                        // Perform color swapping
                        _colorR = GlobalHelpers.alea.Next(0, 256);
                        _colorG = GlobalHelpers.alea.Next(0, 256);
                        _colorB = GlobalHelpers.alea.Next(0, 256);

                        int _secondcolorR;
                        int _secondcolorG;
                        int _secondcolorB;


                        metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(_colorR, _colorG, _colorB));
                        metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(_colorR - (_colorR / 3), _colorG - (_colorG / 3), _colorB - (_colorB / 3)));
                        metode.SwapColor(bmp, Color.FromArgb(225, 55, 0), Color.FromArgb(_colorR - (_colorR / 2), _colorG - (_colorG / 2), _colorB - (_colorB / 2)));

                        if ((_colorR + (_colorR / 3)) > 255)
                        {
                            _secondcolorR = 255;
                        }
                        else
                            _secondcolorR = (_colorR + (_colorR / 3));

                        if ((_colorG + (_colorG / 3)) > 255)
                        {
                            _secondcolorG = 255;
                        }
                        else
                            _secondcolorG = (_colorG + (_colorG / 3));

                        if ((_colorB + (_colorB / 3)) > 255)
                        {
                            _secondcolorB = 255;
                        }
                        else
                            _secondcolorB = (_colorB + (_colorB / 3));

                        metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(_secondcolorR, _secondcolorG, _secondcolorB));
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



    }
}
