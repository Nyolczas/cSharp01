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
            var kartyapakli = new FontAwesomeIcon[6];

            kartyapakli[0] = FontAwesomeIcon.Info;
            kartyapakli[1] = FontAwesomeIcon.Random;
            kartyapakli[2] = FontAwesomeIcon.Rocket;
            kartyapakli[3] = FontAwesomeIcon.Dollar;
            kartyapakli[4] = FontAwesomeIcon.Star;
            kartyapakli[5] = FontAwesomeIcon.Female;

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
                JoValasz();
            }
            else
            {
                RosszValasz();
            }
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gombot nyomtunk.");
            UjKartyaHuzasa();
            if (elozoKartya != cardRight.Icon)
            {
                JoValasz();
            }
            else
            {
                RosszValasz();
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start gombot nyomtunk.");
            UjKartyaHuzasa();
            ButtonYes.IsEnabled = true;
            ButtonNo.IsEnabled = true ; 
            ButtonStart.IsEnabled = false; 
        }

        private void RosszValasz()
        {
            Debug.WriteLine("Helytelen válasz!");
            cardLeft.Icon = FontAwesomeIcon.Times;
            cardLeft.Foreground = Brushes.Red;
        }

        private void JoValasz()
        {
            Debug.WriteLine("A válasz helyes.");
            cardLeft.Icon = FontAwesomeIcon.Check;
            cardLeft.Foreground = Brushes.LimeGreen;
        }
    }
}
