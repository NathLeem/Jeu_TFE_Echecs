using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Chess
{
    struct SetUpGame
    {
        public void SetUpPlate(ref Grid grdPlate, ref Button[,] cases, ref Grid gameScreen)    //Fonction qui va créer le plateau : lignes et colonnes, cases et couleurs, préparation au positionnement des pions
        {
            // Création des colonnes et des lignes
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdPlate.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                grdPlate.RowDefinitions.Add(rowDef);
            }

            // Création des button avec des "?" et coloration des cases, les "?" permettant de se repérer pour placer les pièces dans les fonctions à venir
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cases[i, j] = new Button();

                    if (i < 2 || i > 5)
                    {
                        cases[i, j].Content = "?";
                    }

                    cases[i, j].FontSize = 50;

                    if ((i + 1) % 2 == 0)
                    {
                        if ((j + 1) % 2 != 0)
                        {
                            cases[i, j].Background = Brushes.Green;
                        }

                    }
                    else
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            cases[i, j].Background = Brushes.Green;
                        }
                    }

                    cases[i, j].Name = "B_" + i + "_" + j;   //Nom de la case : "B" pour dire bouton et les numéros de case - 1. Exemple : création de la case ligne 2 colonne 7 : B_1_6

                    Grid.SetColumn(cases[i, j], j);  //Positionnement de la case
                    Grid.SetRow(cases[i, j], i);
                    grdPlate.Children.Add(cases[i, j]);   //Ajout de la case
                }
            }
            Grid.SetRow(grdPlate, 1);    //Le plateau d'échec se met dans la deuxième ligne de la fenêtre
            gameScreen.Children.Add(grdPlate);  //Ajout du plateau
        }
        public void PrepareGame(ref Grid grdPlate)   //Fonction qui va préparer
        {
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

            foreach (Button button in grdPlate.Children.OfType<Button>())
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
                BitmapImage egypteBishopWhite = new BitmapImage();
                egypteBishopWhite.BeginInit();
                egypteBishopWhite.UriSource = new Uri("/SkinPieces/Egypt/BishopWhite.png", UriKind.Relative);
                egypteBishopWhite.EndInit();

                BitmapImage egypteBishopBlack = new BitmapImage();
                egypteBishopBlack.BeginInit();
                egypteBishopBlack.UriSource = new Uri("/SkinPieces/Egypt/BishopBlack.png", UriKind.Relative);
                egypteBishopBlack.EndInit();


                BitmapImage egypteHorseWhite = new BitmapImage();
                egypteHorseWhite.BeginInit();
                egypteHorseWhite.UriSource = new Uri("/SkinPieces/Egypt/HorseWhite.png", UriKind.Relative);
                egypteHorseWhite.EndInit();

                BitmapImage egypteHorseBlack = new BitmapImage();
                egypteHorseBlack.BeginInit();
                egypteHorseBlack.UriSource = new Uri("/SkinPieces/Egypt/HorseBlack.png", UriKind.Relative);
                egypteHorseBlack.EndInit();


                BitmapImage egypteKingWhite = new BitmapImage();
                egypteKingWhite.BeginInit();
                egypteKingWhite.UriSource = new Uri("/SkinPieces/Egypt/KingWhite.png", UriKind.Relative);
                  egypteKingWhite.EndInit();

                BitmapImage egypteKingBlack = new BitmapImage();
                egypteKingBlack.BeginInit();
                egypteKingBlack.UriSource = new Uri("/SkinPieces/Egypt/KingBlack.png", UriKind.Relative);
                egypteKingBlack.EndInit();


                BitmapImage egyptePawnWhite = new BitmapImage();
                egyptePawnWhite.BeginInit();
                egyptePawnWhite.UriSource = new Uri("/SkinPieces/Egypt/PawnWhite.png", UriKind.Relative);
                egyptePawnWhite.EndInit();

                BitmapImage egyptePawnBlack = new BitmapImage();
                egyptePawnBlack.BeginInit();
                egyptePawnBlack.UriSource = new Uri("/SkinPieces/Egypt/PawnBlack.png", UriKind.Relative);
                egyptePawnBlack.EndInit();


                BitmapImage egypteQueenWhite = new BitmapImage();
                egypteQueenWhite.BeginInit();
                egypteQueenWhite.UriSource = new Uri("/SkinPieces/Egypt/QueenWhite.png", UriKind.Relative);
                egypteQueenWhite.EndInit();

                BitmapImage egypteQueenBlack = new BitmapImage();
                egypteQueenBlack.BeginInit();
                egypteQueenBlack.UriSource = new Uri("/SkinPieces/Egypt/QueenBlack.png", UriKind.Relative);
                egypteQueenBlack.EndInit();


                BitmapImage egypteTowerWhite = new BitmapImage();
                egypteTowerWhite.BeginInit();
                egypteTowerWhite.UriSource = new Uri("/SkinPieces/Egypt/TowerWhite.png", UriKind.Relative);
                egypteTowerWhite.EndInit();

                BitmapImage egypteTowerBlack = new BitmapImage();
                egypteTowerBlack.BeginInit();
                egypteTowerBlack.UriSource = new Uri("/SkinPieces/Egypt/TowerBlack.png", UriKind.Relative);
                egypteTowerBlack.EndInit();

                egypte = new List<BitmapImage>()
            {
                egypteTowerBlack, egypteHorseBlack, egypteBishopBlack, egypteQueenBlack, egypteKingBlack, egypteBishopBlack, egypteHorseBlack, egypteTowerBlack,
                egyptePawnBlack, egyptePawnBlack, egyptePawnBlack, egyptePawnBlack, egyptePawnBlack, egyptePawnBlack, egyptePawnBlack, egyptePawnBlack,
                egyptePawnWhite, egyptePawnWhite, egyptePawnWhite, egyptePawnWhite, egyptePawnWhite, egyptePawnWhite, egyptePawnWhite, egyptePawnWhite,
                egypteTowerWhite, egypteHorseWhite, egypteBishopWhite, egypteQueenWhite, egypteKingWhite, egypteBishopWhite, egypteHorseWhite, egypteTowerWhite
            };
        }
       
        private void SkinCar(out List<BitmapImage> car)     //Fonction qui met prêt à utilisation les skins des véhicules
        {
            BitmapImage carBishopWhite = new BitmapImage();
            carBishopWhite.BeginInit();
            carBishopWhite.UriSource = new Uri("/SkinPieces/Cars/BishopWhite.png", UriKind.Relative);
            carBishopWhite.EndInit();

            BitmapImage carBishopBlack = new BitmapImage();
            carBishopBlack.BeginInit();
            carBishopBlack.UriSource = new Uri("/SkinPieces/Cars/BishopBlack.png", UriKind.Relative);
            carBishopBlack.EndInit();


            BitmapImage carHorseWhite = new BitmapImage();
            carHorseWhite.BeginInit();
            carHorseWhite.UriSource = new Uri("/SkinPieces/Cars/HorseWhite.png", UriKind.Relative);
            carHorseWhite.EndInit();

            BitmapImage carHorseBlack = new BitmapImage();
            carHorseBlack.BeginInit();
            carHorseBlack.UriSource = new Uri("/SkinPieces/Cars/HorseBlack.png", UriKind.Relative);
            carHorseBlack.EndInit();


            BitmapImage carKingWhite = new BitmapImage();
            carKingWhite.BeginInit();
            carKingWhite.UriSource = new Uri("/SkinPieces/Cars/KingWhite.png", UriKind.Relative);
            carKingWhite.EndInit();

            BitmapImage carKingBlack = new BitmapImage();
            carKingBlack.BeginInit();
            carKingBlack.UriSource = new Uri("/SkinPieces/Cars/KingBlack.png", UriKind.Relative);
            carKingBlack.EndInit();


            BitmapImage carPawnWhite = new BitmapImage();
            carPawnWhite.BeginInit();
            carPawnWhite.UriSource = new Uri("/SkinPieces/Cars/PawnWhite.png", UriKind.Relative);
            carPawnWhite.EndInit();

            BitmapImage carPawnBlack = new BitmapImage();
            carPawnBlack.BeginInit();
            carPawnBlack.UriSource = new Uri("/SkinPieces/Cars/PawnBlack.png", UriKind.Relative);
            carPawnBlack.EndInit();


            BitmapImage carQueenWhite = new BitmapImage();
            carQueenWhite.BeginInit();
            carQueenWhite.UriSource = new Uri("/SkinPieces/Cars/QueenWhite.png", UriKind.Relative);
            carQueenWhite.EndInit();

            BitmapImage carQueenBlack = new BitmapImage();
            carQueenBlack.BeginInit();
            carQueenBlack.UriSource = new Uri("/SkinPieces/Cars/QueenBlack.png", UriKind.Relative);
            carQueenBlack.EndInit();


            BitmapImage carTowerWhite = new BitmapImage();
            carTowerWhite.BeginInit();
            carTowerWhite.UriSource = new Uri("/SkinPieces/Cars/TowerWhite.png", UriKind.Relative);
            carTowerWhite.EndInit();

            BitmapImage carTowerBlack = new BitmapImage();
            carTowerBlack.BeginInit();
            carTowerBlack.UriSource = new Uri("/SkinPieces/Cars/TowerBlack.png", UriKind.Relative);
            carTowerBlack.EndInit();

            car = new List<BitmapImage>()
            {
                carTowerBlack, carHorseBlack, carBishopBlack, carQueenBlack, carKingBlack, carBishopBlack, carHorseBlack, carTowerBlack,
                carPawnBlack, carPawnBlack, carPawnBlack, carPawnBlack, carPawnBlack, carPawnBlack, carPawnBlack, carPawnBlack,
                carPawnWhite, carPawnWhite, carPawnWhite, carPawnWhite, carPawnWhite, carPawnWhite, carPawnWhite, carPawnWhite,
                carTowerWhite, carHorseWhite, carBishopWhite, carQueenWhite, carKingWhite, carBishopWhite, carHorseWhite, carTowerWhite
            };
        }
        private void SkinTeletubbies(out List<BitmapImage> tele)    //Fonction qui met prêt à utilisation les skins des Télétubbies
        {
            BitmapImage teleBishop = new BitmapImage();
            teleBishop.BeginInit();
            teleBishop.UriSource = new Uri("/SkinPieces/Teletubbies/Bishop.png", UriKind.Relative);
            teleBishop.EndInit();

            BitmapImage teleHorse = new BitmapImage();
            teleHorse.BeginInit();
            teleHorse.UriSource = new Uri("/SkinPieces/Teletubbies/Horse.png", UriKind.Relative);
            teleHorse.EndInit();

            BitmapImage teleKing = new BitmapImage();
            teleKing.BeginInit();
            teleKing.UriSource = new Uri("/SkinPieces/Teletubbies/King.png", UriKind.Relative);
            teleKing.EndInit();

            BitmapImage telePawn = new BitmapImage();
            telePawn.BeginInit();
            telePawn.UriSource = new Uri("/SkinPieces/Teletubbies/Pawn.png", UriKind.Relative);
            telePawn.EndInit();

            BitmapImage teleQueen = new BitmapImage();
            teleQueen.BeginInit();
            teleQueen.UriSource = new Uri("/SkinPieces/Teletubbies/Queen.png", UriKind.Relative);
            teleQueen.EndInit();

            BitmapImage teleTower = new BitmapImage();
            teleTower.BeginInit();
            teleTower.UriSource = new Uri("/SkinPieces/Teletubbies/Tower.png", UriKind.Relative);
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
            defaultBishop.UriSource = new Uri("/SkinPieces/Default/Bishop.png", UriKind.Relative);
            defaultBishop.EndInit();

            BitmapImage defaultHorse = new BitmapImage();
            defaultHorse.BeginInit();
            defaultHorse.UriSource = new Uri("/SkinPieces/Default/Horse.png", UriKind.Relative);
            defaultHorse.EndInit();

            BitmapImage defaultKing = new BitmapImage();
            defaultKing.BeginInit();
            defaultKing.UriSource = new Uri("/SkinPieces/Default/King.png", UriKind.Relative);
            defaultKing.EndInit();

            BitmapImage defaultPawn = new BitmapImage();
            defaultPawn.BeginInit();
            defaultPawn.UriSource = new Uri("/SkinPieces/Default/Pawn.png", UriKind.Relative);
            defaultPawn.EndInit();

            BitmapImage defaultQueen = new BitmapImage();
            defaultQueen.BeginInit();
            defaultQueen.UriSource = new Uri("/SkinPieces/Default/Queen.png", UriKind.Relative);
            defaultQueen.EndInit();

            BitmapImage defaultTower = new BitmapImage();
            defaultTower.BeginInit();
            defaultTower.UriSource = new Uri("/SkinPieces/Default/Tower.png", UriKind.Relative);
            defaultTower.EndInit();

            skindef = new List<BitmapImage>()
            {
                defaultTower, defaultHorse, defaultBishop, defaultQueen, defaultKing, defaultBishop, defaultHorse, defaultTower,
                defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn,
                defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn, defaultPawn,
                defaultTower, defaultHorse, defaultBishop, defaultQueen, defaultKing, defaultBishop, defaultHorse, defaultTower
            };
        }
        public void SetUpMem(ref Piece[] pieces, ref Piece[,] memPlate)  //Fonction qui va placer les pièces artificielles/logiques dans le plateau mémoire et donner toutes leurs propriétés respectives
        {
            pieces[0] = new Tower(new int[2] { 0, 0 }, "black");
            memPlate[0, 0] = pieces[0];

            pieces[1] = new Tower(new int[2] { 0, 7 }, "black");
            memPlate[0, 7] = pieces[1];

            pieces[2] = new Tower(new int[2] { 7, 0 }, "white");
            memPlate[7, 0] = pieces[2];

            pieces[3] = new Tower(new int[2] { 7, 7 }, "white");
            memPlate[7, 7] = pieces[3];


            pieces[4] = new Horse(new int[2] { 0, 1 }, "black");
            memPlate[0, 1] = pieces[4];

            pieces[5] = new Horse(new int[2] { 0, 6 }, "black");
            memPlate[0, 6] = pieces[5];   
                
            pieces[6] = new Horse(new int[2] { 7, 1 }, "white");
            memPlate[7, 1] = pieces[6];

            pieces[7] = new Horse(new int[2] { 7, 6 }, "white");
            memPlate[7, 6] = pieces[7];


            pieces[8] = new Bishop(new int[2] { 0, 2 }, "black");
            memPlate[0, 2] = pieces[8];

            pieces[9] = new Bishop(new int[2] { 0, 5 }, "black");
            memPlate[0, 5] = pieces[9];

            pieces[10] = new Bishop(new int[2] { 7, 2 }, "white");
            memPlate[7, 2] = pieces[10];

            pieces[11] = new Bishop(new int[2] { 7, 5 }, "white");
            memPlate[7, 5] = pieces[11];


            pieces[12] = new Queen(new int[2] { 0, 3 }, "black");
            memPlate[0, 3] = pieces[12];

            pieces[13] = new Queen(new int[2] { 7, 3 }, "white");
            memPlate[7, 3] = pieces[13];


            pieces[14] = new King(new int[2] { 0, 4 }, "black");
            memPlate[0, 4] = pieces[14];

            pieces[15] = new King(new int[2] { 7, 4 }, "white");
            memPlate[7, 4] = pieces[15];

            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pieces[16 + i] = new Pawn(new int[2] { 1, i }, "black");
                memPlate[1, i] = pieces[16 + i];
            }

            int[] pp2 = new int[2] { 6, 0 };
            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pieces[24 + i] = new Pawn(new int[2] { 6, i }, "white");
                memPlate[6, i] = pieces[24 + i];
            }

        }
    }
}
