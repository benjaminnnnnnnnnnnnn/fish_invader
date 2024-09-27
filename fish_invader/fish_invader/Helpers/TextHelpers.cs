namespace FishInvader.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    internal static class TextHelpers
    {
        public static Font drawFont = new Font("Arial", 10);
        public static Font drawbigFont = new Font("Arial", 20);
        public static SolidBrush writingBrush = new SolidBrush(Color.Black);
        public static SolidBrush writingBrushPNJ = new SolidBrush(Color.Red);
        public static SolidBrush writingBrushPink = new SolidBrush(Color.MediumPurple);
        public static SolidBrush writingBrushGold = new SolidBrush(Color.DarkGoldenrod);

    }
}
