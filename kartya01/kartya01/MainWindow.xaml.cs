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
using System.Windows.Threading;
using FontAwesome.WPF;

namespace kartya01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FontAwesomeIcon elozoKartya;
        private long score;
        private DispatcherTimer pendulumClock;
        private TimeSpan playTime;
        private Stopwatch stopwatch;
        private List<long> listReactionTimes;
        private Random dobokocka;
        private FontAwesomeIcon[] kartyapakli;

        public MainWindow()
        {
            InitializeComponent();

            pendulumClock = new DispatcherTimer(TimeSpan.FromSeconds(1),
                                                DispatcherPriority.Normal,
                                                clockShock,
                                                Application.Current.Dispatcher);
            pendulumClock.Stop();

            stopwatch = new Stopwatch();

            kartyapakli = new FontAwesomeIcon[6];

            kartyapakli[0] = FontAwesomeIcon.Info;
            kartyapakli[1] = FontAwesomeIcon.Random;
            kartyapakli[2] = FontAwesomeIcon.Rocket;
            kartyapakli[3] = FontAwesomeIcon.Dollar;
            kartyapakli[4] = FontAwesomeIcon.Star;
            kartyapakli[5] = FontAwesomeIcon.Female;

            dobokocka = new Random();

            StartingState();
        }

        // játék mkezdőállapota
        private void StartingState()
        {
            ButtonRestart.Visibility = Visibility.Hidden;
            ButtonStart.Visibility = Visibility.Visible;

            ButtonStart.IsEnabled = true;
            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;
            score = 0;
            ShowScore();
            playTime = TimeSpan.FromSeconds(0);
            ShowPlayTime();
            listReactionTimes = new List<long>();
            ShowReactonTimes(0,0);
            UjKartyaHuzasa(); 
        }

        // játék végállapota
        private void FinalState()
        {
            pendulumClock.Stop();

            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;

            ButtonRestart.Visibility = Visibility.Visible;
            ButtonStart.Visibility = Visibility.Hidden;

        }

        private void clockShock(object sender, EventArgs e)
        {
            playTime += TimeSpan.FromSeconds(1);

            if (playTime > TimeSpan.FromSeconds(10))
            {
                FinalState();
            }
            ShowPlayTime();
        }

        private void ShowPlayTime()
        {
            LabelPlayTime.Content = $"{playTime.Minutes:00}:{playTime.Seconds:00}";
        }

        private void UjKartyaHuzasa()
        {
            var dobas = dobokocka.Next(0, 5);

            elozoKartya = cardRight.Icon;

            // eltüntetni az előző kártyát

            var animOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            cardRight.BeginAnimation(OpacityProperty, animOut);

            cardRight.Icon = kartyapakli[dobas];

            // megjeleníteni az új kártyát

            var animIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            cardRight.BeginAnimation(OpacityProperty, animIn);

            stopwatch.Restart();

        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            StartingState();
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
            pendulumClock.Start();
        }

        private void RosszValasz()
        {
            Debug.WriteLine("Helytelen válasz!");
            cardLeft.Icon = FontAwesomeIcon.Times;
            cardLeft.Foreground = Brushes.Red;
            Scoring(false);
            VisszajelzesEltuntetese();
        }

        private void JoValasz()
        {
            Debug.WriteLine("A válasz helyes.");
            cardLeft.Icon = FontAwesomeIcon.Check;
            cardLeft.Foreground = Brushes.LimeGreen;
            VisszajelzesEltuntetese();
            Scoring(true);
        }

        private void Scoring(bool isGoodAnsver)
        {
            //stopwatch.Stop();

            listReactionTimes.Add(stopwatch.ElapsedMilliseconds);
            ShowReactonTimes(listReactionTimes.Last(), (long)listReactionTimes.Average());

            if (isGoodAnsver)
            {
                Debug.WriteLine($"hozzáadott ponszám: {10000 / listReactionTimes.Last()}");
                score = score + 10000 / listReactionTimes.Last();
            }
            else
            {
                Debug.WriteLine($"levont ponszám: {100 * (listReactionTimes.Last() / 1000)}");
                score = score - 100 * (listReactionTimes.Last() / 1000);
            }

            ShowScore();
        }

        private void ShowReactonTimes(long lastRactionTime, long averageReactionTime)
        {
            LabelReactionTime.Content = $"{lastRactionTime} / {averageReactionTime}";
        }

        private void ShowScore()
        {
            LabelScore.Content = score;
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
            if(ButtonStart.IsEnabled &&
                ButtonStart.IsVisible &&
                e.Key==Key.Up)
            {
                StartGame();
            }

            if (ButtonRestart.IsEnabled &&
                ButtonRestart.IsVisible &&
                e.Key == Key.Down)
            {
                StartingState();
            }

            if (ButtonNo.IsEnabled &&
                e.Key==Key.Right)
            {
                AnsverNo();
            }

            if(ButtonYes.IsEnabled && 
                e.Key==Key.Left)
            {
                AnsverYes();
            }
        }

    }
}
