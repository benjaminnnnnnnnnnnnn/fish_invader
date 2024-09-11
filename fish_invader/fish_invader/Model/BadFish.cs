using FishInvader.Helpers;
using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishInvader
{
    public partial class BadFish
    {

        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private string _name;
        private int _speed;

        // Constructeur
        public BadFish(string name)
        {

            _x = GlobalHelpers.alea.Next(0,1200);
            _y = GlobalHelpers.alea.Next(0,200);
            _name = name;
            _speed = GlobalHelpers.alea.Next(1, 6);
            

        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }


        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update()
        {
            _x += _speed;



            if (_x >= 1200)
            {
                _x = 0;
                _y = GlobalHelpers.alea.Next(0, 200);
                _speed = GlobalHelpers.alea.Next(1, 6);
            }
           
        }



    }
}
