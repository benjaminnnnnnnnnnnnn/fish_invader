using fish_invader;

namespace FishInvader
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Fish
    {
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        public static bool facing_left;
        private int _height;
        private int _width;
        public int helth = 100;
        public static bool pressingE = false;
        //public PictureBox fishpicture;
        public static int touchingPngId;
        public static int touchingjellyPngId;
        private int _gold = 0;


        public Image FishImage { get; private set; }

        // Constructeur
        public Fish(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;

            FishImage = Image.FromFile("originalfish\\f2sh1.png");

            _height = (FishImage.Height / 2);
            _width = (FishImage.Width / 2);

            //hitbox
            //fishpicture = new PictureBox();
            //fishpicture.Image = FishImage;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }

        public int Height { get { return _height; } }
        public int Width { get { return _width; } }

        public int Gold { get => _gold; set => _gold = value; }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed, List<BadFish> badfleet, Event Event, List<Jellyfish> jellyfleet, List<Heart> hearts, List<Gold> golds)
        {
            bool moved = false;

            if (!AirSpace.TalkingToPng)
            {

                if (!((_y - _height) <= 2))
                {
                    if (moveUp)
                    {
                        _y -= speed;
                        moved = true;
                    }
                }

                if (!((_y + _height) >= 598))
                {
                    if (moveDown)
                    {
                        _y += speed;
                        moved = true;
                    }
                }

                if (!((_x - _width) <= 2))
                {
                    if (moveLeft)
                    {
                        _x -= speed;
                        moved = true;
                        facing_left = true;
                    }
                }

                if (!((_x - _width) >= 1163))
                {
                    if (moveRight)
                    {
                        _x += speed;
                        moved = true;
                        facing_left = false;
                    }
                }

                BadFish.ShopTouch = false;
                BadFish.PnjTouch = false;
                //if touch png
                touchingPngId = 0;
                foreach (BadFish badfish in badfleet)
                {
                    touchingPngId++;
                    if (badfish.IsPnj || badfish.IsShop)
                    {
                        if ((badfish.X - badfish.Width) <= (_x + _width) && (badfish.Y - badfish.Height) <= (_y + _height) && (badfish.X + badfish.Width) >= (_x - _width) && (badfish.Y + badfish.Height) >= (_y - _height))
                        {

                            if (badfish.IsPnj)
                                BadFish.PnjTouch = true;
                            else
                                BadFish.ShopTouch = true;
                            break;
                        }


                    }

                }



                //if touch badfish
                foreach (BadFish badfish in badfleet)
                {

                    if (!badfish.IsPnj && !badfish.IsShop)
                    {
                        if ((badfish.X - badfish.Width) <= (_x + _width) && (badfish.Y - badfish.Height) <= (_y + _height) && (badfish.X + badfish.Width) >= (_x - _width) && (badfish.Y + badfish.Height) >= (_y - _height))
                        {
                            helth--;
                        }


                    }

                }


                Jellyfish.PnjTouch = false;
                //if touch png
                touchingjellyPngId = 0;
                foreach (Jellyfish jellyfish in jellyfleet)
                {
                    touchingjellyPngId++;
                    if (jellyfish.IsPnj)
                    {
                        if ((jellyfish.X - jellyfish.Width) <= (_x + _width) && (jellyfish.Y - jellyfish.Height) <= (_y + _height) && (jellyfish.X + jellyfish.Width) >= (_x - _width) && (jellyfish.Y + jellyfish.Height) >= (_y - _height))
                        {

                            Jellyfish.PnjTouch = true;
                            break;
                        }


                    }
                }

                //if touch badfish
                foreach (Jellyfish jellyfish in jellyfleet)
                {

                    if (!jellyfish.IsPnj)
                    {
                        if ((jellyfish.X - jellyfish.Width) <= (_x + _width) && (jellyfish.Y - jellyfish.Height) <= (_y + _height) && (jellyfish.X + jellyfish.Width) >= (_x - _width) && (jellyfish.Y + jellyfish.Height) >= (_y - _height))
                        {
                            helth--;
                        }


                    }

                }

                foreach (Heart heart in hearts)
                {

                    if ((heart.X - heart.Width) <= (_x + _width) && (heart.Y - heart.Height) <= (_y + _height) && (heart.X + heart.Width) >= (_x - _width) && (heart.Y + heart.Height) >= (_y - _height))
                    {
                        if (helth >= 95)
                            helth = 100;
                        else
                            helth += heart.Amount;
                        hearts.Remove(heart);
                        hearts.Add(new Heart());
                        break;
                    }

                }

                foreach (Gold gold in golds)
                {

                    if ((gold.X - gold.Width) <= (_x + _width) && (gold.Y - gold.Height) <= (_y + _height) && (gold.X + gold.Width) >= (_x - _width) && (gold.Y + gold.Height) >= (_y - _height))
                    {

                        _gold += gold.Amount;
                        Console.WriteLine(_gold);
                        golds.Remove(gold);
                        break;
                    }

                }


                //if touch shark event
                if (AirSpace.eventtype == 0 && AirSpace.ramdomEvent && AirSpace.EventTime >= 1000)
                {


                    if ((Event.x - Event.Widths1) <= (_x + _width) && (200 - Event.Heights1) <= (_y + _height) && (Event.x + Event.Widths1) >= (_x - _width) && (200 + Event.Heights1) >= (_y - _height) && Event.Health1 > 0)
                    {

                        helth -= 1;
                    }


                    if ((Event.x2 - Event.Widths2) <= (_x + _width) && (400 - Event.Heights2) <= (_y + _height) && (Event.x2 + Event.Widths2) >= (_x - _width) && (400 + Event.Heights2) >= (_y - _height) && Event.Health2 > 0)
                    {
                        helth -= 1;

                    }

                    if ((Event.x3 - Event.Widths3) <= (_x + _width) && (475 - Event.Heights3) <= (_y + _height) && (Event.x3 + Event.Widths3) >= (_x - _width) && (475 + Event.Heights3) >= (_y - _height) && Event.Health3 > 0)
                    {
                        helth -= 1;

                    }


                }

                if (AirSpace.eventtype == 1 && AirSpace.ramdomEvent)
                {

                    //bottom
                    if ((Event.Whaley + Event.Heightwhale - 55) >= (_y - _height) && (Event.Whalex + Event.Widthwhale - 15) >= (_x - _width) && (Event.Whalex - Event.Widthwhale + 15) <= (_x + _width) && moveUp)
                        _y = ((Event.Whaley + Event.Heightwhale) - 55);

                    //left
                    if ((Event.Whalex + Event.Widthwhale) >= (_x - _width) && (Event.Whaley + Event.Heightwhale - 55) >= (_y + _height) && (Event.Whalex - Event.Widthwhale + 100) <= (_x + _width))
                        _x = ((Event.Whalex + Event.Widthwhale) + 8);

                    //right
                    if ((Event.Whalex + Event.Widthwhale - 100) >= (_x - _width) && (Event.Whaley + Event.Heightwhale - 55) >= (_y + _height) && (Event.Whalex - Event.Widthwhale) <= (_x + _width))
                        _x = ((Event.Whalex - Event.Widthwhale) - 8);

                    if (_x >= 1200)
                    {
                        _x = 1167;
                        _y = ((Event.Whaley + Event.Heightwhale) - 55);
                    }



                }
            }



        }
    }
}