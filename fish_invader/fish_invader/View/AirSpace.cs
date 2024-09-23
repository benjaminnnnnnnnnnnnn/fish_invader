using fish_invader;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private List<Quest> quests = new List<Quest>();
        private List<Event> events = new List<Event>();
        private List<Fish> fleet;                     // La flotte des poissons
        private List<BadFish> badfleet;               //flotte de machant poison
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics airspace;



        public static bool SharkEvent = false;


        public static bool DoingQuest = false;
        public static bool TalkingToPng = false;
        public static int QuestType;
        public static int dialogNum = 0;


        // Variables pour les mouvements
        private bool moveUp, moveDown, moveLeft, moveRight;
        private const int MOVE_SPEED = 3; // Vitesse de déplacement du drone

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Fish> fleet, List<BadFish> badfleet) : base()
        {
            InitializeComponent();

            this.fleet = fleet;
            this.badfleet = badfleet;
            events.Add(new Event());
            quests.Add(new Quest());

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
        }


        // Gestion des appuis sur les touches clavier
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                moveUp = true;
            if (e.KeyCode == Keys.S)
                moveDown = true;
            if (e.KeyCode == Keys.A)
                moveLeft = true;
            if (e.KeyCode == Keys.D)
                moveRight = true;
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(0);
            if (e.KeyCode == Keys.E)
            {

                if (dialogNum == 1)
                {
                }
                else if (TalkingToPng && dialogNum < 3)
                    dialogNum++;

                if (BadFish.PnjTouch && dialogNum == 0)
                {
                    Console.WriteLine("give quest");
                    Fish.pressingE = true;
                    DoingQuest = true;
                    TalkingToPng = true;

                    QuestType = GlobalHelpers.alea.Next(0, 3);
                }






                if (dialogNum == 3 || dialogNum == 2)
                {
                    TalkingToPng = false;
                    DoingQuest = false;
                    dialogNum = 0;
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
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        bool ramdomEvent = false;
        public static int EventTime = 0;
        private void Update(int interval)
        {
            foreach (Fish fish in fleet)
            {
                fish.Update(moveUp, moveDown, moveLeft, moveRight, MOVE_SPEED, badfleet, events);

                if (fish.helth <= 0)
                    Environment.Exit(0);
            }


            foreach (BadFish badfish in badfleet)
            {
                badfish.Update();


            }


            //ramdon event
            if (GlobalHelpers.alea.Next(0, 3000) == 0 && !ramdomEvent && !TalkingToPng)
            {
                Console.Write("\nEvent : ");
                ramdomEvent = true;
                int ö = GlobalHelpers.alea.Next(0, 1);

                //shark event
                if (ö == 0)
                {
                    SharkEvent = true;
                    Console.Write("Shark\n");

                }
            }

            //event update
            if (ramdomEvent && !TalkingToPng)
            {
                EventTime++;

                if (EventTime >= 1700)
                {
                    ramdomEvent = false;
                    SharkEvent = false;
                    EventTime = 0;
                    foreach (Event e in events)
                    {
                        e.x = -200;

                    }
                }
            }
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.Aqua);

            // Dessin des du poisson
            foreach (Fish fish in fleet)
            {
                fish.Render(airspace);
            }

            foreach (BadFish badfish in badfleet)
            {
                badfish.Render(airspace);


            }

            if (ramdomEvent)
            {

                if (SharkEvent && EventTime >= 1200)
                {
                    foreach (Event events in events)
                    {

                        events.Render(airspace);
                    }
                }


            }

            if (DoingQuest)
            {
                foreach (Quest quest in quests)
                {
                    quest.Render(airspace, fleet, badfleet);
                }
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