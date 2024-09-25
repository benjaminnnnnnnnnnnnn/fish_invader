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

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed, List<BadFish> badfleet, List<Event> events, List<Jellyfish> jellyfleet)
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

                if (!((_x - _width) >= 1180))
                {
                    if (moveRight)
                    {
                        _x += speed;
                        moved = true;
                        facing_left = false;
                    }
                }

                BadFish.PnjTouch = false;
                //if touch png
                touchingPngId = 0;
                foreach (BadFish badfish in badfleet)
                {
                    touchingPngId++;
                    if (badfish.IsPnj)
                    {
                        if ((badfish.X - badfish.Width) <= (_x + _width) && (badfish.Y - badfish.Height) <= (_y + _height) && (badfish.X + badfish.Width) >= (_x - _width) && (badfish.Y + badfish.Height) >= (_y - _height))
                        {
                            
                            BadFish.PnjTouch = true;
                            break;
                        }


                    }

                }

                //if touch badfish
                foreach (BadFish badfish in badfleet)
                {

                    if (!badfish.IsPnj)
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



                //if touch shark event
                if (AirSpace.SharkEvent && AirSpace.EventTime >= 1000)
                {
                    foreach (Event e in events)
                    {
                        if ((e.x - e.Shark1.Width) <= (_x + _width) && (200 - e.Shark1.Height) <= (_y + _height) && (e.x + e.Shark1.Width) >= (_x - _width) && (200 + e.Shark1.Height) >= (_y - _height))
                        {
                            Console.Write("-1hp");

                        }


                        if ((e.x - e.Shark2.Width) <= (_x + _width) && (400 - e.Shark2.Height) <= (_y + _height) && (e.x + e.Shark2.Width) >= (_x - _width) && (400 + e.Shark2.Height) >= (_y - _height))
                        {
                            Console.Write("-1hp");

                        }

                        if ((e.x - e.Babyshark.Width) <= (_x + _width) && (475 - e.Babyshark.Height) <= (_y + _height) && (e.x + e.Babyshark.Width) >= (_x - _width) && (475 + e.Babyshark.Height) >= (_y - _height))
                        {
                            Console.Write("-1hp");

                        }

                    }
                }
            }



        }
    }
}