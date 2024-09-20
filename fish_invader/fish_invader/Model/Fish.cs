namespace FishInvader
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Fish
    {
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        public bool facing_left;
        private int _height;
        private int _width;
        public int helth;
        //public PictureBox fishpicture;


        public Image FishImage { get; private set; }

        // Constructeur
        public Fish(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;

            FishImage = Image.FromFile("originalfish\\fish1.png");

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
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed, List<BadFish> badfleet)
        {
            bool moved = false;

            if (moveUp)
            {
                _y -= speed;
                moved = true;
            }

            if (moveDown)
            {
                _y += speed;
                moved = true;
            }

            if (moveLeft)
            {
                _x -= speed;
                moved = true;
                facing_left = true;
            }

            if (moveRight)
            {
                _x += speed;
                moved = true;
                facing_left = false;
            }

            int i = 0;
            foreach (BadFish badfish in badfleet)
            {


                if (badfish.IsPnj && i == 0)
                {
                    if ((badfish.X - badfish.Width) <= (_x + _width) && (badfish.Y - badfish.Height) <= (_y + _height) && (badfish.X + badfish.Width) >= (_x - _width) && (badfish.Y + badfish.Height) >= (_y - _height))
                    {
                        BadFish.PnjTouch = true;
                        i = 1;


                    }
                    else
                    {
                        BadFish.PnjTouch = false;
                    }



                }
                else
                {
                    if ((badfish.X - badfish.Width) <= (_x + _width) && (badfish.Y - badfish.Height) <= (_y + _height) && (badfish.X + badfish.Width) >= (_x - _width) && (badfish.Y + badfish.Height) >= (_y - _height))
                    {
                        Console.Write("-1hp");

                    }

                }

                
            }
        }
    }
}