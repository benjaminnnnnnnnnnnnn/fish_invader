using FishInvader.Helpers;
using FishInvader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishInvader
{
    public partial class Wepon
    {

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {

            if (Fish.facing_left)
            {

                if (wepontype == 0)
                {
                    if (hiting)
                    {
                        using (Image Flippedfish = Image.FromFile("images/otherimage/sward.png"))
                        {
                            // Flip the image
                            Flippedfish.RotateFlip(RotateFlipType.Rotate180FlipX);



                            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                            drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        }
                    }
                    else
                    {
                        drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(WeponImage, -WeponImage.Width / 2, -WeponImage.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                    }
                }
                else if (wepontype == 1)
                {

                    if (hiting)
                    {

                        drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(WeponImageGun, -WeponImageGun.Width / 2, -WeponImageGun.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation


                    }
                    else
                    {
                        drawingSpace.Graphics.TranslateTransform(_x - 5, _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(WeponImageGun, -WeponImageGun.Width / 2, -WeponImageGun.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                    }

                }
                else if (wepontype == 2)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageUsi, -WeponImageUsi.Width / 2, -WeponImageUsi.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 3)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/shotgun.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 4)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/scar.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 5)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/minigun.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 6)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/sniper.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 7)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageTuret, -WeponImageTuret.Width / 2, -WeponImageTuret.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 8)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageKelp, -WeponImageKelp.Width / 2, -WeponImageKelp.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }

            }
            else
            {
                if (wepontype == 0)
                {
                    if (hiting)
                    {
                        using (Image Flippedfish = Image.FromFile("images/otherimage/sward.png"))
                        {
                            // Flip the image
                            Flippedfish.RotateFlip(RotateFlipType.Rotate90FlipY);



                            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                            drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        }
                    }
                    else
                    {
                        using (Image Flippedfish = Image.FromFile("images/otherimage/sward.png"))
                        {
                            // Flip the image
                            Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);



                            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                            drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        }
                    }


                }
                else if (wepontype == 1)
                {
                    if (hiting) 
                    {
                        using (Image Flippedfish = Image.FromFile("images/otherimage/gun.png"))
                        {
                            // Flip the image
                            Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);



                            drawingSpace.Graphics.TranslateTransform(_x, _y); // Déplace l'origine du dessin au centre du fish
                            drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        }
                    }
                    else
                    {
                        using (Image Flippedfish = Image.FromFile("images/otherimage/gun.png"))
                        {
                            // Flip the image
                            Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);



                            drawingSpace.Graphics.TranslateTransform(_x + 5, _y); // Déplace l'origine du dessin au centre du fish
                            drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
                            drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                        }
                    }

                }
                else if (wepontype == 2)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/Usi.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 3)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y +5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageShotgun, -WeponImageShotgun.Width / 2, -WeponImageShotgun.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 4)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageScar, -WeponImageScar.Width / 2, -WeponImageScar.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 5)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageMini, -WeponImageMini.Width / 2, -WeponImageMini.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 6)
                {
                    drawingSpace.Graphics.TranslateTransform(_x - 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                    drawingSpace.Graphics.DrawImage(WeponImageSniper, -WeponImageSniper.Width / 2, -WeponImageSniper.Height / 2);
                    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
                }
                else if (wepontype == 7)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/turet.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
                else if (wepontype == 8)
                {
                    using (Image FlippedUsi = Image.FromFile("images/otherimage/kelp.png"))
                    {
                        // Flip the image
                        FlippedUsi.RotateFlip(RotateFlipType.RotateNoneFlipX);



                        drawingSpace.Graphics.TranslateTransform(_x + 5, _y + 5); // Déplace l'origine du dessin au centre du fish
                        drawingSpace.Graphics.DrawImage(FlippedUsi, -FlippedUsi.Width / 2, -FlippedUsi.Height / 2);
                        drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation

                    }
                }
            }









        }
    }
}
