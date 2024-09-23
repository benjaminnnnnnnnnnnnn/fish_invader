using Efundies;
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

            // Création de la flotte de poissons
            List<Fish> fleet = new List<Fish>();
            fleet.Add(new Fish(AirSpace.WIDTH / 2, AirSpace.HEIGHT / 2, "Fish"));


            List<BadFish> badfleet = new List<BadFish>();           
            for (int i = 0; i < 30; i++)
            {
                badfleet.Add(new BadFish(i));
            }



            // Démarrage
            Application.Run(new AirSpace(fleet, badfleet));











        }


    }
}