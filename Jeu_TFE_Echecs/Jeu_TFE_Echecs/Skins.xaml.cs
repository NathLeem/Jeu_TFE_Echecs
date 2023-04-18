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
        public bool choisi;
        public string ancienChoix;
        public Skins()
        {
            InitializeComponent();
            exit.Click += new RoutedEventHandler(AnnulerChoix);

            /*skin1.Click += new RoutedEventHandler(SelectSkin);
            skin2.Click += new RoutedEventHandler(SelectSkin);
            skin3.Click += new RoutedEventHandler(SelectSkin);
            skin4.Click += new RoutedEventHandler(SelectSkin);
            skin5.Click += new RoutedEventHandler(SelectSkin);
            skin6.Click += new RoutedEventHandler(SelectSkin);*/
        }

        public void AnnulerChoix(object sender, RoutedEventArgs e)
        {
            
            this.Close();          
        }

        public void SelectSkin(object sender, RoutedEventArgs e)
        {
            if (choisi)
            {
                ((Button)sender).BorderBrush = Brushes.Yellow;
            }
            else
            {
                
            }
        }
    }
}
