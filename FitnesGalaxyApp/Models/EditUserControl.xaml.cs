using FitnesGalaxyApp.DataB.DataSetTableAdapters;
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
using static FitnesGalaxyApp.Models.DataGridTableUserControl;

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для EditUserControl.xaml
    /// </summary>
    public partial class EditUserControl : UserControl
    {
        UsersTableAdapter usersTB = new UsersTableAdapter();
        private int ID;
        public EditUserControl(int IDuser,string login,string password,string name,string surname,DateTime dateb,int genders,int role)
        {
            InitializeComponent();
            ID = IDuser;
            Login.Text = login;
            Password.Password = password;
            Name.Text = name;
            SurName.Text = surname;
            DatePick.SelectedDate= dateb;
            GenderBox.SelectedIndex = genders;
            Role.Text = role.ToString();
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
                                        string PasswordHash = (Password.Password);
                                        usersTB.UpdateQuery(PasswordHash, Login.Text, Name.Text, SurName.Text, DatePick.SelectedDate.ToString(), GenderBox.SelectedIndex.ToString(), Int32.Parse(Role.Text), ID);
                                        MessageBox.Show("Успешное Изменение!");

                                        this.Visibility = Visibility.Collapsed;
                                    }
                                    catch (Exception ex)
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
    }
}
