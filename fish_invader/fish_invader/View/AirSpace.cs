using fish_invader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FishInvader
{
    // La classe AirSpace repr�sente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fen�tre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public static int WIDTH = 1200;        // Dimensions de l'espace a�rien
        public static int HEIGHT = 600;

        Shop shop = new Shop();
        Quest quest = new Quest();
        Event Event = new Event();

        private List<Projectile> projectiles = new List<Projectile>();
        private List<Gold> golds = new List<Gold>();
        private List<Heart> hearts = new List<Heart>();
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


        // Variables pour les mouvements
        private bool moveUp, moveDown, moveLeft, moveRight;
        private const int MOVE_SPEED = 3; // Vitesse de d�placement du drone

        // Initialisation de l'espace a�rien avec un certain nombre de drones
        public AirSpace(List<BadFish> badfleet, List<Jellyfish> jellyfleet) : base()
        {
            InitializeComponent();


            this.badfleet = badfleet;
            this.jellyfleet = jellyfleet;


            hearts.Add(new Heart());
            hearts.Add(new Heart());
            hearts.Add(new Heart());


            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;

            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            // Gestion des touches clavier
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);

            // Rendre le formulaire focusable pour les �v�nements clavier
            this.KeyPreview = true;

            SetbackgroundImage();
        }

        private Image background;
        public void SetbackgroundImage()
        {

            background = Image.FromFile("otherimage\\background.png");
            BackgroundImage = background;

        }


        // Gestion des appuis sur les touches clavier
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (BadFish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionY > 0)
                        shop.selectionY--;

                }
                else
                    moveUp = true;
            }

            if (e.KeyCode == Keys.S)
            {
                if (BadFish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionY < 2)
                        shop.selectionY++;

                }
                else
                    moveDown = true;
            }

            if (e.KeyCode == Keys.A)
            {
                if (BadFish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionX > 0)
                        shop.selectionX--;

                }
                else
                    moveLeft = true;
            }

            if (e.KeyCode == Keys.D)
            {
                if (BadFish.ShopTouch && TalkingToPng)
                {

                    if (shop.selectionX < 4)
                        shop.selectionX++;

                }
                else
                    moveRight = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (TalkingToPng && BadFish.ShopTouch)
                {
                    TalkingToPng = false;

                }
                else
                    Environment.Exit(0);
            }

            if (e.KeyCode == Keys.E)
            {
                if (BadFish.ShopTouch && TalkingToPng)
                {
                    

                    if (shop.selectionX == 0 && shop.selectionY == 0 && fish.Gold >= shop.price[0,0])
                    {
                        fish.Gold -= shop.price[0,0];
                        wepon.wepontype = 1;
                        TalkingToPng = false;
                    }

                }


                if (dialogNum == 1)
                {
                }
                else if (TalkingToPng && dialogNum < 2)
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


                if (BadFish.ShopTouch)
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
                Wepon.hiting = true;


                if (wepon.wepontype == 0)
                {
                    foreach (BadFish badfish in badfleet)
                    {

                        if (!badfish.IsPnj && !badfish.IsShop)
                        {
                            if ((badfish.X - badfish.Width) <= (wepon.X + wepon.Width) && (badfish.Y - badfish.Height) <= (wepon.Y + wepon.Height) && (badfish.X + badfish.Width) >= (wepon.X - wepon.Width) && (badfish.Y + badfish.Height) >= (wepon.Y - wepon.Height))
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
                            if ((jellyfish.X - jellyfish.Width) <= (wepon.X + wepon.Width) && (jellyfish.Y - jellyfish.Height) <= (wepon.Y + wepon.Height) && (jellyfish.X + jellyfish.Width) >= (wepon.X - wepon.Width) && (jellyfish.Y + jellyfish.Height) >= (wepon.Y - wepon.Height))
                            {
                                Console.WriteLine("-1 jellyfish hp");
                                jellyfish.Helth -= wepon.Damage;
                            }


                        }

                    }
                }
                else if (wepon.wepontype == 1)
                {
                    projectiles.Add(new Projectile(fish.X,fish.Y));
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

        // Gestion du rel�chement des touches clavier
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

        // Calcul du nouvel �tat apr�s que 'interval' millisecondes se sont �coul�es
        public static bool ramdomEvent = false;
        public static int EventTime = 0;

        private void AirSpace_Load(object sender, EventArgs e)
        {

        }


        private void Update(int interval)
        {

            fish.Update(moveUp, moveDown, moveLeft, moveRight, MOVE_SPEED, badfleet, Event, jellyfleet, hearts, golds);

            if (fish.helth <= 0)
                Environment.Exit(0);


            foreach (BadFish badfish in badfleet)
            {
                badfish.Update();

                if (badfish.helth <= 0)
                {
                    badfleet.Remove(badfish);
                    golds.Add(new Gold(badfish.X, badfish.Y, badfish.Size));
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
                jellyfish.Update();

                if (jellyfish.Helth <= 0)
                {
                    jellyfleet.Remove(jellyfish);
                    golds.Add(new Gold(jellyfish.X, jellyfish.Y, jellyfish.Size));
                    jellyfleet.Add(new Jellyfish(jellyfish.Id, 0, -100));
                    if (DoingQuest && QuestType == 3 && jellyfish.Size >= 13)
                    {
                        Quest.numberoffish++;
                    }
                    break;
                }
            }


            wepon.update(fish);

            foreach (Projectile projectile in projectiles)
            {
                projectile.Update();
            }

            //ramdon event
            if (GlobalHelpers.alea.Next(0, 3000) == 0 && !ramdomEvent && !TalkingToPng)
            {
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

                if (eventtype == 1)
                {
                    Console.Write("Whale\n");
                }
            }

            //event update
            if (ramdomEvent && !TalkingToPng)
            {
                EventTime++;

                if (EventTime >= 1800 && eventtype == 0 || eventtype == 2 && EventTime >= 3000)
                {
                    ramdomEvent = false;
                    EventTime = 0;

                    Event.x = -200;
                    Event.x2 = -200;
                    Event.x3 = -200;
                    Event.Whalex = -1500;

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

        }

        // Affichage de la situation actuelle
        private void Render()
        {

            Graphics g = airspace.Graphics;
            g.DrawImage(background, 0, 0, WIDTH, HEIGHT);


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
                if (BadFish.PnjTouch)
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

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }








    }
}