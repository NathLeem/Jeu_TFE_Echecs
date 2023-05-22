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
        string choix;
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
            choix = ((Button)sender).Content.ToString();
        }
    }
}
