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

namespace Chess.Frames
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Lobby : Page
    {
        public Lobby()
        {
            InitializeComponent();
            skin.Click += new RoutedEventHandler(ChoixSkin);
            play.Click += new RoutedEventHandler(LancerPartie);
            rules.Click += new RoutedEventHandler(MontrerLesRegles);
        }

        public void ChoixSkin(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.Width = 300;
            mw.Height = 300;
            mw.screen.Content = new Skins();
        }

        public void LancerPartie(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.screen.Content = new Game();
            play.IsEnabled = false; //Empêche le joueur de lancer plusieurs parties en même temps
            mw.tour.Visibility = Visibility.Visible;
            mw.afficheTimeBlack.Visibility = Visibility.Visible;
            mw.afficheTimeWhite.Visibility = Visibility.Visible;
        }

        public void MontrerLesRegles(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
