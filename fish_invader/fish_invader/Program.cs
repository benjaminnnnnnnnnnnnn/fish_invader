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
            
            for (int i = 0; i < 10; i++)
            {
                badfleet.Add(new BadFish(RandomName()));
            }



            // Démarrage
            Application.Run(new AirSpace(fleet,badfleet));



















            static string RandomName()
            {
                string line;
                int i = 0;

                StreamReader sr = new StreamReader("first-names.txt");
                string[] Names = new string[4946];

                line = sr.ReadLine();


                while (line != null)
                {
                    Names[i++] = line;

                    //Read the next line
                    line = sr.ReadLine();
                }

                Random rnd = new Random();

                string randomName = Names[rnd.Next(4946)];

                return randomName;
            }
        }
    }
}