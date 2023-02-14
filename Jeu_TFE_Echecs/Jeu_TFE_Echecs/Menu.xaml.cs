﻿using System;
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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Skins skins = new Skins();
        public Menu()
        {
            InitializeComponent();
            skin.Click += new RoutedEventHandler(ChoixSkin);
        }

        public void ChoixSkin(object sender, RoutedEventArgs e)
        {
            skins.Show();
            this.Hide();
        }
    }
}
