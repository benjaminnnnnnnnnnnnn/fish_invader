namespace FishInvader
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Fish
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        public bool facing_left;
        private int _fishhight;
        private int _fishwidth;


        public Image FishImage { get; private set; }

        // Constructeur
        public Fish(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;



            FishImage = Image.FromFile("fish.png");

            FishImage = Image.FromFile("originalfish\\fish1.png");

            _fishhight = (FishImage.Height / 2);
            _fishwidth = (FishImage.Width / 2);

        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }

        public int Fishwidth { get { return _fishwidth; } }
        public int Fishhight { get { return _fishhight; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed, List<BadFish> badfleet)
        {
            bool moved = false;




            //hit box
            foreach (BadFish badfish in badfleet)
            {
                /*
                if ((_x - Fishwidth) >= (badfish.X - badfish.BadFishwidth) && (_y - Fishhight) >= (badfish.Y - badfish.BadFishhight)  && (_x + Fishwidth) <= (badfish.X + badfish.BadFishwidth) && (_y + Fishhight) <= (badfish.Y + badfish.BadFishhight))
                {
                    Console.Write("-1hp");

                }
                */
                if ((_x - _fishwidth) <= (badfish.X - badfish.BadFishwidth) && (_y - _fishhight) >= (badfish.Y - badfish.BadFishhight) ) 
                {
                    Console.Write("-1hp");
                }

            }


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


        }
    }
}