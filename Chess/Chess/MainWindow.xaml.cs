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
using Chess.Frames;
using Chess.Pieces;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string turn = "white";      //Tour par tour (Les blancs commencent)
        public string skin;                 //Permet au joueur de choisir l'apparence de son pion
        public int[] pawnPosition = new int[2];     //Variable qui sert à conserver la position d'un pion qui est en stade de promotion pour pouvoir le faire passer de fichier en fichier
        public Piece[,] memPlate = new Piece[8, 8]; //Plateau "logique" du jeu, toutes les opérations se feront ici
        public Piece[] pieces = new Piece[32];      //Liste des pièces du jeu
        public Button[,] cases = new Button[8, 8];  //Cases du plateau (en 8x8) tous intéragissables   
        SetUpGame start = new SetUpGame();      //Structure qui lance le jeu
        public MainWindow()
        {
            InitializeComponent();
            start.SetUpMem(ref pieces, ref memPlate);
            screen.Content = new Lobby();
        }
        public string PostCheck() //Fonction qui regarde si une fois le tour joué les rois sont en échecs
        {
            if (turn == "white")    //Si c'était le tour des blancs
            {
                turn = "black"; //Trait aux noirs désormais
                if (pieces[14].IsChecked(memPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    return "CHECK TO BLACK";    //Envoie de l'information
                }
                else
                {
                    return "";    //Retrait de l'information
                }
            }
            else
            {
                turn = "white"; //Trait aux blancs
                if (pieces[15].IsChecked(memPlate)) //On vérifie si il a mis en échec le roi adversaire
                {
                    return "CHECK TO WHITE";   //Envoie de l'information
                }
                else
                {
                    return "";    //Retrait de l'information
                }
            }
        }
    }
}
