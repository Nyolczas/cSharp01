﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace kartya01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gombot nyomtunk.");
            UjKartyaHuzasa();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gombot nyomtunk.");
            UjKartyaHuzasa();
        }

        private void UjKartyaHuzasa()
        {
            var kartyapakli = new FontAwesome.WPF.FontAwesomeIcon[6];

            kartyapakli[0] = FontAwesome.WPF.FontAwesomeIcon.Info;
            kartyapakli[1] = FontAwesome.WPF.FontAwesomeIcon.Random;
            kartyapakli[2] = FontAwesome.WPF.FontAwesomeIcon.Rocket;
            kartyapakli[3] = FontAwesome.WPF.FontAwesomeIcon.Ship;
            kartyapakli[4] = FontAwesome.WPF.FontAwesomeIcon.Star;
            kartyapakli[5] = FontAwesome.WPF.FontAwesomeIcon.Tree;

            var dobokocka = new Random();

            var dobas = dobokocka.Next(0, 5);

            cardLeft.Icon = kartyapakli[dobas];
        }
    }
}
