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

namespace TWO_FACTOR_AUTHENTICATION.Page
{
    /// <summary>
    /// Логика взаимодействия для Avtor.xaml
    /// </summary>
    public partial class Avtor 
    {

        string password = "15lm20nt7";
        string login = "naki951230";
        public Avtor()
        {
            InitializeComponent();
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
