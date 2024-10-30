using System.Windows.Forms;

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
        private bool _isShop = false;
        private int _id;
        private int _width;
        private int _height;
        public static bool PnjTouch = false;
        public static bool ShopTouch = false;
        public static Image PressE = Image.FromFile("images/PressE.png");
        public static Image PressEdown = Image.FromFile("images/PressEdown.png");
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
        public Jellyfish(int i, int x, int y)
        {
            Jellyfishfilepath = $"images/originalfish/jellyf1sh1.png";
            Jellyfishfilepath2 = $"images/originalfish/jellyf2sh1.png";


            originaljellyfish = Image.FromFile(Jellyfishfilepath);
            originaljellyfish2 = Image.FromFile(Jellyfishfilepath2);










            //if badfish is a png
            if ((GlobalHelpers.alea.Next(0, 25)) == 0)
            {
                _IsPnj = true;
                _name = metode.RandomName();
                _speed = GlobalHelpers.alea.Next(10, 14);
            }
            else if ((GlobalHelpers.alea.Next(0, 25)) == 0)
            {
                _isShop = true;
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
            bmp.Save(@"fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //reprendre l'image après l'avoir changer
            using (var bmpTemp = new Bitmap("fish" + _id + ".png"))
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
            bmp.Save(@"f2sh" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //reprendre l'image après l'avoir changer
            using (var bmpTemp = new Bitmap("f2sh" + _id + ".png"))
            {
                JellyFishImage2 = new Bitmap(bmpTemp);
            }







            //set image hight and width (for hitbox)
            _size = GlobalHelpers.alea.Next(5, 16);
            _height = (JellyFishImage.Height * _size);
            _width = (JellyFishImage.Width * _size);

            _helth = _size;


            //set pos to ramdom location

            _y = y;

            _x = x;



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
        public bool IsShop { get => _isShop; set => _isShop = value; }

        private int v = 0;
        int s = 0;
        bool redo;
        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(List<Projectile> projectiles, Wepon wepon)
        {
            if (!AirSpace.TalkingToPng)
            {



                if (_stage <= _speed)
                {
                    _stage++;

                    if (v == 0)
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






                do
                {
                    redo = false;
                    foreach (Projectile projectile in projectiles)
                    {
                        if (!IsPnj && !IsShop)
                        {

                            if (Wepon.wepontype == 1 || Wepon.wepontype == 3 || Wepon.wepontype == 4 || Wepon.wepontype == 5 || Wepon.wepontype == 6)
                            {
                                if ((projectile.X - (projectile.Width / 2)) <= (_x + _width) && (projectile.Y - (projectile.Height / 2)) <= (_y + _height) && (projectile.X + (projectile.Width / 2)) >= _x && (projectile.Y + (projectile.Height / 2)) >= _y)
                                {

                                    Helth -= projectile.Damage;
                                    projectiles.Remove(projectile);
                                    redo = true;
                                    break;
                                }
                            }
                            else
                            {
                                if ((projectile.X - projectile.Slimewidth) <= (_x + _width) && (projectile.Y - projectile.Slimeheight) <= (_y + _height) && (projectile.X + projectile.Slimewidth) >= _x && (projectile.Y + projectile.Slimeheight) >= _y)
                                {

                                    Helth -= projectile.Damage;

                                    projectiles.Remove(projectile);
                                    redo = true;
                                    break;
                                }
                            }

                        }
                    }

                } while (redo);

                if (_y <= -200)
                {
                    if (AirSpace.eventtype == 0 && AirSpace.ramdomEvent && AirSpace.EventTime > 1000)
                    {
                        _y = -300;
                    }
                    else
                    {

                        //is png
                        if ((GlobalHelpers.alea.Next(0, 25)) == 0)
                        {
                            _isShop = false;
                            _IsPnj = true;
                            _name = metode.RandomName();
                            _speed = GlobalHelpers.alea.Next(10, 14);
                        }
                        else if ((GlobalHelpers.alea.Next(0, 20)) == 0)
                        {
                            _IsPnj = false;
                            _isShop = true;
                            _name = metode.RandomName();
                            _speed = GlobalHelpers.alea.Next(10, 14);
                        }
                        else
                        {
                            _isShop = false;
                            _IsPnj = false;
                            _name = "";
                            _speed = GlobalHelpers.alea.Next(10, 14);
                        }


                        _stage = 0 - _speed;

                        //changer la taile du jellyfish
                        _size = GlobalHelpers.alea.Next(5, 16);
                        _height = (JellyFishImage.Height * _size);
                        _width = (JellyFishImage.Width * _size);
                        _helth = _size;



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
                        bmp.Save(@"fish" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("fish" + _id + ".png"))
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
                        bmp.Save(@"f2sh" + _id + ".png", System.Drawing.Imaging.ImageFormat.Png);


                        //reprendre l'image après l'avoir changer
                        using (var bmpTemp = new Bitmap("f2sh" + _id + ".png"))
                        {
                            JellyFishImage2 = new Bitmap(bmpTemp);
                        }


                    }


                }
            }
        }

    }




}
