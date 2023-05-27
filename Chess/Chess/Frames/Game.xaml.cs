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


namespace Chess.Frames
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Grid grdPlate = new Grid();          //Plateau visuel du jeu
        SolidColorBrush lastColor;                  //Retiens la couleur de la prmière case cliquée

        int click = 0;              //Permet de faire un mouvement (0 : Aucune case cliquée; 1 : une case a déjà été choisie)
 
        public int[] nLigne = new int[2];       //Numéros de lignes utilisés    
        public int[] nColonne = new int[2];     //Numéros de colonnes utilisés

        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        
        SetUpGame start = new SetUpGame();
        public Game()
        {
            InitializeComponent();
            start.SetUpPlate(ref grdPlate, ref mainWindow.cases, ref this.gameScreen);
            start.PrepareGame(ref grdPlate);

            mainWindow.infRow.Height = new GridLength(800/9);

            for (int i = 0; i < mainWindow.cases.GetLength(0); i++)
            {
                for (int j = 0; j < mainWindow.cases.GetLength(1); j++)
                {
                    mainWindow.cases[i, j].Click += new RoutedEventHandler(Play);  //Tous les boutons peuvent être utilisés pour interagir
                }
            }
        }

        public void Play(object sender, RoutedEventArgs e)  //Jouer
        {

            if (click == 0) //Aucune case encore choisie    
            {
                SplitName(((Button)sender).Name, ref nLigne, ref nColonne, click);  //Extraction des coordonnées de la case cliquée
                if (mainWindow.cases[nColonne[0], nLigne[0]].Content != " ")   //La case choisie doit contenir une pièce
                {
                    if (mainWindow.memPlate[nColonne[0], nLigne[0]].Color == mainWindow.turn) //Le joueur a cliqué sur une de ses pièces
                    {
                    for (int i = 0; i < mainWindow.cases.GetLength(0); i++)
                        lastColor = (SolidColorBrush)mainWindow.cases[nColonne[0], nLigne[0]].Background;  //Sauvegarde la couleur initiale de la case choisie
                        mainWindow.cases[nColonne[0], nLigne[0]].Background = Brushes.Yellow;  //Affichage de la case qu'il a choisie (aide mémorielle)

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
                            mainWindow.cases[nColonne[1], nLigne[1]].Content = mainWindow.cases[nColonne[0], nLigne[0]].Content;  //Déplacement du pion
                            mainWindow.cases[nColonne[0], nLigne[0]].Content = " ";    //Suppression de son ancienne positoion

                            if (!VerifPromote())
                            {                              
                                mainWindow.PostCheck();
                            }
                            else
                            {

                            }                
                        }
                    }
                }
                click = 0;  //Fin du tour   

                mainWindow.cases[nColonne[0], nLigne[0]].Background = lastColor;   //Réatribution de la couleur initiale à la première case cliquée

                RefreshInfos(); //Actualisation des informations
            }
        }
        public bool AcceptMove(int[] nColonne, int[] nLigne)    //Fonction qui va vérifier la validité du mouvement
        {
            bool moveAccept = mainWindow.memPlate[nColonne[0], nLigne[0]].Moving(nColonne, nLigne, mainWindow.memPlate);  //Vérifie selon la pièce la validité du mouvement

            return moveAccept;  //Envoie du résultat
        }

        public void SplitName(string nomCase, ref int[] nLigne, ref int[] nColonne, int click)  //Fonction qui va permettre d'extraire en nombres entier les coordonnées x et y de la case qui a été cliquée
        {
            string[] nom = nomCase.Split('_');  //Sépare les coordonnées

            int.TryParse(nom[1], out nColonne[click]);  //Sortie de la coordonnée x 

            int.TryParse(nom[2], out nLigne[click]);    //Sortie de la coordonnée y      
        }

        

        public bool AnteCheck(Piece[,] tempMemPlate)
        {
            if (mainWindow.turn == "white")    //Si c'était le tour des blancs
            {
                if (mainWindow.pieces[15].IsChecked(tempMemPlate)) //On vérifie si il a mis en échec le roi adversaire
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
                if (mainWindow.pieces[14].IsChecked(tempMemPlate)) //On vérifie si il a mis en échec le roi adversaire
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

            for (int i = 0; i < mainWindow.memPlate.GetLength(0); i++)
            {
                for (int j = 0; j < mainWindow.memPlate.GetLength(1); j++)
                {
                    tempMemPlate[i, j] = mainWindow.memPlate[i, j];
                }
            }

            tempMemPlate[nColonne[1], nLigne[1]] = tempMemPlate[nColonne[0], nLigne[0]];    //Déplacement du pion
            tempMemPlate[nColonne[0], nLigne[0]] = null;    //Suppression de son ancienne position

            if (!AnteCheck(tempMemPlate))
            {
                mainWindow.memPlate[nColonne[1], nLigne[1]] = mainWindow.memPlate[nColonne[0], nLigne[0]];    //Déplacement du pion
                mainWindow.memPlate[nColonne[0], nLigne[0]] = null;    //Suppression de son ancienne position
                return true;
            }

            return false;
        }

        public void RefreshInfos()  //Actualise les informations de la partie
        {
            if (mainWindow.turn == "white") //Informe le joueur à qui est-ce de joueur
            {
                mainWindow.tour.Background = Brushes.White;
                mainWindow.tour.Text = "White turn";
                mainWindow.tour.Foreground = Brushes.Black;
            }
            else    //Trait aux noirs
            {
                mainWindow.tour.Background = Brushes.Black;
                mainWindow.tour.Text = "Black turn";
                mainWindow.tour.Foreground = Brushes.White;
            }
        }

        public void TypeOfMove()
        {
            
        }

        public bool VerifPromote()
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;

            bool promotable = false;

            for (int i = 0; i < mainWindow.memPlate.GetLength(0); i++)
            {
                if(mainWindow.memPlate[0,i] is Pawn)
                {
                    promotable = true;

                    mw.pawnPosition[0] = 0;
                    mw.pawnPosition[1] = i;
                }

                if (mainWindow.memPlate[7, i] is Pawn)
                {
                    promotable = true;

                    mw.pawnPosition[0] = 7;
                    mw.pawnPosition[1] = i;
                }
            }

            if (promotable)
            {
                for (int i = 0; i < mainWindow.cases.GetLength(0); i++)
                {
                    for (int j = 0; j < mainWindow.cases.GetLength(0); j++)
                    {
                        mainWindow.cases[i, j].IsEnabled = false;
                    }
                }

                mainWindow.promoteChoose.Content = new Promote();

                return true;
            }
            return false;
        }

        public bool Checkmate()
        {
            return false;
        }
    }
}
