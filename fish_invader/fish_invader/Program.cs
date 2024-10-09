using Efundies;
using fish_invader;
using System.Xml.Linq;

namespace FishInvader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            List<BadFish> badfleet = new List<BadFish>();
            for (int i = 0; i < 5; i++)
            {
                badfleet.Add(new BadFish(i, GlobalHelpers.alea.Next(0, 1200), GlobalHelpers.alea.Next(0, 600)));
            }

            List<Jellyfish> jellyfleet = new List<Jellyfish>();
            for (int i = 0; i < 2; i++)
            {
                jellyfleet.Add(new Jellyfish(i, GlobalHelpers.alea.Next(0, 1200), GlobalHelpers.alea.Next(0, 600)));
            }


            // Démarrage
            Application.Run(new AirSpace(badfleet, jellyfleet));











        }


    }
}