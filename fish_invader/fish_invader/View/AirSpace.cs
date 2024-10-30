using fish_invader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FishInvader
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public static int WIDTH = 1200;        // Dimensions de l'espace aérien
        public static int HEIGHT = 600;

        Shop shop = new Shop();
        Quest quest = new Quest();
        Event Event = new Event();

        private List<Projectile> projectiles = new List<Projectile>();
        private List<Kelp> kelps = new List<Kelp>();
        private List<Gold> golds = new List<Gold>();
        private List<Heart> hearts = new List<Heart>();
        private List<turet> turets = new List<turet>();
        Wepon wepon = new Wepon();
        private List<Jellyfish> jellyfleet;
        Fish fish = new Fish(AirSpace.WIDTH / 2, AirSpace.HEIGHT / 2, "Fish");

        private List<BadFish> badfleet;               //flotte de machant poison
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics airspace;

        public static int eventtype;

        public static int questamount;
        public static bool DoingQuest = false;
        public static bool TalkingToPng = false;
        public static int QuestType;
        public static int dialogNum = 0;

        private bool won = false;

        // Variables pour les mouvements
        private bool moveUp, moveDown, moveLeft, moveRight;
        private const int MOVE_SPEED = 3; // Vitesse de déplacement du drone

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<BadFish> badfleet, List<Jellyfish> jellyfleet) : base()
        {
            InitializeComponent();


            this.badfleet = badfleet;
            this.jellyfleet = jellyfleet;

            hearts.Add(new Heart());
            hearts.Add(new Heart());
            hearts.Add(new Heart());

            kelps.Add(new Kelp(GlobalHelpers.alea.Next(0, 1200), GlobalHelpers.alea.Next(0, 600), GlobalHelpers.alea.Next(3, 7)));
            kelps.Add(new Kelp(GlobalHelpers.alea.Next(0, 1200), GlobalHelpers.alea.Next(0, 600), GlobalHelpers.alea.Next(3, 7)));


            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;

            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            // Gestion des touches clavier
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);

            // Rendre le formulaire focusable pour les événements clavier
            this.KeyPreview = true;

            SetbackgroundImage();
        }

        private Image background;
        public void SetbackgroundImage()
        {

            background = Image.FromFile("../../../images/otherimage/background.png");
            BackgroundImage = background;
        }

        public static bool reloding = false;
        int r = 0;
        int f = 0;
        public static int progectilcapacity = 12;
        private int lastwepontype;
        // Gestion des appuis sur les touches clavier
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (BadFish.ShopTouch && TalkingToPng || Jellyfish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionY > 0)
                        shop.selectionY--;

                }
                else
                    moveUp = true;
            }

            if (e.KeyCode == Keys.S)
            {
                if (BadFish.ShopTouch && TalkingToPng || Jellyfish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionY < 2)
                        shop.selectionY++;

                }
                else
                    moveDown = true;
            }

            if (e.KeyCode == Keys.A)
            {
                if (BadFish.ShopTouch && TalkingToPng || Jellyfish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionX > 0)
                        shop.selectionX--;

                }
                else
                    moveLeft = true;
            }

            if (e.KeyCode == Keys.D)
            {
                if (BadFish.ShopTouch && TalkingToPng || Jellyfish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionX < 4)
                        shop.selectionX++;

                }
                else
                    moveRight = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (TalkingToPng && BadFish.ShopTouch || Jellyfish.ShopTouch && TalkingToPng)
                {
                    TalkingToPng = false;

                }
                else
                    Environment.Exit(0);
            }
            if (e.KeyCode == Keys.E)
            {
                if (dialogNum == 1)
                {
                }
                else if (TalkingToPng && dialogNum < 2 && !BadFish.ShopTouch && !Jellyfish.ShopTouch)
                    dialogNum++;

                if (BadFish.PnjTouch && dialogNum == 0 && !DoingQuest || Jellyfish.PnjTouch && dialogNum == 0 && !DoingQuest)
                {
                    Console.WriteLine("give quest");
                    Fish.pressingE = true;
                    DoingQuest = true;
                    TalkingToPng = true;

                    QuestType = GlobalHelpers.alea.Next(0, 4);
                    if (QuestType == 0)
                        questamount = GlobalHelpers.alea.Next(50, 151);
                    else if (QuestType == 1)
                        questamount = GlobalHelpers.alea.Next(10, 61);
                    else if (QuestType == 2)
                        questamount = GlobalHelpers.alea.Next(5, 31);
                    else if (QuestType == 3)
                        questamount = GlobalHelpers.alea.Next(15, 45);
                }

                //choix de quette
                if (dialogNum == 3)
                {
                    TalkingToPng = false;
                    dialogNum = 0;
                    Quest.numberoffish = 0;

                }
                if (dialogNum == 2)
                {
                    TalkingToPng = false;
                    DoingQuest = false;
                    dialogNum = 0;
                }

                if (BadFish.ShopTouch && TalkingToPng || Jellyfish.ShopTouch && TalkingToPng)
                {
                    if (shop.selectionX == 0 && shop.selectionY == 0 && fish.Gold >= shop.price[0, 0])
                    {
                        fish.Gold -= shop.price[0, 0];
                        Wepon.wepontype = 1;
                        lastwepontype = 1;
                        progectilcapacity = 12;
                        wepon.Damage = 2;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 1 && shop.selectionY == 0 && fish.Gold >= shop.price[0, 1])
                    {
                        fish.Gold -= shop.price[0, 1];
                        Wepon.wepontype = 2;
                        lastwepontype = 2;
                        progectilcapacity = 32;
                        wepon.Damage = 1;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 2 && shop.selectionY == 0 && fish.Gold >= shop.price[0, 2])
                    {
                        fish.Gold -= shop.price[0, 2];
                        fish.helth = 100;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 3 && shop.selectionY == 0 && fish.Gold >= shop.price[0, 3])
                    {
                        fish.Gold -= shop.price[0, 3];
                        Wepon.wepontype = 3;
                        lastwepontype = 3;
                        progectilcapacity = 5;
                        wepon.Damage = 1;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 4 && shop.selectionY == 0 && fish.Gold >= shop.price[0, 4])
                    {
                        fish.Gold -= shop.price[0, 4];
                        Wepon.wepontype = 4;
                        lastwepontype = 4;
                        progectilcapacity = 50;
                        wepon.Damage = 2;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 0 && shop.selectionY == 1 && fish.Gold >= shop.price[1, 0])
                    {
                        fish.Gold -= shop.price[1, 0];
                        Wepon.wepontype = 5;
                        lastwepontype = 5;
                        progectilcapacity = 100;
                        wepon.Damage = 1;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 1 && shop.selectionY == 1 && fish.Gold >= shop.price[1, 1])
                    {
                        fish.Gold -= shop.price[1, 1];
                        Wepon.wepontype = 6;
                        lastwepontype = 6;
                        progectilcapacity = 5;
                        wepon.Damage = 150;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 2 && shop.selectionY == 1 && fish.Gold >= shop.price[1, 2])
                    {
                        fish.Gold -= shop.price[1, 2];
                        Wepon.wepontype = 7;
                        progectilcapacity = 0;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 3 && shop.selectionY == 1 && fish.Gold >= shop.price[1, 3])
                    {
                        fish.Gold -= shop.price[1, 3];
                        Wepon.wepontype = 8;
                        progectilcapacity = 0;
                        TalkingToPng = false;
                    }
                    else if (shop.selectionX == 4 && shop.selectionY == 2 && fish.Gold >= shop.price[2, 4])
                    {
                        fish.Gold -= shop.price[2, 4];

                        TalkingToPng= false;
                        won = true;
                        badfleet.Clear();
                        jellyfleet.Clear();
                    }

                }
                else if (BadFish.ShopTouch || Jellyfish.ShopTouch)
                {
                    Console.WriteLine("Shopping");
                    Fish.pressingE = true;
                    TalkingToPng = true;

                }
            }
            if (e.KeyCode == Keys.N)
            {
                if (dialogNum == 1 && TalkingToPng)
                    dialogNum = 2;


            }
            if (e.KeyCode == Keys.Y)
            {
                if (dialogNum == 1 && TalkingToPng)
                    dialogNum = 3;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (!TalkingToPng)
                {
                    Wepon.hiting = true;
                    if (Wepon.wepontype == 0 && !Fish.isportected)
                    {
                        foreach (BadFish badfish in badfleet)
                        {

                            if (!badfish.IsPnj && !badfish.IsShop)
                            {

                                if (badfish.X <= (wepon.X + wepon.Width) && badfish.Y <= (wepon.Y + wepon.Height) && (badfish.X + badfish.Width) >= (wepon.X - wepon.Width) && (badfish.Y + badfish.Height) >= (wepon.Y - wepon.Height))
                                {
                                    Console.WriteLine("-1 badfish hp");
                                    badfish.helth -= wepon.Damage;
                                }


                            }

                        }
                        //if touch badfish
                        foreach (Jellyfish jellyfish in jellyfleet)
                        {

                            if (!jellyfish.IsPnj)
                            {
                                if (jellyfish.X <= (wepon.X + wepon.Width) && jellyfish.Y <= (wepon.Y + wepon.Height) && (jellyfish.X + jellyfish.Width) >= (wepon.X - wepon.Width) && (jellyfish.Y + jellyfish.Height) >= (wepon.Y - wepon.Height))
                                {
                                    Console.WriteLine("-1 jellyfish hp");
                                    jellyfish.Helth -= wepon.Damage;
                                }


                            }

                        }
                    }
                    else if (Wepon.wepontype == 1 && !reloding && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            projectiles.Add(new Projectile(fish.X, fish.Y,wepon.Damage, 1, fish));
                            progectilcapacity--;
                        }
                    }
                    else if (Wepon.wepontype == 2 && !reloding && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            projectiles.Add(new Projectile(fish.X, fish.Y,wepon.Damage,2, fish));
                            progectilcapacity--;
                        }
                    }
                    else if (Wepon.wepontype == 3 && !reloding && f == 0 && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            for (int k = 0; k <= GlobalHelpers.alea.Next(15,35); k++)
                                projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage,3, fish));
                            progectilcapacity--;
                            f++;
                        }
                    }
                    else if (Wepon.wepontype == 4 && !reloding && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage,4, fish));
                            progectilcapacity--;
                        }
                    }
                    else if (Wepon.wepontype == 5 && !reloding && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage,5, fish));
                            progectilcapacity--;
                        }
                    }
                    else if (Wepon.wepontype == 6 && !reloding && !Fish.isportected)
                    {
                        if (progectilcapacity >= 1)
                        {
                            projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage,6, fish));
                            progectilcapacity--;
                        }
                    }
                    else if (Wepon.wepontype == 7)
                    {
                        turets.Add(new turet(fish.X,fish.Y));

                        if (lastwepontype == 1)
                        {
                            Wepon.wepontype = 1;
                            progectilcapacity = 12;
                            wepon.Damage = 2;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 2)
                        {
                            Wepon.wepontype = 2;
                            progectilcapacity = 32;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 3)
                        {
                            Wepon.wepontype = 3;
                            progectilcapacity = 5;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 4)
                        {
                            Wepon.wepontype = 4;
                            progectilcapacity = 50;
                            wepon.Damage = 2;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 5)
                        {
                            Wepon.wepontype = 5;
                            progectilcapacity = 100;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 6)
                        {
                            Wepon.wepontype = 6;
                            progectilcapacity = 5;
                            wepon.Damage = 150;
                            TalkingToPng = false;
                        }
                        else
                        {
                            Wepon.wepontype = 0;
                        }
                    }
                    else if (Wepon.wepontype == 8)
                    {
                        kelps.Add(new Kelp(fish.X, fish.Y, 2));

                        if (lastwepontype == 1)
                        {
                            Wepon.wepontype = 1;
                            progectilcapacity = 12;
                            wepon.Damage = 2;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 2)
                        {
                            Wepon.wepontype = 2;
                            progectilcapacity = 32;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 3)
                        {
                            Wepon.wepontype = 3;
                            progectilcapacity = 5;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 4)
                        {
                            Wepon.wepontype = 4;
                            progectilcapacity = 50;
                            wepon.Damage = 2;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 5)
                        {
                            Wepon.wepontype = 5;
                            progectilcapacity = 100;
                            wepon.Damage = 1;
                            TalkingToPng = false;
                        }
                        else if (lastwepontype == 6)
                        {
                            Wepon.wepontype = 6;
                            progectilcapacity = 5;
                            wepon.Damage = 150;
                            TalkingToPng = false;
                        }
                        else
                        {
                            Wepon.wepontype = 0;
                        }
                    }

                    if (eventtype == 0 && AirSpace.EventTime >= 1000 && ramdomEvent)
                    {


                        if ((Event.x - Event.Widths1) <= (wepon.X + wepon.Width) && (200 - Event.Heights1) <= (wepon.Y + wepon.Height) && (Event.x + Event.Widths1) >= (wepon.X - wepon.Width) && (200 + Event.Heights1) >= (wepon.Y - wepon.Height) && Event.Health1 > 0)
                        {
                            Event.Health1 -= wepon.Damage;
                            Console.WriteLine("shark 1 health : " + Event.Health1);

                        }


                        if ((Event.x2 - Event.Widths2) <= (wepon.X + wepon.Width) && (400 - Event.Heights2) <= (wepon.Y + wepon.Height) && (Event.x2 + Event.Widths2) >= (wepon.X - wepon.Width) && (400 + Event.Heights2) >= (wepon.Y - wepon.Height) && Event.Health2 > 0)
                        {
                            Event.Health2 -= wepon.Damage;
                            Console.WriteLine("shark 2 health : " + Event.Health2);

                        }

                        if ((Event.x3 - Event.Widths3) <= (wepon.X + wepon.Width) && (475 - Event.Heights3) <= (wepon.Y + wepon.Height) && (Event.x3 + Event.Widths3) >= (wepon.X - wepon.Width) && (475 + Event.Heights3) >= (wepon.Y - wepon.Height) && Event.Health3 > 0)
                        {
                            Event.Health3 -= wepon.Damage;
                            Console.WriteLine("shark 3 health : " + Event.Health3);

                        }


                    }
                }




            }
            if (e.KeyCode == Keys.R)
            {
                reloding = true;
            }
        }

        // Gestion du relâchement des touches clavier
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                moveUp = false;
            if (e.KeyCode == Keys.S)
                moveDown = false;
            if (e.KeyCode == Keys.A)
                moveLeft = false;
            if (e.KeyCode == Keys.D)
                moveRight = false;
            if (e.KeyCode == Keys.E)
                Fish.pressingE = false;
            if (e.KeyCode == Keys.Space)
            {
                Wepon.hiting = false;
            }
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        public static bool ramdomEvent = false;
        public static int EventTime = 0;

        private void AirSpace_Load(object sender, EventArgs e)
        {

        }

        int rndU = GlobalHelpers.alea.Next(1500, 2000);
        int u = 0;
        int z = 0;
        int h = 0;
        int i;
        private void Update(int interval)
        {
            if (f > 0)
                f++;

            if (f >= 100)
                f = 0;

            if (h == 5)
                h = 0;
            if (Wepon.wepontype != 0 && Wepon.wepontype != 3 && !reloding && Wepon.hiting && h == 0 && !Fish.isportected)
            {
                if (progectilcapacity >= 1 && Wepon.wepontype == 2  || Wepon.wepontype == 5 && progectilcapacity >= 1)
                {
                    projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage, Wepon.wepontype, fish));
                    progectilcapacity--;
                }
                else if (Wepon.wepontype == 4 && h % 2 == 0 && progectilcapacity >= 1)
                {
                    projectiles.Add(new Projectile(fish.X, fish.Y, wepon.Damage,Wepon.wepontype, fish));
                    progectilcapacity--;
                }
                h++;
            }

            if (h != 0)
                h++;

            fish.Update(moveUp, moveDown, moveLeft, moveRight, MOVE_SPEED, badfleet, Event, jellyfleet, hearts, golds, kelps);

            if (fish.helth <= 0)
                Environment.Exit(0);

            if (progectilcapacity == 0)
                reloding = true;


            foreach (BadFish badfish in badfleet)
            {
                badfish.Update(projectiles,wepon);

                if (badfish.helth <= 0)
                {
                    badfleet.Remove(badfish);
                    golds.Add(new Gold((badfish.X + (badfish.Width / 2)), (badfish.Y + (badfish.Height / 2)), badfish.Size));
                    badfleet.Add(new BadFish(badfish.Id, 1300, 0));
                    if (DoingQuest && QuestType == 1)
                    {
                        Quest.numberoffish++;
                        Console.WriteLine("number of fish killed : " + Quest.numberoffish);
                    }
                    if (DoingQuest && QuestType == 2 && badfish.Type == 14)
                    {
                        Quest.numberoffish++;
                    }
                    if (DoingQuest && QuestType == 3 && badfish.Size >= 13)
                    {
                        Quest.numberoffish++;
                    }

                    break;
                }
            }

            foreach (Jellyfish jellyfish in jellyfleet)
            {
                jellyfish.Update(projectiles,wepon);

                if (jellyfish.Helth <= 0)
                {
                    jellyfleet.Remove(jellyfish);
                    golds.Add(new Gold((jellyfish.X + (jellyfish.Width / 2)), (jellyfish.Y + (jellyfish.Height / 2)), jellyfish.Size));
                    jellyfleet.Add(new Jellyfish(jellyfish.Id, 0, -100));
                    if (DoingQuest && QuestType == 3 && jellyfish.Size >= 13)
                    {
                        Quest.numberoffish++;
                    }
                    break;
                }
            }

            foreach (turet turet in turets)
            {
                turet.Update(projectiles, fish);
            }

            wepon.update(fish);

            do
            {
                i = 0;
                foreach (Projectile projectile in projectiles)
                {
                    projectile.Update();
                    if (projectile.X < 0 || projectile.X > 1200 || projectile.Y < 0 || projectile.Y > 600 || projectile.bulletdistance > 15)
                    {
                        projectiles.Remove(projectile);
                        i = 1;
                        break;
                    }
                }
            } while (i == 1);

            if (!ramdomEvent && !TalkingToPng)
                u++;

            //ramdon event
            if (u >= rndU && !ramdomEvent && !TalkingToPng)
            {
                u = 0;
                Console.Write("\nEvent : ");
                ramdomEvent = true;
                eventtype = GlobalHelpers.alea.Next(0, 2);

                //shark event
                if (eventtype == 0)
                {
                    Console.Write("Shark\n");

                    Event.x = -200;
                    Event.x2 = -200;
                    Event.x3 = -200;
                    Event.Health1 = 50;
                    Event.Health2 = 50;
                    Event.Health3 = 25;
                }

                if (eventtype == 1 && !won)
                {
                    Console.Write("Whale\n");
                    
                    jellyfleet.Clear();
                    badfleet.Add(new BadFish(badfleet.Count, GlobalHelpers.alea.Next(-200, 0), GlobalHelpers.alea.Next(0, 400)));
                    badfleet.Add(new BadFish(badfleet.Count, GlobalHelpers.alea.Next(-200, 0), GlobalHelpers.alea.Next(0, 400)));
                    badfleet.Add(new BadFish(badfleet.Count, GlobalHelpers.alea.Next(-200, 0), GlobalHelpers.alea.Next(0, 400)));
                }
            }
            bool repeat;   
            //event update
            if (ramdomEvent && !TalkingToPng)
            {
                EventTime++;

                if (EventTime >= 1800 && eventtype == 0 || eventtype == 1 && EventTime >= 5000 || won)
                {
                    ramdomEvent = false;
                    EventTime = 0;

                    Event.x = -200;
                    Event.x2 = -200;
                    Event.x3 = -200;
                    Event.Whalex = -1500;

                    if (eventtype == 1) 
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            jellyfleet.Add(new Jellyfish(i, GlobalHelpers.alea.Next(0, 1200), GlobalHelpers.alea.Next(600, 800)));
                        }
                        do
                        {
                            repeat = false;
                            foreach (BadFish badFish in badfleet)
                            {
                                if (badFish.Id > 3)
                                {
                                    badfleet.Remove(badFish);
                                    repeat = true;
                                    break;
                                }
                            }
                        }while (repeat);
                    }
                }
            }

            //doing quest
            if (DoingQuest)
            {
                if (QuestType == 0 && Quest.numberoffish >= 1)
                {
                    Quest.numberoffish = 0;

                    fish.Gold += questamount;

                    DoingQuest = false;
                }

                if (QuestType == 1 && Quest.numberoffish >= 5)
                {
                    Quest.numberoffish = 0;

                    fish.Gold += questamount;

                    DoingQuest = false;
                }

                if (QuestType == 2 && Quest.numberoffish >= 1)
                {
                    Quest.numberoffish = 0;

                    fish.Gold += questamount;

                    DoingQuest = false;
                }

                if (QuestType == 3 && Quest.numberoffish >= 1)
                {
                    Quest.numberoffish = 0;

                    fish.Gold += questamount;

                    DoingQuest = false;
                }
            }

            if (eventtype == 0 && ramdomEvent)
            {

                if (Event.Health1 <= 0 && Event.x != 1300)
                {
                    golds.Add(new Gold(Event.x, 200, 80));
                    Event.x = 1300;
                }
                if (Event.Health2 <= 0 && Event.x2 != 1300)
                {
                    golds.Add(new Gold(Event.x2, 400, 80));
                    Event.x2 = 1300;
                }
                if (Event.Health3 <= 0 && Event.x3 != 1300)
                {

                    golds.Add(new Gold(Event.x3, 475, 50));
                    Event.x3 = 1300;
                }

                if (DoingQuest && Event.Health1 <= 0 && QuestType == 0 || DoingQuest && Event.Health2 <= 0 && QuestType == 0 || DoingQuest && Event.Health3 <= 0 && QuestType == 0)
                    Quest.numberoffish++;
            }

            if (reloding)
            {
                z++;

                if (z > 200)
                {
                    reloding = false;
                    if (Wepon.wepontype == 1)
                        progectilcapacity = 12;
                    else if (Wepon.wepontype == 2)
                        progectilcapacity = 32;
                    else if (Wepon.wepontype == 3)
                        progectilcapacity = 5;
                    else if (Wepon.wepontype == 4)
                        progectilcapacity = 50;
                    else if (Wepon.wepontype == 5)
                        progectilcapacity = 100;
                    else if (Wepon.wepontype == 6)
                        progectilcapacity = 5;
                    z = 0;
                }
            }

        }

        Image trophe = Image.FromFile("images/otherimage/victoire.png");
        // Affichage de la situation actuelle
        private void Render()
        {

            Graphics g = airspace.Graphics;
            g.DrawImage(background, 0, 0, WIDTH, HEIGHT);
            
            if (won)
            {
                airspace.Graphics.DrawImage(trophe, new Rectangle(10, 10, 1180, 580));
            }

            // Dessin des du poisson

            fish.Render(airspace);


            wepon.Render(airspace);


            foreach (Gold gold in golds)
            {
                gold.Render(airspace);
            }

            foreach (Heart heart in hearts)
            {
                heart.Render(airspace);
            }

            foreach (turet turet in turets)
            {
                turet.Render(airspace);
            }

            foreach (Kelp kelp in kelps)
            {
                kelp.Render(airspace);
            }

            foreach (BadFish badfish in badfleet)
            {
                badfish.Render(airspace);
            }


            foreach (Jellyfish jellyfish in jellyfleet)
            {
                jellyfish.Render(airspace);
            }

            if (ramdomEvent)
            {

                if (eventtype == 0 && EventTime >= 1200)
                {


                    Event.Render(airspace);

                }

                if (eventtype == 1)
                {


                    Event.Render(airspace);

                }

            }

            if (TalkingToPng)
            {
                if (BadFish.PnjTouch || Jellyfish.PnjTouch)
                {

                    quest.Render(airspace, fish, badfleet, jellyfleet);

                }
                else
                {

                    shop.Render(airspace, fish, badfleet, jellyfleet);

                }

            }


            foreach (Projectile projectile in projectiles)
            {
                projectile.Render(airspace);
            }



            airspace.Render();
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }

    }
}