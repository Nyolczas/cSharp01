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
using System.Windows.Media.Animation;
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

            // eltüntetni az előző kártyát

            var animOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            cardRight.BeginAnimation(OpacityProperty, animOut);

            cardRight.Icon = kartyapakli[dobas];

            // megjeleníteni az új kártyát

            var animIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            cardRight.BeginAnimation(OpacityProperty, animIn);

        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            AnsverYes();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            AnsverNo();
        }

        private void AnsverYes()
        {
            Debug.WriteLine("Igen gombot nyomtunk.");

            if (elozoKartya == cardRight.Icon)
            {
                JoValasz();
            }
            else
            {
                RosszValasz();
            }

            UjKartyaHuzasa();
        }
        
        private void AnsverNo()
        {
            Debug.WriteLine("Nem gombot nyomtunk.");

            if (elozoKartya != cardRight.Icon)
            {
                JoValasz();
            }
            else
            {
                RosszValasz();
            }

            UjKartyaHuzasa();
        }


        private void StartGame()
        {
            Debug.WriteLine("Start gombot nyomtunk.");
            UjKartyaHuzasa();
            ButtonYes.IsEnabled = true;
            ButtonNo.IsEnabled = true;
            ButtonStart.IsEnabled = false;
        }

        private void RosszValasz()
        {
            Debug.WriteLine("Helytelen válasz!");
            cardLeft.Icon = FontAwesomeIcon.Times;
            cardLeft.Foreground = Brushes.Red;
            VisszajelzesEltuntetese();
        }

        private void JoValasz()
        {
            Debug.WriteLine("A válasz helyes.");
            cardLeft.Icon = FontAwesomeIcon.Check;
            cardLeft.Foreground = Brushes.LimeGreen;
            VisszajelzesEltuntetese();
        }

        private void VisszajelzesEltuntetese()
        {
            // kártya eltüntetése animációval
            var animationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            cardLeft.BeginAnimation(OpacityProperty, animationOut);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);
            if(e.Key==Key.Up)
            {
                StartGame();
            }

            if(e.Key==Key.Right)
            {
                AnsverNo();
            }

            if(e.Key==Key.Left)
            {
                AnsverYes();
            }
        }
    }
}
