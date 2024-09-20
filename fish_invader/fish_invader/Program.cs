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

            // Création de la flotte de drones
            List<Fish> fleet = new List<Fish>();
            fleet.Add(new Fish(AirSpace.WIDTH / 2, AirSpace.HEIGHT / 2, "Fish"));

            List<BadFish> badfleet = new List<BadFish>();

            string fishfilepath = "originalfish\\fish20.png";
            string Name;
            for (int i = 0; i < 1; i++)
            {
                Name = metode.RandomName();



                for (int j = 1; j < 21; j++)
                {
                    if (GlobalHelpers.alea.Next(1, 3) == 2)
                    {
                        fishfilepath = $"originalfish\\fish1.png";
                        break;
                    }
                }


                // Load the bitmap
                var bmp = new Bitmap(fishfilepath);

                // Perform color swapping
                metode.SwapColor(bmp, Color.FromArgb(255, 163, 26), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(250, 243, 64), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(255, 85, 5), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));
                metode.SwapColor(bmp, Color.FromArgb(31, 49, 125), Color.FromArgb(GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256), GlobalHelpers.alea.Next(0, 256)));

                // Save the modified image
                bmp.Save(@"fishpng\\fish" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);




                badfleet.Add(new BadFish(Name, i));

            }



            // Démarrage
            Application.Run(new AirSpace(fleet, badfleet));











        }


    }
}