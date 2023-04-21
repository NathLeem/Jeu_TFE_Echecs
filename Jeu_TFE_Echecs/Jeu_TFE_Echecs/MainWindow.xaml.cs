using System;
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
using System.Windows.Threading;
using Jeu_TFE_Echecs.Pawns;

namespace Jeu_TFE_Echecs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid grdPlate = new Grid();
        Button[,] cases = new Button[8, 8];
        
        Piece[,] memPlate = new Piece[8, 8];
        Piece[] pieces = new Piece[32];

        SolidColorBrush lastColor;

        int click = 0;
        string turn = "white";

        public int[] nLigne = new int[2];
        public int[] nColonne = new int[2];

        /*DispatcherTimer timerWhite = new DispatcherTimer();
        DispatcherTimer timerBlack = new DispatcherTimer();

        int timeWhite = 0;
        int timeBlack = 0;*/

        public MainWindow()
        {
            InitializeComponent();            
            SetUpPlate();            
            SetUpGame();
            SetUpMem();

            for (int i = 0; i < cases.GetLength(0); i++)
            {
                for (int j = 0; j < cases.GetLength(1); j++)
                {
                    cases[i, j].Click += new RoutedEventHandler(Play);
                }
            }

            
        }
        public void SetUpPlate()
        {
        
            // Création des colonnes et des lignes
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdPlate.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                grdPlate.RowDefinitions.Add(rowDef);
            }

            // Création des button avec des "?" et coloration des cases
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

                    cases[i, j].Name = "B_" + i + "_" + j;

                    Grid.SetColumn(cases[i, j], j);
                    Grid.SetRow(cases[i, j], i);
                    grdPlate.Children.Add(cases[i, j]);
                }
            }

            Grid.SetRow(grdPlate, 1);
            game.Children.Add(grdPlate);          
        }
        public void SetUpGame()
        {
            /*List<string> pieces = new List<string>()
            {
                "♜","♞","♝","♛","♚","♝","♞","♜",
                "♟","♟️","♟️","♟️","♟️","♟️","♟️","♟️",
                "♙","♙","♙","♙","♙","♙","♙","♙",
                "♖","♘","♗","♕","♔","♗","♘","♖"
            };*/
            List<BitmapImage> pieces;

            SkinTeletubbies(out pieces);
            SkinEgypte(out pieces);
            SkinCar(out pieces);
            SkinDefault(out pieces);

            foreach (Button button in grdPlate.Children.OfType<Button>())
            {
                if (button.Content == "?")
                {
                    Image imBouton = new Image();
                    imBouton.Source = pieces[0];
                    imBouton.Stretch = System.Windows.Media.Stretch.None;
                    button.Content = imBouton;

                    pieces.RemoveAt(0);
                }
                else
                {
                    button.Content = " ";
                }

            }

            /*timerWhite.Tick += new EventHandler(Timer_Tick);
            timerWhite.Interval = (TimeSpan)1000;
            timerWhite.Start();*/
        }

        public void RefreshInfos()
        {
            if(turn == "white")
            {
                tour.Background = Brushes.White;
                tour.Text = "Trait au blancs";
                tour.Foreground = Brushes.Black;
            }
            else
            {           
                tour.Background = Brushes.Black;
                tour.Text = "Trait au noirs";
                tour.Foreground = Brushes.White;
            }
        }

        public void SetUpMem()
        {
            pieces[0] = new Tower(new int[2] { 0, 0 }, "black", "tower", 0);
            memPlate[0, 0] = pieces[0];

            pieces[1] = new Tower(new int[2] { 0, 7 }, "black", "tower", 1);
            memPlate[0, 7] = pieces[1];

            pieces[2] = new Tower(new int[2] { 7, 0 }, "white", "tower", 2);
            memPlate[7, 0] = pieces[2];

            pieces[3] = new Tower(new int[2] { 7, 7 }, "white", "tower", 3);
            memPlate[7, 7] = pieces[3];


            pieces[4] = new Horse(new int[2] { 0, 1 }, "black", "horse", 4);
            memPlate[0, 1] = pieces[4];

            pieces[5] = new Horse(new int[2] { 0, 6 }, "black", "horse", 5);
            memPlate[0, 6] = pieces[5];

            pieces[6] = new Horse(new int[2] { 7, 1 }, "white", "horse", 6);
            memPlate[7, 1] = pieces[6];

            pieces[7] = new Horse(new int[2] { 7, 6 }, "white", "horse", 7);
            memPlate[7, 6] = pieces[7];


            pieces[8] = new Bishop(new int[2] { 0, 2 }, "black", "bishop", 8);
            memPlate[0, 2] = pieces[8];

            pieces[9] = new Bishop(new int[2] { 0, 5 }, "black", "bishop", 9);
            memPlate[0, 5] = pieces[9];

            pieces[10] = new Bishop(new int[2] { 7, 2 }, "white", "bishop", 10);
            memPlate[7, 2] = pieces[10];

            pieces[11] = new Bishop(new int[2] { 7, 5 }, "white", "bishop", 11);
            memPlate[7, 5] = pieces[11];


            pieces[12] = new Queen(new int[2] { 0, 3 }, "black", "queen", 12);
            memPlate[0, 3] = pieces[12];

            pieces[13] = new Queen(new int[2] { 7, 3 }, "white", "queen", 13);
            memPlate[7, 3] = pieces[13];


            pieces[14] = new King(new int[2] { 0, 4 }, "black", "king", 14);
            memPlate[0, 4] = pieces[14];

            pieces[15] = new King(new int[2] { 7, 4 }, "white", "king", 15);
            memPlate[7, 4] = pieces[15];

            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pieces[16 + i] = new Pawn(new int[2] { 1, 0 }, "black", "pawn", (sbyte)(16 + i));
                memPlate[1, i] = pieces[16 + i];
            }

            int[] pp2 = new int[2] { 6, 0 };
            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pieces[24 + i] = new Pawn(new int[2] { 6, 0 }, "white", "pawn", (sbyte)(24 + i));
                memPlate[6, i] = pieces[24 + i];
            }

        }
        public void Play(object sender, RoutedEventArgs e)
        {
            
            if (click == 0)
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);
                if (cases[nColonne[0], nLigne[0]].Content != " ")
                {
                    if (memPlate[nColonne[0], nLigne[0]].Color == turn)
                    {
                        lastColor = (SolidColorBrush)cases[nColonne[0], nLigne[0]].Background;
                        cases[nColonne[0], nLigne[0]].Background = Brushes.Yellow;

                        click++;
                    }                         
                }
            }
            else
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);
                
                if (nLigne[0] != nLigne[1] || nColonne[0] != nColonne[1])
                {                 
                    if(AcceptMove(nColonne, nLigne))
                    {
                        cases[nColonne[1], nLigne[1]].Content = cases[nColonne[0], nLigne[0]].Content;
                        cases[nColonne[0], nLigne[0]].Content = " ";

                        memPlate[nColonne[1], nLigne[1]] = memPlate[nColonne[0], nLigne[0]];
                        memPlate[nColonne[0], nLigne[0]] = null;

                        if (turn == "white")
                        {
                            turn = "black";
                        }
                        else
                        {
                            turn = "white";
                        }


                    }
                    
                }
                click = 0;

                cases[nColonne[0], nLigne[0]].Background = lastColor;
            
                RefreshInfos();
            }
            
        }
        public bool AcceptMove(int[] nColonne, int[] nLigne)
        {
            bool moveAccept = memPlate[nColonne[0], nLigne[0]].Moving(nColonne, nLigne, memPlate);

            return moveAccept;
        }

        public void SplitName(string nomCase, ref int[] nLigne, ref int[] nColonne, int click)
        {
            string[] nom = nomCase.Split('_');

            int.TryParse(nom[1], out nColonne[click]);

            int.TryParse(nom[2], out nLigne[click]);
            
        }

        public void SkinEgypte(out List<BitmapImage> egypte)
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
        public void SkinCar(out List<BitmapImage> car)
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
        public void SkinTeletubbies(out List<BitmapImage> tele)
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

        public void SkinDefault(out List<BitmapImage> skindef)
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

        /*public void Timer_Tick(object sender, EventArgs e)
        {
            
            if(turn == "white")
            {
                timeWhite++;
                afficheTime.Text = (timeWhite).ToString("0.0s");
            }
        }*/
    }
}
