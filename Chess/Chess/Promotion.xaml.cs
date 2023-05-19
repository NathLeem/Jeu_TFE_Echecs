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

namespace Chess
{
    /// <summary>
    /// Interaction logic for Promotion.xaml
    /// </summary>
    public partial class Promotion : Window
    {
        public string chose = "";
        public Promotion()
        {
            InitializeComponent();
            queen.Click += new RoutedEventHandler(ChosePromote);
            bishop.Click += new RoutedEventHandler(ChosePromote);
            horse.Click += new RoutedEventHandler(ChosePromote);
            tower.Click += new RoutedEventHandler(ChosePromote);
        }

        public void ChosePromote(object sender, RoutedEventArgs e)
        {
            chose = ((Button)sender).Content.ToString();
            this.Close();
        }
    }
}
