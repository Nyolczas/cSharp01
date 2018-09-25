using System;
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
using FontAwesome.WPF;

namespace kartya01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FontAwesomeIcon elozoKartya;

        public MainWindow()
        {
            InitializeComponent();
            UjKartyaHuzasa();
            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;
        }



        private void UjKartyaHuzasa()
        {
            var kartyapakli = new FontAwesome.WPF.FontAwesomeIcon[6];

            kartyapakli[0] = FontAwesome.WPF.FontAwesomeIcon.Info;
            kartyapakli[1] = FontAwesome.WPF.FontAwesomeIcon.Random;
            kartyapakli[2] = FontAwesome.WPF.FontAwesomeIcon.Rocket;
            kartyapakli[3] = FontAwesome.WPF.FontAwesomeIcon.Dollar;
            kartyapakli[4] = FontAwesome.WPF.FontAwesomeIcon.Star;
            kartyapakli[5] = FontAwesome.WPF.FontAwesomeIcon.Female;

            var dobokocka = new Random();

            var dobas = dobokocka.Next(0, 5);

            elozoKartya = cardRight.Icon;

            cardRight.Icon = kartyapakli[dobas];
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gombot nyomtunk.");
            UjKartyaHuzasa();
            if (elozoKartya==cardRight.Icon)
            {
                Debug.WriteLine("A válasz helyes.");
            }
            else
            {
                Debug.WriteLine("Helytelen válasz!");
            }
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gombot nyomtunk.");
            UjKartyaHuzasa();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start gombot nyomtunk.");
            UjKartyaHuzasa();
            ButtonYes.IsEnabled = true;
            ButtonNo.IsEnabled = true ; 
            ButtonStart.IsEnabled = false; 
        }
    }
}
