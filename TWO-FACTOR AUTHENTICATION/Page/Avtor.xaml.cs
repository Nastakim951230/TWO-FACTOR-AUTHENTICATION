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
        string login = "naki951230";
        private string text = String.Empty;
        public static string log;
        public static string pas;

        DispatcherTimer disTimer = new DispatcherTimer();
        int sec = 0;
        public Avtor()
        {
            InitializeComponent();
            if(coint==1)
            {
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
      
    }
}
