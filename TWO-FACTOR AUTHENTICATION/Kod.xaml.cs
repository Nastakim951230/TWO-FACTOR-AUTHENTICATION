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
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TWO_FACTOR_AUTHENTICATION
{
    /// <summary>
    /// Логика взаимодействия для Kod.xaml
    /// </summary>
    public partial class Kod : Window
    {
        DispatcherTimer disTimer= new DispatcherTimer();
      public static int count = 0;
        public static string log;
        public static string pas;

        public int value;
        public Kod()
        {
            InitializeComponent();
          
            disTimer.Interval = new TimeSpan(0,0,10);
            Random rnd = new Random();
             value = rnd.Next(10000,99999);
           kod.Text = value.ToString();
            disTimer.Tick += Dis_Timer;
            disTimer.Start();
        }

     
        private void Dis_Timer(object sender, EventArgs e)
        {
            
            count++;
            Page.Avtor.pas = pas;
            Page.Avtor.log = log;
            Page.Avtor.coint = count;
            disTimer.Stop();
            ClassPage.perehod.Navigate(new Page.Avtor());
            this.Close();

        }
        private void Rez_Click(object sender, RoutedEventArgs e)
        {
            
            if(kodrez.Text == value.ToString())
            {
                disTimer.Stop();
                ClassPage.perehod.Navigate(new Page.str());
               
                this.Close();
            }
            else
            {
               
                count++;
                Page.Avtor.pas = pas;
                Page.Avtor.log = log;
                Page.Avtor.coint = count;
                disTimer.Stop();
                ClassPage.perehod.Navigate(new Page.Avtor());
                this.Close();

            }
        }
    }
}
