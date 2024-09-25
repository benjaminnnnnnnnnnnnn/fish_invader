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

            // Cr�ation de la flotte de poissons
            List<Fish> fleet = new List<Fish>();
            fleet.Add(new Fish(AirSpace.WIDTH / 2, AirSpace.HEIGHT / 2, "Fish"));

            List<Wepon> wepons = new List<Wepon>();
            wepons.Add(new Wepon());


            List<BadFish> badfleet = new List<BadFish>();           
            for (int i = 0; i < 6; i++)
            {
                badfleet.Add(new BadFish(i));
            }

            List<Jellyfish> jellyfleet = new List<Jellyfish>();
            for (int i = 0; i < 3; i++)
            {
                jellyfleet.Add(new Jellyfish(i));
            }



            // D�marrage
            Application.Run(new AirSpace(fleet, badfleet, jellyfleet, wepons));











        }


    }
}