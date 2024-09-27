namespace FishInvader
{
    public partial class Jellyfish
    {
        private string Jellyfishfilepath;
        private string Jellyfishfilepath2;
        public static Image originaljellyfish;
        public static Image originaljellyfish2;
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private string _name;
        private int _speed;
        private bool _IsPnj = false;
        private int _id;
        private int _width;
        private int _height;
        public static bool PnjTouch = false;
        public static Image PressE = Image.FromFile("PressE.png");
        public static Image PressEdown = Image.FromFile("PressEdown.png");
        private double _colorR = GlobalHelpers.alea.Next(0, 256);
        private double _colorG = GlobalHelpers.alea.Next(0, 256);
        private double _colorB = GlobalHelpers.alea.Next(0, 256);
        private int _stage = 0;
        private int _helth;
        private int _size;

        //public PictureBox badfishpicture;

        public Image JellyFishImage { get; private set; }
        public Image JellyFishImage2 { get; private set; }


        // Constructeur
        public Jellyfish(int i)
        {
            Jellyfishfilepath = $"originalfish\\jellyf1sh20.png";
            Jellyfishfilepath2 = $"originalfish\\jellyf2sh20.png";

            for (_size = 1; _size < 5; _size++)
            {


                if (GlobalHelpers.alea.Next(1, 3) == 2)
                {
                    Jellyfishfilepath = $"originalfish\\jellyf1sh{_size}.png";
                    Jellyfishfilepath2 = $"originalfish\\jellyf2sh{_size}.png";
                    _helth = _size;
                    break;
                }
            }
            originaljellyfish = Image.FromFile(Jellyfishfilepath);
            originaljellyfish2 = Image.FromFile(Jellyfishfilepath2);










            //if badfish is a png
            if ((GlobalHelpers.alea.Next(0, 25)) == 0)
            {
                _IsPnj = true;
                _name = metode.RandomName();
                _speed = GlobalHelpers.alea.Next(10, 14);
            }
            else
            {
                _speed = GlobalHelpers.alea.Next(10, 14);
                _name = "";
            }


            _stage = 0 - _speed;


            var bmp = new Bitmap(originaljellyfish);

            metode.SwapColor(bmp, Color.FromArgb(207, 255, 255), Color.FromArgb(Convert.ToInt32(_colorR), Convert.ToInt32(_colorG), Convert.ToInt32(_colorB)));
            metode.SwapColor(bmp, Color.FromArgb(174, 251, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.19)), Convert.ToInt32(Math.Round(_colorG / 1.0159)), Convert.ToInt32(_colorB)));
            metode.SwapColor(bmp, Color.FromArgb(143, 234, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.448)), Convert.ToInt32(Math.Round(_colorG / 1.0897)), Convert.ToInt32(_colorG)));
            metode.SwapColor(bmp, Color.FromArgb(96, 205, 239), Color.FromArgb(Convert.ToInt32(_colorR / 2.15625), Convert.ToInt32(_colorG / 1.2439), Convert.ToInt32(_colorB / 1.0661)));
            metode.SwapColor(bmp, Color.FromArgb(73, 194, 214), Color.FromArgb(Convert.ToInt32(_colorR / 2.8356), Convert.ToInt32(_colorG / 1.3113), Convert.ToInt32(_colorB / 1.1911)));
            metode.SwapColor(bmp, Color.FromArgb(50, 173, 186), Color.FromArgb(Convert.ToInt32(_colorR / 4.14), Convert.ToInt32(_colorG / 1.4734), Convert.ToInt32(_colorB / 1.3672)));

            // Save the modified image
            bmp.Save(@"fishpng\\fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //reprendre l'image après l'avoir changer
            using (var bmpTemp = new Bitmap("fishpng\\fish" + _id + ".png"))
            {
                JellyFishImage = new Bitmap(bmpTemp);
            }




            bmp = new Bitmap(originaljellyfish2);

            metode.SwapColor(bmp, Color.FromArgb(207, 255, 255), Color.FromArgb(Convert.ToInt32(_colorR), Convert.ToInt32(_colorG), Convert.ToInt32(_colorB)));
            metode.SwapColor(bmp, Color.FromArgb(174, 251, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.19)), Convert.ToInt32(Math.Round(_colorG / 1.0159)), Convert.ToInt32(_colorB)));
            metode.SwapColor(bmp, Color.FromArgb(143, 234, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.448)), Convert.ToInt32(Math.Round(_colorG / 1.0897)), Convert.ToInt32(_colorG)));
            metode.SwapColor(bmp, Color.FromArgb(96, 205, 239), Color.FromArgb(Convert.ToInt32(_colorR / 2.15625), Convert.ToInt32(_colorG / 1.2439), Convert.ToInt32(_colorB / 1.0661)));
            metode.SwapColor(bmp, Color.FromArgb(73, 194, 214), Color.FromArgb(Convert.ToInt32(_colorR / 2.8356), Convert.ToInt32(_colorG / 1.3113), Convert.ToInt32(_colorB / 1.1911)));
            metode.SwapColor(bmp, Color.FromArgb(50, 173, 186), Color.FromArgb(Convert.ToInt32(_colorR / 4.14), Convert.ToInt32(_colorG / 1.4734), Convert.ToInt32(_colorB / 1.3672)));

            // Save the modified image
            bmp.Save(@"fishpng\\f2sh" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //reprendre l'image après l'avoir changer
            using (var bmpTemp = new Bitmap("fishpng\\f2sh" + _id + ".png"))
            {
                JellyFishImage2 = new Bitmap(bmpTemp);
            }







            //set image hight and width (for hitbox)
            _height = (JellyFishImage2.Height / 2);
            _width = (JellyFishImage2.Width / 2);



            //set pos to ramdom location

            _y = GlobalHelpers.alea.Next(0, 600);

            _x = GlobalHelpers.alea.Next(0, 1200);



            _id = i;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }
        public bool IsPnj { get { return _IsPnj; } }

        public int Height { get { return _height; } }
        public int Width { get { return _width; } }

        public double ColorR { get => _colorR; set => _colorR = value; }
        public double ColorG { get => _colorG; set => _colorG = value; }
        public double ColorB { get => _colorB; set => _colorB = value; }
        public int V { get => v; set => v = value; }
        public int Helth { get => _helth; set => _helth = value; }
        public int Id { get => _id; set => _id = value; }
        public int Size { get => _size; set => _size = value; }

        private int v = 0;
        int s = 0;
        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update()
        {
            if (!AirSpace.TalkingToPng)
            {


                if (_stage <= _speed)
                {
                    _stage++;

                    if (v ==  0)
                    {
                        v++;
                    }



                }
                else if (_stage == _speed)
                {
                    _stage++;
                    _y--;
                }
                else if (_stage > _speed)
                {
                    if (v == 1)
                    {
                        v--;
                    }

                    _y -= (_speed + _speed - _stage);


                    if ((_stage - _speed) <= s)
                    {
                        s = 0;
                        _stage++;
                    }

                    s++;

                    if ((_speed + _speed) <= _stage)
                        _stage = (0 - _speed);
                }



                if (_y <= -100)
                {
                    if (AirSpace.SharkEvent && AirSpace.EventTime > 1000)
                    {
                        _y = -300;
                    }
                    else
                    {

                        //is png
                        if ((GlobalHelpers.alea.Next(0, 25)) == 0)
                        {
                            _IsPnj = true;
                            _name = metode.RandomName();
                            _speed = GlobalHelpers.alea.Next(10, 14);
                        }
                        else
                        {
                            _IsPnj = false;
                            _name = "";
                            _speed = GlobalHelpers.alea.Next(10, 14);
                        }


                        _stage = 0 - _speed;

                        //changer la taile du jellyfish
                        for (_size = 5; _size < 16; _size++)
                        {
                            if (GlobalHelpers.alea.Next(1, 4) == 2)
                            {
                                originaljellyfish = Image.FromFile($"originalfish\\jellyf1sh" + _size + ".png");
                                originaljellyfish2 = Image.FromFile($"originalfish\\jellyf2sh" + _size + ".png");
                                _helth = _size;
                                break;
                            }

                        }

                        _height = (originaljellyfish.Height / 2);
                        _width = (originaljellyfish.Width / 2);



                        _y = 700;
                        _x = GlobalHelpers.alea.Next(0, 1200); ;

                        //changer l'image du poisson
                        // Load the bitmap
                        var bmp = new Bitmap(originaljellyfish);

                        // Perform color swapping
                        _colorR = GlobalHelpers.alea.Next(0, 256);
                        _colorG = GlobalHelpers.alea.Next(0, 256);
                        _colorB = GlobalHelpers.alea.Next(0, 256);


                        metode.SwapColor(bmp, Color.FromArgb(207, 255, 255), Color.FromArgb(Convert.ToInt32(_colorR), Convert.ToInt32(_colorG), Convert.ToInt32(_colorB)));
                        metode.SwapColor(bmp, Color.FromArgb(174, 251, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.19)), Convert.ToInt32(Math.Round(_colorG / 1.0159)), Convert.ToInt32(_colorB)));
                        metode.SwapColor(bmp, Color.FromArgb(143, 234, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.448)), Convert.ToInt32(Math.Round(_colorG / 1.0897)), Convert.ToInt32(_colorG)));
                        metode.SwapColor(bmp, Color.FromArgb(96, 205, 239), Color.FromArgb(Convert.ToInt32(_colorR / 2.15625), Convert.ToInt32(_colorG / 1.2439), Convert.ToInt32(_colorB / 1.0661)));
                        metode.SwapColor(bmp, Color.FromArgb(73, 194, 214), Color.FromArgb(Convert.ToInt32(_colorR / 2.8356), Convert.ToInt32(_colorG / 1.3113), Convert.ToInt32(_colorB / 1.1911)));
                        metode.SwapColor(bmp, Color.FromArgb(50, 173, 186), Color.FromArgb(Convert.ToInt32(_colorR / 4.14), Convert.ToInt32(_colorG / 1.4734), Convert.ToInt32(_colorB / 1.3672)));

                        // Save the modified image
                        bmp.Save(@"fishpng\\fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("fishpng\\fish" + _id + ".png"))
                        {
                            JellyFishImage = new Bitmap(bmpTemp);
                        }

                        bmp = new Bitmap(originaljellyfish2);

                        metode.SwapColor(bmp, Color.FromArgb(207, 255, 255), Color.FromArgb(Convert.ToInt32(_colorR), Convert.ToInt32(_colorG), Convert.ToInt32(_colorB)));
                        metode.SwapColor(bmp, Color.FromArgb(174, 251, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.19)), Convert.ToInt32(Math.Round(_colorG / 1.0159)), Convert.ToInt32(_colorB)));
                        metode.SwapColor(bmp, Color.FromArgb(143, 234, 255), Color.FromArgb(Convert.ToInt32(Math.Round(_colorR / 1.448)), Convert.ToInt32(Math.Round(_colorG / 1.0897)), Convert.ToInt32(_colorG)));
                        metode.SwapColor(bmp, Color.FromArgb(96, 205, 239), Color.FromArgb(Convert.ToInt32(_colorR / 2.15625), Convert.ToInt32(_colorG / 1.2439), Convert.ToInt32(_colorB / 1.0661)));
                        metode.SwapColor(bmp, Color.FromArgb(73, 194, 214), Color.FromArgb(Convert.ToInt32(_colorR / 2.8356), Convert.ToInt32(_colorG / 1.3113), Convert.ToInt32(_colorB / 1.1911)));
                        metode.SwapColor(bmp, Color.FromArgb(50, 173, 186), Color.FromArgb(Convert.ToInt32(_colorR / 4.14), Convert.ToInt32(_colorG / 1.4734), Convert.ToInt32(_colorB / 1.3672)));

                        // Save the modified image
                        bmp.Save(@"fishpng\\f2sh" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("fishpng\\f2sh" + _id + ".png"))
                        {
                            JellyFishImage2 = new Bitmap(bmpTemp);
                        }


                    }


                }
            }

        }



    }
}
