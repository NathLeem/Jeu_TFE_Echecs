﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess.Frames;
using Chess.Pieces;


namespace Chess.Frames
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Grid grdPlate = new Grid();          //Plateau visuel du jeu
        public Button[,] cases = new Button[8, 8];  //Cases du plateau (en 8x8) tous intéragissables

        public Piece[,] memPlate = new Piece[8, 8]; //Plateau "logique" du jeu, toutes les opérations se feront ici
        public Piece[] pieces = new Piece[32];      //Liste des pièces du jeu

        SolidColorBrush lastColor;                  //Retiens la couleur de la prmière case cliquée

        int click = 0;              //Permet de faire un mouvement (0 : Aucune case cliquée; 1 : une case a déjà été choisie)
        string turn = "white";      //Tour par tour

        public int[] nLigne = new int[2];       //Numéros de lignes utilisés    
        public int[] nColonne = new int[2];     //Numéros de colonnes utilisés

        SetUpGame start = new SetUpGame();      //Structure qui lance le jeu

        /*DispatcherTimer timerWhite = new DispatcherTimer();
        DispatcherTimer timerBlack = new DispatcherTimer();

        int timeWhite = 0;
        int timeBlack = 0;*/
        public Game()
        {
            InitializeComponent();
            start.SetUpPlate(ref grdPlate, ref cases, ref this.gameScreen);
            start.PrepareGame(ref grdPlate);
            start.SetUpMem(ref pieces, ref memPlate);

            for (int i = 0; i < cases.GetLength(0); i++)
            {
                for (int j = 0; j < cases.GetLength(1); j++)
                {
                    cases[i, j].Click += new RoutedEventHandler(Play);  //Tous les boutons peuvent être utilisés pour interagir
                }
            }
        }

        public void Play(object sender, RoutedEventArgs e)  //Jouer
        {

            if (click == 0) //Aucune case encore choisie    
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);  //Extraction des coordonnées de la case cliquée
                if (cases[nColonne[0], nLigne[0]].Content != " ")   //La case choisie doit contenir une pièce
                {
                    if (memPlate[nColonne[0], nLigne[0]].Color == turn) //Le joueur a cliqué sur une de ses pièces
                    {
                        lastColor = (SolidColorBrush)cases[nColonne[0], nLigne[0]].Background;  //Sauvegarde la couleur initiale de la case choisie
                        cases[nColonne[0], nLigne[0]].Background = Brushes.Yellow;  //Affichage de la case qu'il a choisie (aide mémorielle)

                        click++;    //Première étape du tour terminée
                    }
                }
            }
            else
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click); //Extraction des coordonnées de la case cliquée

                if (nLigne[0] != nLigne[1] || nColonne[0] != nColonne[1])   //Le joueur ne peut pas cliquer sur la même case deux fois d'affilée
                {
                    if (AcceptMove(nColonne, nLigne))    //Le mouvement se fait que si le coup est accepté
                    {
                        if (CheckMove())
                        {
                            cases[nColonne[1], nLigne[1]].Content = cases[nColonne[0], nLigne[0]].Content;  //Déplacement du pion
                            cases[nColonne[0], nLigne[0]].Content = " ";    //Suppression de son ancienne positoion
                                                                            //
                            PostCheck();
                        }                       
                    }
                }
                click = 0;  //Fin du tour   

                cases[nColonne[0], nLigne[0]].Background = lastColor;   //Réatribution de la couleur initiale à la première case cliquée

                RefreshInfos(); //Actualisation des informations
            }
        }
        public bool AcceptMove(int[] nColonne, int[] nLigne)    //Fonction qui va vérifier la validité du mouvement
        {
            bool moveAccept = memPlate[nColonne[0], nLigne[0]].Moving(nColonne, nLigne, memPlate);  //Vérifie selon la pièce la validité du mouvement

            return moveAccept;  //Envoie du résultat
        }

        public void SplitName(string nomCase, ref int[] nLigne, ref int[] nColonne, int click)  //Fonction qui va permettre d'extraire en nombres entier les coordonnées x et y de la case qui a été cliquée
        {
            string[] nom = nomCase.Split('_');  //Sépare les coordonnées

            int.TryParse(nom[1], out nColonne[click]);  //Sortie de la coordonnée x 

            int.TryParse(nom[2], out nLigne[click]);    //Sortie de la coordonnée y      
        }

        public void PostCheck() //Fonction qui regarde si une fois le tour joué les rois sont en échecs
        {
            if (turn == "white")    //Si c'était le tour des blancs
            {
                if (pieces[15].IsChecked(memPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    check.Text = "ÉCHECS AUX NOIRS";    //Envoie de l'information
                    check.Foreground = Brushes.White;
                    check.Background = Brushes.Black;
                }
                else
                {
                    check.Text = "";    //Retrait de l'information
                    check.Background = Brushes.DarkCyan;

                    turn = "black"; //Trait aux noirs désormais
                }             
            }
            else
            {
                if (pieces[14].IsChecked(memPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    check.Text = "ÉCHECS AUX BLANCS";   //Envoie de l'information
                    check.Foreground = Brushes.Black;
                    check.Background = Brushes.White;

                }
                else
                {
                    check.Text = "";
                    check.Background = Brushes.DarkCyan;

                    turn = "white"; //Trait aux blancs
                }               
            }
        }

        public bool AnteCheck(Piece[,] tempMemPlate)
        {
            if (turn == "white")    //Si c'était le tour des blancs
            {
                if (pieces[15].IsChecked(tempMemPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (pieces[14].IsChecked(tempMemPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    return true;
                }
                else
                { 
                    return false;
                }
            }
        }

        public bool CheckMove() //Fonction qui vérifie si à la fin du tour d'un joueur dont le roi est en échec ce dernier ne l'est plus
        {
            Piece[,] tempMemPlate = new Piece[8,8];

            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                for (int j = 0; j < memPlate.GetLength(1); j++)
                {
                    tempMemPlate[i, j] = memPlate[i, j];
                }
            }

            tempMemPlate[nColonne[1], nLigne[1]] = tempMemPlate[nColonne[0], nLigne[0]];    //Déplacement du pion
            tempMemPlate[nColonne[0], nLigne[0]] = null;    //Suppression de son ancienne position

            if (!AnteCheck(tempMemPlate))
            {
                memPlate[nColonne[1], nLigne[1]] = memPlate[nColonne[0], nLigne[0]];    //Déplacement du pion
                memPlate[nColonne[0], nLigne[0]] = null;    //Suppression de son ancienne position
                return true;
            }

            return false;
        }

        public void RefreshInfos()  //Actualise les informations de la partie
        {
            if (turn == "white") //Informe le joueur à qui est-ce de joueur
            {
                tour.Background = Brushes.White;
                tour.Text = "Trait au blancs";
                tour.Foreground = Brushes.Black;
            }
            else    //Trait aux noirs
            {
                tour.Background = Brushes.Black;
                tour.Text = "Trait au noirs";
                tour.Foreground = Brushes.White;
            }
        }
    }
}
