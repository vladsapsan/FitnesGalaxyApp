using FitnesGalaxyApp.Models;
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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {

        private AuthUserControll AuthUserControll;
        private SignUpUserControll SignUpUserControll;
        public StartPage()
        {

            InitializeComponent();
            AuthUserControll = new AuthUserControll();
            SignUpUserControll = new SignUpUserControll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MainGrid.Children.Contains(AuthUserControll))
            {

            }
            else
            {
                if (MainGrid.Children.Contains(SignUpUserControll))
                {
                    MainGrid.Children.Remove(SignUpUserControll);
                }
                MainGrid.Children.Add(AuthUserControll);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Children.Contains(SignUpUserControll))
            {

            }
            else
            {
                if (MainGrid.Children.Contains(AuthUserControll))
                {
                    MainGrid.Children.Remove(AuthUserControll);
                }
                MainGrid.Children.Add(SignUpUserControll);
            }
        }
    }
}
