using FitnesGalaxyApp.DataB.DataSetTableAdapters;
using FitnesGalaxyApp.Pages;
using FitnesGalaxyApp.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для SignUpUserControll.xaml
    /// </summary>
    public partial class SignUpUserControll : UserControl
    {

        DataB.DataSet BASED = new DataB.DataSet();
        UsersTableAdapter usersTB = new UsersTableAdapter();
        string ErrorPassword;
        public SignUpUserControll()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            if(!Login.Text.Equals(null))
            {
                if(!Password.Password.Equals(null) && ValidatePassword(Password.Password,out ErrorPassword))
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
                                    usersTB.Insert(Login.Text, PasswordHash, Name.Text, SurName.Text, (DateTime?)DatePick.SelectedDate, GenderBox.SelectedIndex.ToString(),0);
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
           

            MD5 MD5Hash = MD5.Create(); //создаем объект для работы с MD5
            byte[] inputBytes = Encoding.ASCII.GetBytes(stringhash); //преобразуем строку в массив байтов
            byte[] hash = MD5Hash.ComputeHash(inputBytes); //получаем хэш в виде массива байтов
            

            return Convert.ToBase64String(hash);
        }

        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Поле не должно быть пустым!");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Пароль должен содержать по крайней мере один символ нижнего регистра";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Пароль должен содержать по крайней мере один символ верхнего регистра";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Пароль должен быть не меньше 8 и не больше 15 символов";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Пароль должен содержать по крайней мере одну цифру";
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
