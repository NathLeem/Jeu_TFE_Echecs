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
using Jeu_TFE_Echecs.Pawns;

namespace Jeu_TFE_Echecs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] cases = new Button[8, 8];
        Piece[,] memPlate = new Piece[8, 8];

        int click = 0;

        public int[] nLigne = new int[2];
        public int[] nColonne = new int[2];
        public MainWindow()
        {
            InitializeComponent();
            Interface();
            SetUpGame();
            SetUpMem();

            for (int i = 0; i < cases.GetLength(0); i++)
            {
                for (int j = 0; j < cases.GetLength(1); j++)
                {
                    cases[i, j].Click += new RoutedEventHandler(ShowCases);
                }
            }
        }
        public void Interface()
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


        }
        public void SetUpGame()
        {
            List<string> pieces = new List<string>()
            {
                "♜","♞","♝","♛","♚","♝","♞","♜",
                "♟","♟️","♟️","♟️","♟️","♟️","♟️","♟️",
                "♙","♙","♙","♙","♙","♙","♙","♙",
                "♖","♘","♗","♕","♔","♗","♘","♖"
            };

            int j = 0;
            int i = 0;

            foreach (Button button in grdPlate.Children.OfType<Button>())
            {
                if (button.Content == "?")
                {
                    button.Content = pieces[0];
                    pieces.RemoveAt(0);


                }
                else
                {
                    button.Content = " ";
                }

            }
        }

        public void SetUpMem()
        {
            int[] pt1 = new int[2] { 0, 0 };
            memPlate[0, 0] = new Tower(pt1, "black");

            int[] pt2 = new int[2] { 0, 7 };
            memPlate[0, 7] = new Tower(pt1, "black");

            int[] pt3 = new int[2] { 7, 0 };
            memPlate[7, 0] = new Tower(pt1, "white");

            int[] pt4 = new int[2] { 7, 7 };
            memPlate[0, 7] = new Tower(pt1, "white");


            int[] ph1 = new int[2] { 0, 1 };
            memPlate[0, 1] = new Horse(ph1, "black");

            int[] ph2 = new int[2] { 0, 6 };
            memPlate[0, 6] = new Horse(ph1, "black");

            int[] ph3 = new int[2] { 7, 1 };
            memPlate[0, 1] = new Horse(ph1, "white");

            int[] ph4 = new int[2] { 7, 6 };
            memPlate[0, 1] = new Horse(ph1, "white");


            int[] pb1 = new int[2] { 0, 2 };
            memPlate[0, 2] = new Bishop(pb1, "black");

            int[] pb2 = new int[2] { 0, 5 };
            memPlate[0, 5] = new Bishop(pb1, "black");

            int[] pb3 = new int[2] { 7, 2 };
            memPlate[7, 2] = new Bishop(pb1, "white");

            int[] pb4 = new int[2] { 7, 5 };
            memPlate[7, 5] = new Bishop(pb1, "white");


            int[] pq1 = new int[2] { 0, 3 };
            memPlate[0, 3] = new Queen(pq1, "black");

            int[] pq2 = new int[2] { 7, 3 };
            memPlate[7, 3] = new Queen(pq1, "white");


            int[] pk1 = new int[2] { 0, 4 };
            memPlate[0, 4] = new King(pk1, "black");

            int[] pk2 = new int[2] { 7, 4 };
            memPlate[7, 4] = new King(pk1, "white");

            int[] pp1 = new int[2] { 1, 0 };
            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pp1[1] = i;
                memPlate[1, i] = new Pawn(pp1, "black");
            }

            int[] pp2 = new int[2] { 6, 0 };
            for (int i = 0; i < memPlate.GetLength(0); i++)
            {
                pp1[1] = i;
                memPlate[6, i] = new Pawn(pp1, "black");    
            }
        }
        public void ShowCases(object sender, RoutedEventArgs e)
        {
            if (click == 0)
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);
                if (cases[nColonne[0], nLigne[0]].Content != " ")
                {
                    click++;
                }
            }
            else
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);
                
                if (nLigne[0] != nLigne[1] || nColonne[0] != nColonne[1])
                {                 
                    cases[nColonne[1], nLigne[1]].Content = cases[nColonne[0], nLigne[0]].Content;
                    cases[nColonne[0], nLigne[0]].Content = " ";

                    memPlate[nColonne[1], nLigne[1]] = memPlate[nColonne[0], nLigne[0]];
                    //memPlate[nColonne[0], nLigne[0]] = ""; 

                    click = 0;
                }                
            }

            /*switch (cases[nLigne, nColonne].Name)
            {
                case "♟":

                    break;

                case "♜":

                    break;

                case "♞":

                    break;

                case "♝":

                    break;

                case "♛":

                    break;

                case "♚":

                    break;

                case "♙":

                    break;

                case "♖":

                    break;

                case "♘":

                    break;

                case "♗":

                    break;

                case "♕":

                    break;

                case "♔":

                    break;
            }*/
        }

        public void SplitName(string nomCase, ref int[] nLigne, ref int[] nColonne, int click)
        {
            string[] nom = nomCase.Split('_');

            int.TryParse(nom[1], out nColonne[click]);

            int.TryParse(nom[2], out nLigne[click]);
            
        }
    }
}
