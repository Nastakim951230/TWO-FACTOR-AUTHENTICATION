using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace TWO_FACTOR_AUTHENTICATION.Page
{
    /// <summary>
    /// Логика взаимодействия для Avtor.xaml
    /// </summary>
    public partial class Avtor 
    {
        public static int coint;
        string password = "1111";
        string login = "login";
        string text = String.Empty;
        public static string log;
        public static string pas;

        DispatcherTimer disTimer = new DispatcherTimer();
        int sec = 0;

        public Avtor()
        {
            InitializeComponent();
            if(coint==1)
            {
                CaptchaSP.Visibility = Visibility.Collapsed;
                Login.Text = log;
                Passsword.Text = pas;
                avtorizat.Visibility = Visibility.Collapsed;
                time.Visibility= Visibility.Visible;
                disTimer.Interval = TimeSpan.FromSeconds(1);
                disTimer.Tick += dtTicker;
                disTimer.Start();
            }
            else if(coint==2)
            {
                avtorizat.IsEnabled = false;
                Kod.count = 0;
                Login.Text = log;
                Passsword.Text = pas;
                CaptchaSP.Visibility = Visibility.Visible;
                Random random = new Random();
                int kolvoPolyline=random.Next(7,20);

                for (int i = 0; i < kolvoPolyline; i++)
                {
                    SolidColorBrush brush=new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                    Line line = new Line()
                    {
                        X1 = random.Next((int)Captcha.Width),
                        Y1 = random.Next((int)Captcha.Height),
                        X2 = random.Next((int)Captcha.Width),
                        Y2 = random.Next((int)Captcha.Height),
                        Stroke = brush,
                    };
                    Captcha.Children.Add(line);
                }
                int kolvoText = random.Next(7, 10);
                text = String.Empty;
                string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                for (int i = 0; i < kolvoText; ++i)
                    text += ALF[random.Next(ALF.Length)];

                int vubor = random.Next(0, 3);
               
                    int fontSize = random.Next(16, 33);
                    int height = random.Next((int)Captcha.Height - 20);
                    int width = random.Next((int)Captcha.Width - 20);
                if(vubor == 0)
                {
                    TextBlock textBlock = new TextBlock()
                    {

                        Text = text,
                        FontSize = fontSize,
                        Padding = new Thickness(width, height, 0, 0),

                    };
                    Captcha.Children.Add(textBlock);
                }
                else if(vubor == 1)
                {
                    TextBlock textBlock = new TextBlock()
                    {

                        Text = text,
                        FontSize = fontSize,
                        Padding = new Thickness(width, height, 0, 0),
                        FontWeight = FontWeights.Bold,

                    };
                    Captcha.Children.Add(textBlock);
                }
                else if (vubor == 2)
                {
                    TextBlock textBlock = new TextBlock()
                    {

                        Text = text,
                        FontSize = fontSize,
                        Padding = new Thickness(width, height, 0, 0),
                        FontWeight = FontWeights.Bold,
                        FontStyle = FontStyles.Italic,

                    };
                    Captcha.Children.Add(textBlock);
                }
                else if(vubor==3)
                {
                    TextBlock textBlock = new TextBlock()
                    {

                        Text = text,
                        FontSize = fontSize,
                        Padding = new Thickness(width, height, 0, 0),
                      
                        FontStyle = FontStyles.Italic,

                    };
                    Captcha.Children.Add(textBlock);
                }


            }
        }
        

        private void dtTicker(object sender, EventArgs e)
        {
           if(sec!=60)
            {
                sec++;
                time.Text=sec.ToString();

            }
            else
            {
                avtorizat.Visibility = Visibility.Visible;
                time.Visibility = Visibility.Collapsed;
                disTimer.Stop();
                sec = 0;
            }
        }
        private void avtorizat_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Passsword.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK);
            }
            else
            {
                if (Passsword.Text == password || Login.Text == login)
                {
                    Kod.pas = Passsword.Text;
                    Kod.log = Login.Text;
                    Kod Rezul = new Kod();  // создание объекта окна
                    Rezul.ShowDialog();
                   

                }
                else
                {
                    MessageBox.Show("Данного пароля или логина не существует");
                }
            }
        }

        private void vvod_Click(object sender, RoutedEventArgs e)
        {
            if(CaptchaTB.Text=="")
            {
                Page.Avtor.coint = 2;
                ClassPage.perehod.Navigate(new Page.Avtor());
            }
            else
            {
                if(CaptchaTB.Text==text)
                {
                    ClassPage.perehod.Navigate(new Page.str());
                }
                else
                {
                    Page.Avtor.coint = 2;
                    ClassPage.perehod.Navigate(new Page.Avtor());
                }
            }
        }
    }
}
