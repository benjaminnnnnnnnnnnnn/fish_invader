using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FishInvader
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public static readonly int WIDTH = 1200;        // Dimensions de l'espace aérien
        public static readonly int HEIGHT = 600;

        private List<Fish> fleet;                     // La flotte des drones
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics airspace;

        // Variables pour les mouvements
        private bool moveUp, moveDown, moveLeft, moveRight;
        private const int MOVE_SPEED = 3; // Vitesse de déplacement du drone

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Fish> fleet) : base()
        {
            InitializeComponent();

            this.fleet = fleet;

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
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Fish drone in fleet)
            {
                drone.Update(moveUp, moveDown, moveLeft, moveRight, MOVE_SPEED);
            }
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.AliceBlue);

            // Dessin des drones
            foreach (Fish drone in fleet)
            {
                drone.Render(airspace);
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