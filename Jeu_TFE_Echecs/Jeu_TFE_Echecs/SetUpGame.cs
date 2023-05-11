using Jeu_TFE_Echecs.Pawns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jeu_TFE_Echecs
{
    struct SetUpGame
    {
        public void SetUpPlate()    //Fonction qui va créer le plateau : lignes et colonnes, cases et couleurs, préparation au positionnement des pions
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            // Création des colonnes et des lignes
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                mainWindow.grdPlate.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                mainWindow.grdPlate.RowDefinitions.Add(rowDef);
            }

            // Création des button avec des "?" et coloration des cases, les "?" permettant de se repérer pour placer les pièces dans les fonctions à venir
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mainWindow.cases[i, j] = new Button();

                    if (i < 2 || i > 5)
                    {
                        mainWindow.cases[i, j].Content = "?";
                    }

                    mainWindow.cases[i, j].FontSize = 50;

                    if ((i + 1) % 2 == 0)
                    {
                        if ((j + 1) % 2 != 0)
                        {
                            mainWindow.cases[i, j].Background = Brushes.Green;
                        }

                    }
                    else
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            mainWindow.cases[i, j].Background = Brushes.Green;
                        }
                    }

                    mainWindow.cases[i, j].Name = "B_" + i + "_" + j;   //Nom de la case : "B" pour dire bouton et les numéros de case - 1. Exemple : création de la case ligne 2 colonne 7 : B_1_6

                    Grid.SetColumn(mainWindow.cases[i, j], j);  //Positionnement de la case
                    Grid.SetRow(mainWindow.cases[i, j], i);
                    mainWindow.grdPlate.Children.Add(mainWindow.cases[i, j]);   //Ajout de la case
                }
            }

            Grid.SetRow(mainWindow.grdPlate, 1);    //Le plateau d'échec se met dans la deuxième ligne de la fenêtre
            mainWindow.game.Children.Add(mainWindow.grdPlate);  //Ajout du plateau
        }
        public void PrepareGame()   //Fonction qui va préparer
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            /*List<string> pieces = new List<string>()
            {
                "♜","♞","♝","♛","♚","♝","♞","♜",
                "♟","♟️","♟️","♟️","♟️","♟️","♟️","♟️",
                "♙","♙","♙","♙","♙","♙","♙","♙",
                "♖","♘","♗","♕","♔","♗","♘","♖"
            };*/
            List<BitmapImage> pieces;   //Liste des skins. NOTE : les pièces sont déjà placées dans l'ordre dans la liste comme si ils étaient déjà sur le plateau, de sorte à ce que l'on doit parcourir que le premier indice de la liste pour palcer les pièces

            SkinCar(out pieces);            //Skins des véhicules
            SkinDefault(out pieces);        //Skins par défaut
            SkinTeletubbies(out pieces);    //Skins des Télétubbies
            SkinEgypte(out pieces);         //Skins des dieux égyptiens 

            foreach (Button button in mainWindow.grdPlate.Children.OfType<Button>())
            {
                if (button.Content == "?")  //Là où il y a des points d'interrogations, on place une pièce
                {
                    Image imBouton = new Image();
                    imBouton.Source = pieces[0];
                    imBouton.Stretch = System.Windows.Media.Stretch.None;
                    imBouton.Stretch = Stretch.Uniform;
                    button.Content = imBouton;  //Placement de la pièce

                    pieces.RemoveAt(0);
                }
                else
                {
                    button.Content = " ";   //Rien n'est positionné ici
                }

            }

            /*timerWhite.Tick += new EventHandler(Timer_Tick);
            timerWhite.Interval = (TimeSpan)1000;
            timerWhite.Start();*/
        }

        private void SkinEgypte(out List<BitmapImage> egypte)   //Fonction qui met prêt à utilisation les skins des dieux Egyptiens
        {
            BitmapImage egypteBishop = new BitmapImage();
            egypteBishop.BeginInit();
            egypteBishop.UriSource = new Uri("SkinPawn/Egypte/Bishop.png", UriKind.Relative);
            egypteBishop.EndInit();

            BitmapImage egypteHorse = new BitmapImage();
            egypteHorse.BeginInit();
            egypteHorse.UriSource = new Uri("SkinPawn/Egypte/Horse.png", UriKind.Relative);
            egypteHorse.EndInit();

            BitmapImage egypteKing = new BitmapImage();
            egypteKing.BeginInit();
            egypteKing.UriSource = new Uri("SkinPawn/Egypte/King.png", UriKind.Relative);
            egypteKing.EndInit();

            BitmapImage egyptePawn = new BitmapImage();
            egyptePawn.BeginInit();
            egyptePawn.UriSource = new Uri("SkinPawn/Egypte/Pawn.png", UriKind.Relative);
            egyptePawn.EndInit();

            BitmapImage egypteQueen = new BitmapImage();
            egypteQueen.BeginInit();
            egypteQueen.UriSource = new Uri("SkinPawn/Egypte/Queen.png", UriKind.Relative);
            egypteQueen.EndInit();

            BitmapImage egypteTower = new BitmapImage();
            egypteTower.BeginInit();
            egypteTower.UriSource = new Uri("SkinPawn/Egypte/Tower.png", UriKind.Relative);
            egypteTower.EndInit();

            egypte = new List<BitmapImage>()
            {
                egypteTower, egypteHorse, egypteBishop, egypteQueen, egypteKing, egypteBishop, egypteHorse, egypteTower,
                egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn,
                egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn, egyptePawn,
                egypteTower, egypteHorse, egypteBishop, egypteQueen, egypteKing, egypteBishop, egypteHorse, egypteTower
            };
        }
        private void SkinCar(out List<BitmapImage> car)     //Fonction qui met prêt à utilisation les skins des véhicules
        {
            BitmapImage carBishop = new BitmapImage();
            carBishop.BeginInit();
            carBishop.UriSource = new Uri("SkinPawn/Car/Bishop.png", UriKind.Relative);
            carBishop.EndInit();

            BitmapImage carHorse = new BitmapImage();
            carHorse.BeginInit();
            carHorse.UriSource = new Uri("SkinPawn/Car/Horse.png", UriKind.Relative);
            carHorse.EndInit();

            BitmapImage carKing = new BitmapImage();
            carKing.BeginInit();
            carKing.UriSource = new Uri("SkinPawn/Car/King.png", UriKind.Relative);
            carKing.EndInit();

            BitmapImage carPawn = new BitmapImage();
            carPawn.BeginInit();
            carPawn.UriSource = new Uri("SkinPawn/Car/Pawn.png", UriKind.Relative);
            carPawn.EndInit();

            BitmapImage carQueen = new BitmapImage();
            carQueen.BeginInit();
            carQueen.UriSource = new Uri("SkinPawn/Car/Queen.png", UriKind.Relative);
            carQueen.EndInit();

            BitmapImage carTower = new BitmapImage();
            carTower.BeginInit();
            carTower.UriSource = new Uri("SkinPawn/Car/Tower.png", UriKind.Relative);
            carTower.EndInit();

            car = new List<BitmapImage>()
            {
                carTower, carHorse, carBishop, carQueen, carKing, carBishop, carHorse, carTower,
                carPawn, carPawn, carPawn, carPawn, carPawn, carPawn, carPawn, carPawn,
                carPawn, carPawn, carPawn, carPawn, carPawn, carPawn, carPawn, carPawn,
                carTower, carHorse, carBishop, carQueen, carKing, carBishop, carHorse, carTower
            };
        }
        private void SkinTeletubbies(out List<BitmapImage> tele)    //Fonction qui met prêt à utilisation les skins des Télétubbies
        {
            BitmapImage teleBishop = new BitmapImage();
            teleBishop.BeginInit();
            teleBishop.UriSource = new Uri("SkinPawn/Teletubbies/Bishop.png", UriKind.Relative);
            teleBishop.EndInit();

            BitmapImage teleHorse = new BitmapImage();
            teleHorse.BeginInit();
            teleHorse.UriSource = new Uri("SkinPawn/Teletubbies/Horse.png", UriKind.Relative);
            teleHorse.EndInit();

            BitmapImage teleKing = new BitmapImage();
            teleKing.BeginInit();
            teleKing.UriSource = new Uri("SkinPawn/Teletubbies/King.png", UriKind.Relative);
            teleKing.EndInit();

            BitmapImage telePawn = new BitmapImage();
            telePawn.BeginInit();
            telePawn.UriSource = new Uri("SkinPawn/Teletubbies/Pawn.png", UriKind.Relative);
            telePawn.EndInit();

            BitmapImage teleQueen = new BitmapImage();
            teleQueen.BeginInit();
            teleQueen.UriSource = new Uri("SkinPawn/Teletubbies/Queen.png", UriKind.Relative);
            teleQueen.EndInit();

            BitmapImage teleTower = new BitmapImage();
            teleTower.BeginInit();
            teleTower.UriSource = new Uri("SkinPawn/Teletubbies/Tower.png", UriKind.Relative);
            teleTower.EndInit();

            tele = new List<BitmapImage>()
            {
                teleTower, teleHorse, teleBishop, teleQueen, teleKing, teleBishop, teleHorse, teleTower,
                telePawn, telePawn, telePawn, telePawn, telePawn, telePawn, telePawn, telePawn,
                telePawn, telePawn, telePawn, telePawn, telePawn, telePawn, telePawn, telePawn,
                teleTower, teleHorse, teleBishop, teleQueen, teleKing, teleBishop, teleHorse, teleTower
            };
        }

        private void SkinDefault(out List<BitmapImage> skindef)      //Fonction qui met prêt à utilisation les skins par défaut 
        {
            BitmapImage defaultBishop = new BitmapImage();
            defaultBishop.BeginInit();
            defaultBishop.UriSource = new Uri("SkinPawn/default/Bishop.png", UriKind.Relative);
            defaultBishop.EndInit();

            BitmapImage defaultHorse = new BitmapImage();
            defaultHorse.BeginInit();
            defaultHorse.UriSource = new Uri("SkinPawn/default/Horse.png", UriKind.Relative);
            defaultHorse.EndInit();

            BitmapImage defaultKing = new BitmapImage();
            defaultKing.BeginInit();
            defaultKing.UriSource = new Uri("SkinPawn/default/King.png", UriKind.Relative);
            defaultKing.EndInit();

            BitmapImage defaultPawn = new BitmapImage();
            defaultPawn.BeginInit();
            defaultPawn.UriSource = new Uri("SkinPawn/default/Pawn.png", UriKind.Relative);
            defaultPawn.EndInit();

            BitmapImage defaultQueen = new BitmapImage();
            defaultQueen.BeginInit();
            defaultQueen.UriSource = new Uri("SkinPawn/default/Queen.png", UriKind.Relative);
            defaultQueen.EndInit();

            BitmapImage defaultTower = new BitmapImage();
            defaultTower.BeginInit();
            defaultTower.UriSource = new Uri("SkinPawn/default/Tower.png", UriKind.Relative);
            defaultTower.EndInit();

            skindef = new List<BitmapImage>()
            {
                defaultTower, defaultHorse, defaultBishop, defaultQueen, defaultKing, defaultBishop, defaultHorse, defaultTower,
                defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn,
                defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn,
                defaultTower, defaultHorse, defaultBishop, defaultQueen, defaultKing, defaultBishop, defaultHorse, defaultTower
            };
        }
        public void SetUpMem()  //Fonction qui va placer les pièces artificielles/logiques dans le plateau mémoire et donner toutes leurs propriétés respectives
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            mainWindow.pieces[0] = new Tower(new int[2] { 0, 0 }, "black");
            mainWindow.memPlate[0, 0] = mainWindow.pieces[0];

            mainWindow.pieces[1] = new Tower(new int[2] { 0, 7 }, "black");
            mainWindow.memPlate[0, 7] = mainWindow.pieces[1];

            mainWindow.pieces[2] = new Tower(new int[2] { 7, 0 }, "white");
            mainWindow.memPlate[7, 0] = mainWindow.pieces[2];

            mainWindow.pieces[3] = new Tower(new int[2] { 7, 7 }, "white");
            mainWindow.memPlate[7, 7] = mainWindow.pieces[3];


            mainWindow.pieces[4] = new Horse(new int[2] { 0, 1 }, "black");
            mainWindow.memPlate[0, 1] = mainWindow.pieces[4];

            mainWindow.pieces[5] = new Horse(new int[2] { 0, 6 }, "black");
            mainWindow.memPlate[0, 6] = mainWindow.pieces[5];   
                
            mainWindow.pieces[6] = new Horse(new int[2] { 7, 1 }, "white");
            mainWindow.memPlate[7, 1] = mainWindow.pieces[6];

            mainWindow.pieces[7] = new Horse(new int[2] { 7, 6 }, "white");
            mainWindow.memPlate[7, 6] = mainWindow.pieces[7];


            mainWindow.pieces[8] = new Bishop(new int[2] { 0, 2 }, "black");
            mainWindow.memPlate[0, 2] = mainWindow.pieces[8];

            mainWindow.pieces[9] = new Bishop(new int[2] { 0, 5 }, "black");
            mainWindow.memPlate[0, 5] = mainWindow.pieces[9];

            mainWindow.pieces[10] = new Bishop(new int[2] { 7, 2 }, "white");
            mainWindow.memPlate[7, 2] = mainWindow.pieces[10];

            mainWindow.pieces[11] = new Bishop(new int[2] { 7, 5 }, "white");
            mainWindow.memPlate[7, 5] = mainWindow.pieces[11];


            mainWindow.pieces[12] = new Queen(new int[2] { 0, 3 }, "black");
            mainWindow.memPlate[0, 3] = mainWindow.pieces[12];

            mainWindow.pieces[13] = new Queen(new int[2] { 7, 3 }, "white");
            mainWindow.memPlate[7, 3] = mainWindow.pieces[13];


            mainWindow.pieces[14] = new King(new int[2] { 0, 4 }, "black");
            mainWindow.memPlate[0, 4] = mainWindow.pieces[14];

            mainWindow.pieces[15] = new King(new int[2] { 7, 4 }, "white");
            mainWindow.memPlate[7, 4] = mainWindow.pieces[15];

            for (int i = 0; i < mainWindow.memPlate.GetLength(0); i++)
            {
                mainWindow.pieces[16 + i] = new Pawn(new int[2] { 1, 0 }, "black");
                mainWindow.memPlate[1, i] = mainWindow.pieces[16 + i];
            }

            int[] pp2 = new int[2] { 6, 0 };
            for (int i = 0; i < mainWindow.memPlate.GetLength(0); i++)
            {
                mainWindow.pieces[24 + i] = new Pawn(new int[2] { 6, 0 }, "white");
                mainWindow.memPlate[6, i] = mainWindow.pieces[24 + i];
            }

        }

    }
}
