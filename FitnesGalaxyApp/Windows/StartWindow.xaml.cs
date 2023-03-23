using FitnesGalaxyApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace FitnesGalaxyApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        bool MainWindowState = true;
        
        public StartWindow()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new StartPage());


            
        }

       

        /// <summary>
        /// Разворачивание/нормализация окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindowState)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                MainWindowState = true;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                MainWindowState = false;
            }

        }

        /// <summary>
        /// Кнопка Свернуть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void GridWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
            
        }
    }
}
