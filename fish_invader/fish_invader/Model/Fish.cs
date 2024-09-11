namespace FishInvader
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Fish
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien

        // Constructeur
        public Fish(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
            _charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed)
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
            }

            if (moveRight)
            {
                _x += speed;
                moved = true;
            }

            // Décharge de la batterie uniquement si le drone bouge
            if (moved)
            {
                _charge--;
            }
        }
    }
}