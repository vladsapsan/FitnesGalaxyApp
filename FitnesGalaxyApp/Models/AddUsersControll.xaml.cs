using FitnesGalaxyApp.DataB.DataSetTableAdapters;
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
    /// Логика взаимодействия для AddUsersControll.xaml
    /// </summary>
    public partial class AddUsersControll : UserControl
    {

        UsersTableAdapter usersTB = new UsersTableAdapter();
        public AddUsersControll()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Login.Text.Equals(null))
            {
                if (!Password.Password.Equals(null))
                {
                    if (!Name.Text.Equals(null))
                    {
                        if (!SurName.Text.Equals(null))
                        {
                            if (!DatePick.Equals(null))
                            {
                                if (GenderBox.SelectedItem != null)
                                {
                                    try
                                    {
                                        string PasswordHash = GetHash(Password.Password);
                                        usersTB.Insert(Login.Text, PasswordHash, Name.Text, SurName.Text, (DateTime?)DatePick.SelectedDate, GenderBox.SelectedIndex.ToString(), Int32.Parse(Role.Text));
                                        MessageBox.Show("Успешное добавление!");
                                        
                                        this.Visibility = Visibility.Collapsed;
                                    }
                                    catch(Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }


                                }
                            }
                        }
                    }
                }
            }
        }
        private string GetHash(string stringhash)
        {


            MD5 MD5Hash = MD5.Create(); //создаем объект для работы с MD5
            byte[] inputBytes = Encoding.ASCII.GetBytes(stringhash); //преобразуем строку в массив байтов
            byte[] hash = MD5Hash.ComputeHash(inputBytes); //получаем хэш в виде массива байтов


            return Convert.ToBase64String(hash);
        }
    }
}
