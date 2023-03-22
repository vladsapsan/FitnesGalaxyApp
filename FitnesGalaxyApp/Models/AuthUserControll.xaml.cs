﻿using FitnesGalaxyApp.Pages;
using FitnesGalaxyApp.Windows;
using System;
using System.Collections.Generic;
using System.Data;
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
using FitnesGalaxyApp.DataB.DataSetTableAdapters;

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для AuthUserControll.xaml
    /// </summary>
    public partial class AuthUserControll : UserControl
    {
        DataSet dataSet = new DataSet();
        DataB.DataSet B;
        Table_UsersTableAdapter TUTA = new Table_UsersTableAdapter();


        public AuthUserControll()
        {
            InitializeComponent();
            
           // TUTA.Fill(B.Table_Users);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // for (int i = 0; i < B.Table_Users.Count; i++)
                if (Login.Text == "Admin")
                {
                    if (GetHash(Password.Password) == GetHash("12345678"))
                    {

                        if (App.Current.MainWindow.GetType() == typeof(StartWindow))
                        {
                            (App.Current.MainWindow as StartWindow)._NavigationFrame.Navigate(new MainMenu());
                            MessageBox.Show("Вход в систему произведен успешно!");
                        }
                    }
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
