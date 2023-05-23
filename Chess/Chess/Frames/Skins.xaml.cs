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
    /// Logique d'interaction pour Skins.xaml
    /// </summary>
    public partial class Skins : Page
    {
        public Skins()
        {
            InitializeComponent();
            exit.Click += new RoutedEventHandler(AnnulerChoix);

            classic.Click += new RoutedEventHandler(SelectSkin);
            egypt.Click += new RoutedEventHandler(SelectSkin);
            tele.Click += new RoutedEventHandler(SelectSkin);
            vehicles.Click += new RoutedEventHandler(SelectSkin);
        }

        public void AnnulerChoix(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.Width = 800;
            mw.Height = 450;
            mw.screen.Content = new Lobby();
        }

        public void SelectSkin(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.skin = ((Button)sender).Content.ToString();
            mw.Width = 800;
            mw.Height = 450;
            mw.screen.Content = new Lobby();
        }
    }
}
