﻿using fish_invader;

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
        public static bool isportected = false;


        public Image FishImage { get; private set; }

        // Constructeur
        public Fish(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;

            FishImage = Image.FromFile("images/originalfish/f2sh1.png");

            _height = (FishImage.Height * 2);
            _width = (FishImage.Width * 2);

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
        public void Update(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, int speed, List<BadFish> badfleet, Event Event, List<Jellyfish> jellyfleet, List<Heart> hearts, List<Gold> golds,List<Kelp> kelps)
        {
            bool moved = false;

            if (!AirSpace.TalkingToPng)
            {

                if (!(_y <= 0))
                {
                    if (moveUp)
                    {
                        _y -= speed;
                        moved = true;
                    }
                }

                if (!((_y + _height) >= 600))
                {
                    if (moveDown)
                    {
                        _y += speed;
                        moved = true;
                    }
                }

                if (!(_x <= 0))
                {
                    if (moveLeft)
                    {
                        _x -= speed;
                        moved = true;
                        facing_left = true;
                    }
                }

                if (!((_x + _width) >= 1200))
                {
                    if (moveRight)
                    {
                        _x += speed;
                        moved = true;
                        facing_left = false;
                    }
                }

                isportected = false;
                foreach (Kelp kelp in kelps)
                {
                    if (kelp.X <= (_x + Width) && kelp.Y <= (_y + _height) && (kelp.X + kelp.Width) >= _x && (kelp.Y + kelp.Height) >= _y)
                    {
                        isportected = true;
                        break;
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
                        if ((badfish.X - (badfish.Width / badfish.Size - 15)) <= (_x + _width) && (badfish.Y - (badfish.Height / badfish.Size - 10)) <= (_y + _height) && (badfish.X + badfish.Width) >= _x && (badfish.Y + badfish.Height) >= _y)
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

                    if (!badfish.IsPnj && !badfish.IsShop && !isportected)
                    {
                        if ((badfish.X - (badfish.Width / badfish.Size - 15)) <= (_x + _width) && (badfish.Y - (badfish.Height / badfish.Size - 10)) <= (_y + _height) && (badfish.X + badfish.Width) >= _x && (badfish.Y + badfish.Height) >= _y)
                        {
                            helth--;
                        }


                    }

                }

                Jellyfish.ShopTouch = false;
                Jellyfish.PnjTouch = false;
                //if touch png
                touchingjellyPngId = 0;
                foreach (Jellyfish jellyfish in jellyfleet)
                {
                    touchingjellyPngId++;
                    if (jellyfish.IsPnj || jellyfish.IsShop)
                    {
                        if ((jellyfish.X - (jellyfish.Width / jellyfish.Size - 15)) <= (_x + _width) && (jellyfish.Y - (jellyfish.Height / jellyfish.Size - 10)) <= (_y + _height) && (jellyfish.X + jellyfish.Width) >= _x && (jellyfish.Y + jellyfish.Height) >= _y)
                        {
                            if (jellyfish.IsPnj)
                                Jellyfish.PnjTouch = true;
                            else
                                Jellyfish.ShopTouch = true;
                            break;
                        }


                    }
                }

                //if touch badfish
                foreach (Jellyfish jellyfish in jellyfleet)
                {

                    if (!jellyfish.IsPnj && !jellyfish.IsShop && !isportected)
                    {
                        if ((jellyfish.X - (jellyfish.Width / jellyfish.Size - 15)) <= (_x + _width) && (jellyfish.Y - (jellyfish.Height / jellyfish.Size - 10)) <= (_y + _height) && (jellyfish.X + jellyfish.Width) >= _x && (jellyfish.Y + jellyfish.Height) >= _y)
                        {
                            helth--;
                        }


                    }

                }

                foreach (Heart heart in hearts)
                {

                    if ((heart.X - heart.Width) <= (_x + _width) && (heart.Y - heart.Height) <= (_y + _height) && (heart.X + heart.Width) >= _x && (heart.Y + heart.Height) >= _y)
                    {

                        helth += heart.Amount;
                        if (helth > 100)
                            helth = 100;
                        hearts.Remove(heart);
                        hearts.Add(new Heart());
                        break;
                    }

                }

                foreach (Gold gold in golds)
                {

                    if ((gold.X - gold.Width) <= (_x + _width) && (gold.Y - gold.Height) <= (_y + _height) && (gold.X + gold.Width) >= _x && (gold.Y + gold.Height) >= _y)
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


                    if ((Event.x - Event.Widths1) <= (_x + _width) && (200 - Event.Heights1) <= (_y + _height) && (Event.x + Event.Widths1) >= _x && (200 + Event.Heights1) >= _y && Event.Health1 > 0)
                    {

                        helth -= 1;
                    }


                    if ((Event.x2 - Event.Widths2) <= (_x + _width) && (400 - Event.Heights2) <= (_y + _height) && (Event.x2 + Event.Widths2) >= _x && (400 + Event.Heights2) >= _y && Event.Health2 > 0)
                    {
                        helth -= 1;

                    }

                    if ((Event.x3 - Event.Widths3) <= (_x + _width) && (475 - Event.Heights3) <= (_y + _height) && (Event.x3 + Event.Widths3) >= _x && (475 + Event.Heights3) >= _y && Event.Health3 > 0)
                    {
                        helth -= 1;

                    }


                }

                if (AirSpace.eventtype == 1 && AirSpace.ramdomEvent)
                {

                    //bottom
                    if ((Event.Whaley + Event.Heightwhale - 55) >= _y && (Event.Whalex + Event.Widthwhale - 15) >= _x && (Event.Whalex - Event.Widthwhale + 15) <= (_x + _width) && moveUp)
                        _y = ((Event.Whaley + Event.Heightwhale) - 55);

                    //left
                    if ((Event.Whalex + Event.Widthwhale) >= _x && (Event.Whaley + Event.Heightwhale - 55) >= (_y + _height) && (Event.Whalex - Event.Widthwhale + 100) <= (_x + _width))
                        _x = ((Event.Whalex + Event.Widthwhale) + 2);

                    //right
                    if ((Event.Whalex + Event.Widthwhale - 100) >= _x && (Event.Whaley + Event.Heightwhale - 55) >= (_y + _height) && (Event.Whalex - Event.Widthwhale) <= (_x + _width))
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