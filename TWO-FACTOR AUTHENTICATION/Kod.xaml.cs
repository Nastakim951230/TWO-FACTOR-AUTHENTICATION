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

namespace TWO_FACTOR_AUTHENTICATION
{
    /// <summary>
    /// Логика взаимодействия для Kod.xaml
    /// </summary>
    public partial class Kod : Window
    {

        public Kod()
        {
            InitializeComponent();
            Random rnd = new Random();
            int value = rnd.Next(10000,99999);
           kod.Text = value.ToString();
        }

        private void Rez_Click(object sender, RoutedEventArgs e)
        {
            if(kodrez.Text != kod.Text)
            {

            }
            else
            {

            }
        }
    }
}
