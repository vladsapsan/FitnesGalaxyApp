using FitnesGalaxyApp.Pages;
using FitnesGalaxyApp.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для SignUpUserControll.xaml
    /// </summary>
    public partial class SignUpUserControll : UserControl
    {
        public SignUpUserControll()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            if(!Login.Text.Equals(null))
            {
                if(!Password.Password.Equals(null))
                {
                    if(!Name.Text.Equals(null))
                    {
                        if(!SurName.Text.Equals(null))
                        {
                            if(!DatePick.Equals(null))
                            {
                                if(GenderBox.SelectedItem != null)
                                {
                                    string PasswordHash = GetHash(Password.Password);

                                    MessageBox.Show("Успешная регистрация!");
                                    
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Логин не введен!");
            }

        }
        private string GetHash(string stringhash)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(stringhash));

            return Convert.ToBase64String(hash);
        }
    }
}
