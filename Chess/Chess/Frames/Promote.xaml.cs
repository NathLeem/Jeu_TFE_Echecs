using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.Frames
{
    /// <summary>
    /// Interaction logic for Promote.xaml
    /// </summary>
    public partial class Promote : Page
    {
        string choose;

        MainWindow mw = (MainWindow)App.Current.MainWindow;
        public Promote()
        {
            InitializeComponent();
            queen.Click += new RoutedEventHandler(PieceChosen);
            bishop.Click += new RoutedEventHandler(PieceChosen);
            horse.Click += new RoutedEventHandler(PieceChosen);
            tower.Click += new RoutedEventHandler(PieceChosen);
        }

        public void PieceChosen(object sender, RoutedEventArgs e)
        {          
            choose = ((Button)sender).Content.ToString();
            
            mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Promotion(choose, ref mw.memPlate);

            switch (choose)
            {
                case "Queen":
                    ChangeToQueen();
                    break;

                case "Bishop":
                    ChangeToBishop();
                    break;

                case "Horse":
                    ChangeToHorse();
                    break;

                case "Tower":
                    ChangeToTower();
                    break;
            }

            for (int i = 0; i < mw.cases.GetLength(0); i++)
            {
                for (int j = 0; j < mw.cases.GetLength(1); j++)
                {
                    mw.cases[i, j].IsEnabled = true;
                }
            }
        }

        private void ChangeToQueen()
        {        
            switch (mw.skin)
            {
                case "Default":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultQueenBlack = new BitmapImage();
                        defaultQueenBlack.BeginInit();
                        defaultQueenBlack.UriSource = new Uri("/SkinPieces/Default/QueenBlack.png", UriKind.Relative);
                        defaultQueenBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultQueenBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultQueenWhite = new BitmapImage();
                        defaultQueenWhite.BeginInit();
                        defaultQueenWhite.UriSource = new Uri("/SkinPieces/Default/QueenWhite.png", UriKind.Relative);
                        defaultQueenWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultQueenWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Car":
                    if(mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage carQueenBlack = new BitmapImage();
                        carQueenBlack.BeginInit();
                        carQueenBlack.UriSource = new Uri("/SkinPieces/Cars/QueenBlack.png", UriKind.Relative);
                        carQueenBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carQueenBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage carQueenWhite = new BitmapImage();
                        carQueenWhite.BeginInit();
                        carQueenWhite.UriSource = new Uri("/SkinPieces/Cars/QueenWhite.png", UriKind.Relative);
                        carQueenWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carQueenWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Egypt":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage egypteQueenBlack = new BitmapImage();
                        egypteQueenBlack.BeginInit();
                        egypteQueenBlack.UriSource = new Uri("/SkinPieces/Egypt/QueenBlack.png", UriKind.Relative);
                        egypteQueenBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteQueenBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage egypteQueenWhite = new BitmapImage();
                        egypteQueenWhite.BeginInit();
                        egypteQueenWhite.UriSource = new Uri("/SkinPieces/Egypt/QueenWhite.png", UriKind.Relative);
                        egypteQueenWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteQueenWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Teletubbies":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage teleQueenBlack = new BitmapImage();
                        teleQueenBlack.BeginInit();
                        teleQueenBlack.UriSource = new Uri("/SkinPieces/Teletubbies/QueenBlack.png", UriKind.Relative);
                        teleQueenBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleQueenBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage teleQueenWhite = new BitmapImage();
                        teleQueenWhite.BeginInit();
                        teleQueenWhite.UriSource = new Uri("/SkinPieces/Teletubbies/QueenWhite.png", UriKind.Relative);
                        teleQueenWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleQueenWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                default:
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultQueenBlack = new BitmapImage();
                        defaultQueenBlack.BeginInit();
                        defaultQueenBlack.UriSource = new Uri("/SkinPieces/Default/QueenBlack.png", UriKind.Relative);
                        defaultQueenBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultQueenBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultQueenWhite = new BitmapImage();
                        defaultQueenWhite.BeginInit();
                        defaultQueenWhite.UriSource = new Uri("/SkinPieces/Default/QueenWhite.png", UriKind.Relative);
                        defaultQueenWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultQueenWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;
            }
        }

        private void ChangeToBishop()
        {
            switch (mw.skin)
            {
                case "Default":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultBishopBlack = new BitmapImage();
                        defaultBishopBlack.BeginInit();
                        defaultBishopBlack.UriSource = new Uri("/SkinPieces/Default/BishopBlack.png", UriKind.Relative);
                        defaultBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultBishopWhite = new BitmapImage();
                        defaultBishopWhite.BeginInit();
                        defaultBishopWhite.UriSource = new Uri("/SkinPieces/Default/BishopWhite.png", UriKind.Relative);
                        defaultBishopWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultBishopWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                break;

                case "Car":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage carBishopBlack = new BitmapImage();
                        carBishopBlack.BeginInit();
                        carBishopBlack.UriSource = new Uri("/SkinPieces/Cars/BishopBlack.png", UriKind.Relative);
                        carBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage carBishopWhite = new BitmapImage();
                        carBishopWhite.BeginInit();
                        carBishopWhite.UriSource = new Uri("/SkinPieces/Cars/BishopWhite.png", UriKind.Relative);
                        carBishopWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carBishopWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Egypt":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage egypteBishopBlack = new BitmapImage();
                        egypteBishopBlack.BeginInit();
                        egypteBishopBlack.UriSource = new Uri("/SkinPieces/Egypt/BishopBlack.png", UriKind.Relative);
                        egypteBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage egypteBishopWhite = new BitmapImage();
                        egypteBishopWhite.BeginInit();
                        egypteBishopWhite.UriSource = new Uri("/SkinPieces/Egypt/BishopWhite.png", UriKind.Relative);
                        egypteBishopWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteBishopWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;
                        
                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Teletubbies":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage teleBishopBlack = new BitmapImage();
                        teleBishopBlack.BeginInit();
                        teleBishopBlack.UriSource = new Uri("/SkinPieces/Teletubbies/BishopBlack.png", UriKind.Relative);
                        teleBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage teleBishopWhite = new BitmapImage();
                        teleBishopWhite.BeginInit();
                        teleBishopWhite.UriSource = new Uri("/SkinPieces/Teletubbies/BishopWhite.png", UriKind.Relative);
                        teleBishopWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleBishopWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                default:
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultBishopBlack = new BitmapImage();
                        defaultBishopBlack.BeginInit();
                        defaultBishopBlack.UriSource = new Uri("/SkinPieces/Default/BishopBlack.png", UriKind.Relative);
                        defaultBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultBishopWhite = new BitmapImage();
                        defaultBishopWhite.BeginInit();
                        defaultBishopWhite.UriSource = new Uri("/SkinPieces/Default/BishopWhite.png", UriKind.Relative);
                        defaultBishopWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultBishopWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;
            }
        }

        private void ChangeToHorse()
        {
            switch (mw.skin)
            {
                case "Default":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultHorseBlack = new BitmapImage();
                        defaultHorseBlack.BeginInit();
                        defaultHorseBlack.UriSource = new Uri("/SkinPieces/Default/HorseBlack.png", UriKind.Relative);
                        defaultHorseBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultHorseBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultHorseWhite = new BitmapImage();
                        defaultHorseWhite.BeginInit();
                        defaultHorseWhite.UriSource = new Uri("/SkinPieces/Default/HorseWhite.png", UriKind.Relative);
                        defaultHorseWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultHorseWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Car":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage carBishopBlack = new BitmapImage();
                        carBishopBlack.BeginInit();
                        carBishopBlack.UriSource = new Uri("/SkinPieces/Cars/BishopBlack.png", UriKind.Relative);
                        carBishopBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carBishopBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage carHorseWhite = new BitmapImage();
                        carHorseWhite.BeginInit();
                        carHorseWhite.UriSource = new Uri("/SkinPieces/Cars/HorseWhite.png", UriKind.Relative);
                        carHorseWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carHorseWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Egypt":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage egypteHorseBlack = new BitmapImage();
                        egypteHorseBlack.BeginInit();
                        egypteHorseBlack.UriSource = new Uri("/SkinPieces/Egypt/HorseBlack.png", UriKind.Relative);
                        egypteHorseBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteHorseBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage egypteHorseWhite = new BitmapImage();
                        egypteHorseWhite.BeginInit();
                        egypteHorseWhite.UriSource = new Uri("/SkinPieces/Egypt/HorseWhite.png", UriKind.Relative);
                        egypteHorseWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteHorseWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Teletubbies":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage teleHorseBlack = new BitmapImage();
                        teleHorseBlack.BeginInit();
                        teleHorseBlack.UriSource = new Uri("/SkinPieces/Teletubbies/HorseBlack.png", UriKind.Relative);
                        teleHorseBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleHorseBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage teleHorseWhite = new BitmapImage();
                        teleHorseWhite.BeginInit();
                        teleHorseWhite.UriSource = new Uri("/SkinPieces/Teletubbies/HorseWhite.png", UriKind.Relative);
                        teleHorseWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleHorseWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                default:
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultHorseBlack = new BitmapImage();
                        defaultHorseBlack.BeginInit();
                        defaultHorseBlack.UriSource = new Uri("/SkinPieces/Default/HorseBlack.png", UriKind.Relative);
                        defaultHorseBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultHorseBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultHorseWhite = new BitmapImage();
                        defaultHorseWhite.BeginInit();
                        defaultHorseWhite.UriSource = new Uri("/SkinPieces/Default/HorseWhite.png", UriKind.Relative);
                        defaultHorseWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultHorseWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;
            }
        }
        private void ChangeToTower()
        {
            switch (mw.skin)
            {
                case "Default":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultTowerBlack = new BitmapImage();
                        defaultTowerBlack.BeginInit();
                        defaultTowerBlack.UriSource = new Uri("/SkinPieces/Default/TowerBlack.png", UriKind.Relative);
                        defaultTowerBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultTowerBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultTowerWhite = new BitmapImage();
                        defaultTowerWhite.BeginInit();
                        defaultTowerWhite.UriSource = new Uri("/SkinPieces/Default/TowerWhite.png", UriKind.Relative);
                        defaultTowerWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultTowerWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Car":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage carTowerBlack = new BitmapImage();
                        carTowerBlack.BeginInit();
                        carTowerBlack.UriSource = new Uri("/SkinPieces/Cars/TowerBlack.png", UriKind.Relative);
                        carTowerBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carTowerBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage carTowerWhite = new BitmapImage();
                        carTowerWhite.BeginInit();
                        carTowerWhite.UriSource = new Uri("/SkinPieces/Cars/TowerWhite.png", UriKind.Relative);
                        carTowerWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = carTowerWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Egypt":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage egypteTowerBlack = new BitmapImage();
                        egypteTowerBlack.BeginInit();
                        egypteTowerBlack.UriSource = new Uri("/SkinPieces/Egypt/TowerBlack.png", UriKind.Relative);
                        egypteTowerBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteTowerBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage egypteTowerWhite = new BitmapImage();
                        egypteTowerWhite.BeginInit();
                        egypteTowerWhite.UriSource = new Uri("/SkinPieces/Egypt/TowerWhite.png", UriKind.Relative);
                        egypteTowerWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = egypteTowerWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                case "Teletubbies":
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage teleTowerBlack = new BitmapImage();
                        teleTowerBlack.BeginInit();
                        teleTowerBlack.UriSource = new Uri("/SkinPieces/Teletubbies/TowerBlack.png", UriKind.Relative);
                        teleTowerBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleTowerBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage teleTowerWhite = new BitmapImage();
                        teleTowerWhite.BeginInit();
                        teleTowerWhite.UriSource = new Uri("/SkinPieces/Teletubbies/TowerWhite.png", UriKind.Relative);
                        teleTowerWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = teleTowerWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;

                default:
                    if (mw.memPlate[mw.pawnPosition[0], mw.pawnPosition[1]].Color == "black")
                    {
                        BitmapImage defaultTowerBlack = new BitmapImage();
                        defaultTowerBlack.BeginInit();
                        defaultTowerBlack.UriSource = new Uri("/SkinPieces/Default/TowerBlack.png", UriKind.Relative);
                        defaultTowerBlack.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultTowerBlack;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    else
                    {
                        BitmapImage defaultTowerWhite = new BitmapImage();
                        defaultTowerWhite.BeginInit();
                        defaultTowerWhite.UriSource = new Uri("/SkinPieces/Default/TowerWhite.png", UriKind.Relative);
                        defaultTowerWhite.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = defaultTowerWhite;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        imBouton.Stretch = Stretch.Uniform;

                        mw.cases[mw.pawnPosition[0], mw.pawnPosition[1]].Content = imBouton;
                    }
                    break;
            }
        }
    }
}
