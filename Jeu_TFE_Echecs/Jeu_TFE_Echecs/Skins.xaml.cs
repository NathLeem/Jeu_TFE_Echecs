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
using System.Windows.Shapes;

namespace Jeu_TFE_Echecs
{
    /// <summary>
    /// Logique d'interaction pour Skins.xaml
    /// </summary>
    public partial class Skins : Window
    {
        public string choix;
        public Skins()
        {
            InitializeComponent();
            exit.Click += new RoutedEventHandler(AnnulerChoix);

            classic.Click += new RoutedEventHandler(SelectSkin);
            egypt.Click += new RoutedEventHandler(SelectSkin);
            tele.Click += new RoutedEventHandler(SelectSkin);
            vehicles.Click += new RoutedEventHandler(SelectSkin);
            //teachers.Click += new RoutedEventHandler(SelectSkin);
        }

        public void AnnulerChoix(object sender, RoutedEventArgs e)
        {
            this.Close();       
        }

        public void SelectSkin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
