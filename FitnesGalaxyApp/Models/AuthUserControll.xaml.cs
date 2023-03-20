using FitnesGalaxyApp.Pages;
using FitnesGalaxyApp.Windows;
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

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для AuthUserControll.xaml
    /// </summary>
    public partial class AuthUserControll : UserControl
    {
        public AuthUserControll()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text=="Admin")
                if(Password.Password=="12345678")
                {
                  
                    
                    if(App.Current.MainWindow.GetType() == typeof(StartWindow))
                    {
                        (App.Current.MainWindow as StartWindow)._NavigationFrame.Navigate(new MainMenu());
                        MessageBox.Show("Вход в систему произведен успешно!");
                    }


                    
                }
        }
    }
}
