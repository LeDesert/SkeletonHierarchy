// Auteur : Aurélie Leborgne
// Calcule la SEDT et les boules maximales d'une forme
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace test_image2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spécifie le chemin d'accès à votre image BMP
            string imagePath = "../../images/imagesReelles/2469s.bmp";
            int z = 0;
            // Transforme l'image en tableau 2D
            //int[,] tabImage = TabFromFile(imagePath);

            //Ajoutez ici d'autres traitements ou analyse du tableau
            // Spécifiez le chemin d'accès à votre image BMP
            /*int i = 2;
            int u = 0;
            string filePath = $"./fichierExcel.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("TailleForme, TempsPrisAlgo1, TempPrisAlgo2");
            }*/
            //      for(i=1; i<=20; i++)
            //      {
            //        for(u=0; u<=4; u++)
            //        {

            int[,] pixelValues = new int[9,9] { { 255, 255, 255, 255, 255, 255, 255, 255, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 0, 0, 0, 0, 0, 0, 0, 255 }, { 255, 255, 255, 255, 255, 255, 255, 255, 255 } };
            affichageTableau(pixelValues);
            //Console.WriteLine(pixelValues.GetLength(0)+" "+pixelValues.GetLength(1));
            // Exemple d'utilisation : affichez la valeur du pixel à la position (0, 0)
            //Console.WriteLine($"La valeur du pixel à la position (0, 0) est : {pixelValues[0, 0]}");
            linearisationImage(pixelValues);
            int Dun;
            int Ddeux;
            int tailleForme = 0;
            Dun = pixelValues.GetLength(0);
            Ddeux = pixelValues.GetLength(1);
            //int[,] localEuclide = new int[Dun, Ddeux];
            int[,] localEuclideOpti = new int[Dun, Ddeux];
            int[,] rayonMain = new int[Dun, Ddeux];
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            tailleForme = calculTailleForme(pixelValues);
            stopwatch.Start();
            //localEuclide = bruteForce(pixelValues, Dun, Ddeux);
            stopwatch.Stop();
            TimeSpan tempsEcoule = stopwatch.Elapsed;
            stopwatch2.Start();
            localEuclideOpti = euclideOptimise(pixelValues, Dun, Ddeux);
            stopwatch2.Stop();
            TimeSpan tempsEcoule2 = stopwatch2.Elapsed;
            Console.WriteLine("Temps écoulé du premier : " + tempsEcoule.TotalMilliseconds + " ms");
            Console.WriteLine("Temps écoulé du second : " + tempsEcoule2.TotalMilliseconds + " ms");
            // Ajoutez ici d'autres traitements ou analyses du tableau 2D si nécessaire
            //affichageTableau(localEuclideOpti);
            rayonMain = boulesMaximales(localEuclideOpti);
            //affichageTableau(rayonMain);
            //faire une procédure qui envoie dans une fonction
            /*using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(tailleForme + "," + tempsEcoule + "," + tempsEcoule2);
            }
            affichageTableau(localEuclideOpti);
            affichageTableau(rayonMain);*/
            //        }
            //      }
            //saveImage(pixelValues, "original.bmp");
            // Attendez que l'utilisateur appuie sur une touche avant de fermer la console
            Console.ReadKey();

            //
            //Affiche_image(tabImage);

            //SaveImage(tabImage, "../../images/imagesReelles/SEDT/2469s-SEDT.bmp");


            // Attendez que l'utilisateur appuie sur une touche avant de fermer la console
            Console.ReadKey();

        }

        // Definition de la fonction TabFromFile : cree le tableau 2D stockant la valeur des pixels de l'image situe au bout du xhemin Xfile
        /* TabFromFile : fonc : int [,]
        parametre:
            Xfile : string : le chemin vers l'image bmp
        retour :
            tabImage : int [,] : le tableau stockant la valeur des pixels de l'image
        local :
            Bitmap : img : l'image 
        */
        public static int[,] TabFromFile(string Xfile)
        {
            Bitmap img = new Bitmap(Xfile);
            int[,] tabImage = ImageToInt(img);
            return tabImage;
        }

        // Definition de la fonction ImageToInt : cree le tableau 2D stockant la valeur des pixels de l'image Ximg
        /* ImageToInt : fonc : int [,]
        parametre:
            Ximg : Bitmap : l'image au format Bitmap
        retour :
            tab : int [,] : le tableau stockant la valeur des pixels de l'image Ximg
        local :
             
        */
        public static int[,] ImageToInt(Bitmap Ximg)
        {
            int largeur = Ximg.Width;
            int hauteur = Ximg.Height;
            int[,] tab = new int[hauteur, largeur];
            for(int lig=0;lig<hauteur; lig++)
            {
                for(int col=0; col<largeur; col++)
                {
                    Color c = Ximg.GetPixel(col, lig);

                    tab[lig, col] = (int)c.R;
                }
            }
            return tab;
        }

        // Definition de la fonction IntToImage : remplie Ximg à partir de Xtab
        /* IntToImage : proc : void
        parametre:
            Ximg : Bitmap : l'image au format Bitmap
            Xtab : int [,] : le tableau stockant la valeur des pixels de l'image Ximg
        retour :
            
        local :
             
        */
        public static void IntToImage(int[,] Xtab, Bitmap Ximg)
        {
            
            int largeur = Xtab.GetLength(1);
            int hauteur = Xtab.GetLength(0);
            for (int lig = 0; lig < hauteur; lig++)
            {
                for (int col = 0; col < largeur; col++)
                {
                    Color c = Color.FromArgb(255,Xtab[lig, col], Xtab[lig, col], Xtab[lig, col]);
                    Ximg.SetPixel(col, lig, c);
                }
            }
            
        }

        // Definition de la fonction saveImage : sauvegarde l'image dont la valeur des pixels est situee dans Xtab, au bout du chemin Xfile
        /* IntToImage : proc : void
        parametre:
            Xfile : string : chemin de l'image au format Bitmap
            Xtab : int [,] : le tableau stockant la valeur des pixels de l'image Ximg
        retour :
            
        local :
             
        */
        public static void SaveImage(int[,] Xtab, string Xfile)
        {
            Bitmap img = new Bitmap(Xtab.GetLength(1), Xtab.GetLength(0));

            IntToImage(Xtab, img);
            img.Save(Xfile);
            Console.WriteLine("Saugarde dans le fichier : " + Xfile);
        }

        // Definition de la fonction affiche_image : affiche l'image dont la valeur des pixels est situee dans Xtab
        /* affiche_image : proc : void
        parametre:
            Xtab : int [,] : le tableau stockant la valeur des pixels
        retour :
            
        local :
             
        */
        public static void Affiche_image(int[,] Xtab)
        {
            Bitmap img = new Bitmap(Xtab.GetLength(1), Xtab.GetLength(0));
            IntToImage(Xtab,img);
            Form f = new Form();
            f.BackgroundImage=img;
            f.Width = img.Width;
            f.Height = img.Height;
            f.Show();

        }
        //--------------------------------------------------------------------------------------------------------------

        public static void linearisationImage(int[,] XT)
        {
            int u;
            int i;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] < 122)
                    {
                        XT[u, i] = 0;
                    }
                    else
                    {
                        XT[u, i] = 255;
                    }
                }
            }
        }
        public static int[,] boulesMaximales(int[,] XT)
        {
            int i;
            int u;
            int XDun = XT.GetLength(0);
            int XDdeux = XT.GetLength(1);
            int[,] rayon = new int[XDun, XDdeux];
            //  int maxGrosseLimite=(XDun-1)*(XDun-1)+(XDdeux-1)*(XDdeux-1);
            //  int maxTempo=0;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] == 0)
                    {
                        rayon[u, i] = 0;
                    }
                    else
                    {
                        rayon[u, i] = XT[u, i];
                    }
                }
            }
            /*while(maxGrosseLimite>0)
            {
            maxTempo=0;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                  if(rayon[u,i]<maxGrosseLimite && rayon[u,i]>maxTempo)
                  {
                    maxTempo=rayon[u,i];
                  }
                }
            }
          maxGrosseLimite=maxTempo;*/
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    /*if(rayon[u,i]==maxGrosseLimite)
                    {*/
                    if (rayon[u, i] != 0)
                    {
                        for (int j = 0; j < rayon.GetLength(0); j++)
                        {
                            for (int k = 0; k < rayon.GetLength(1); k++)
                            {
                                bool complet = true;
                                int rayonTemp = rayon[u, i];
                                int rayonTemp2 = rayon[j, k];
                                if (EstDansCercle(j, k, u, i, rayonTemp))
                                {
                                    for (int m = 0; m < rayon.GetLength(0); m++)
                                    {
                                        for (int p = 0; p < rayon.GetLength(1); p++)
                                        {
                                            if (m != j && p != k)
                                            {
                                                if (EstDansCercle(m, p, j, k, rayonTemp2))
                                                {
                                                    Console.WriteLine(rayonTemp2);
                                                    Console.WriteLine("m = " + m + " j = " + j + " k = " + k + " p = " + p);
                                                    Console.WriteLine("hey");

                                                    // Vérifier si le centre de A (u, i) est à une distance inférieure au rayon de B (j, k)
                                                    if (EstDansCercle(u, i, j, k, rayonTemp2) && rayonTemp2 > rayonTemp)
                                                    {
                                                        Console.WriteLine("heyooooo");
                                                        complet = false;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (complet)
                                    {
                                        rayon[j, k] = 0;
                                    }

                                    affichageTableau(rayon);
                                }
                            }
                        }
                    }
                }
            }
            for (u = 0; u < rayon.GetLength(0); u++)
            {
                for (i = 0; i < rayon.GetLength(1); i++)
                {
                    if (XT[u, i] == 0)
                    {
                        rayon[u, i] = 0;
                    }
                    else
                    {
                        rayon[u, i] = (int)Math.Floor(Math.Sqrt(rayon[u, i]));
                    }
                }
            }
            return rayon;
        }
        static bool EstDansCercle(int x, int y, int centerX, int centerY, int radius)
        {
            bool check = false;
            if (Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= radius)
            {
                check = true;
            }
            return check;
        }
        public static int calculTailleForme(int[,] XT)
        {
            int compteur = 0;
            int i;
            int u;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] == 0)
                    {
                        compteur += 1;
                    }
                }
            }
            return compteur;
        }
        public static void lineariser(int[,] XT)
        {
            int u;
            int i;
            int max = 0;
            int coefficient;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] > max)
                    {
                        max = XT[u, i];
                    }
                }
            }
            coefficient = (max / 255) + 1;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] == max)
                    {
                        XT[u, i] = 255;
                    }
                    else
                    {
                        XT[u, i] = XT[u, i] / coefficient;
                    }
                }
            }
        }

        public static int[,] bruteForce(int[,] XT, int XDun, int XDdeux)
        {
            int[,] euclide = new int[XDun, XDdeux];
            int compteurSaveEuclide = (XDun - 1) * (XDun - 1) + (XDdeux - 1) * (XDdeux - 1);
            int compteurEuclide;
            int u;
            int i;
            int j;
            int p;
            int max = 0;
            int max2 = 0;
            for (u = 0; u < euclide.GetLength(0); u++)
            {
                for (i = 0; i < euclide.GetLength(1); i++)
                {
                    if (XT[u, i] != 0)
                    {
                        euclide[u, i] = 0;
                    }
                }
            }
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] == 0)
                    {
                        max = u * 2 + 1;
                        max2 = i * 2 + 1;
                        if (max > XT.GetLength(0) - 1) ;
                        {
                            max = XT.GetLength(0);
                        }
                        if (max2 > XT.GetLength(1) - 1) ;
                        {
                            max2 = XT.GetLength(1);
                        }
                        compteurSaveEuclide = (XDun - 1) * (XDun - 1) + (XDdeux - 1) * (XDdeux - 1);
                        for (j = 0; j < max; j++)
                        {
                            for (p = 0; p < max2; p++)
                            {
                                if (euclide[j, p] == 0)
                                {
                                    compteurEuclide = (u - j) * (u - j) + (i - p) * (i - p);
                                    if (compteurEuclide < compteurSaveEuclide)
                                    {
                                        compteurSaveEuclide = compteurEuclide;
                                    }
                                }
                            }
                        }
                        euclide[u, i] = compteurSaveEuclide;
                    }
                }
            }
            return euclide;
        }

        public static void affichageTableau(int[,] XT)
        {
            for (int i = 0; i < XT.GetLength(1); i++)
            {
                Console.Write("-=");
            }
            Console.WriteLine("-");

            for (int u = 0; u < XT.GetLength(0); u++)
            {
                for (int i = 0; i < XT.GetLength(1); i++)
                {
                    Console.Write("| ");
                    if (XT[u, i] < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(XT[u, i] + " ");
                }
                Console.Write("|");
                Console.WriteLine("");

                for (int i = 0; i < XT.GetLength(1); i++)
                {
                    Console.Write("-= -=");
                }
                Console.WriteLine("-");
            }
        }
        public static int[,] euclideOptimise(int[,] XT, int XDun, int XDdeux)
        {
            int[,] euclide = new int[XDun, XDdeux];
            int compteurSaveEuclide = (XDun - 1) * (XDun - 1) + (XDdeux - 1) * (XDdeux - 1);
            int compteurEuclide;
            int u;
            int i;
            int distStep = 1;
            for (u = 0; u < XT.GetLength(0); u++)
            {
                for (i = 0; i < XT.GetLength(1); i++)
                {
                    if (XT[u, i] == 0)
                    {
                        euclide[u, i] = compteurSaveEuclide;
                    }
                    else
                    {
                        euclide[u, i] = 0;
                    }
                }
            }
            //parcours de haut en bas + assignation des valeurs
            for (u = 0; u < euclide.GetLength(1); u++)
            {
                for (i = 1; i < euclide.GetLength(0); i++)
                {
                    //Console.WriteLine("check4"+i);
                    if (euclide[i, u] == 0)
                    {
                        distStep = 1;
                    }
                    if (euclide[i, u] != 0)
                    {
                        euclide[i, u] = euclide[i - 1, u] + distStep;
                        distStep += 2;
                    }
                }
            }

            for (u = 0; u < euclide.GetLength(1); u++)
            {
                for (i = euclide.GetLength(0) - 2; i >= 0; i--)
                {
                    if (euclide[i, u] == 0)
                    {
                        distStep = 1;
                    }
                    if (euclide[i, u] != 0)
                    {
                        compteurEuclide = euclide[i + 1, u] + distStep;
                        distStep += 2;
                        if (compteurEuclide < euclide[i, u])
                        {
                            euclide[i, u] = compteurEuclide;
                        }
                    }
                }
            }
            for (i = 0; i < XDun; i++)
            {

                // Copy row of vertical distances
                int[] distMatV = new int[XDdeux];
                for (int col = 0; col < XDdeux; col++)
                {
                    distMatV[col] = euclide[i, col];
                }

                for (int j = 0; j < XDdeux; j++)
                {
                    // Initialize minimum distance
                    int distMin = distMatV[j];

                    for (int k = 0; k < XDdeux; k++)
                    {
                        // Compare to column positions
                        int dist = distMatV[k] + (k - j) * (k - j);
                        if (distMin > dist)
                        {
                            distMin = dist; // New minimum distance
                        }
                    }

                    euclide[i, j] = distMin; // Assign minimum
                }
            }
            return euclide;
        }
    }
}


