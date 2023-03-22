﻿using FitnesGalaxyApp.Windows;
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

namespace FitnesGalaxyApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //Выход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow.GetType() == typeof(StartWindow))
            {
                (App.Current.MainWindow as StartWindow)._NavigationFrame.Navigate(new MainMenu());

            }
        }
    }
}
