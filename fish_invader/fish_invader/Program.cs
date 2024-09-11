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

            // Démarrage
            Application.Run(new AirSpace(fleet));
        }
    }
}