using FitnesGalaxyApp.DataB.DataSetTableAdapters;
using FitnesGalaxyApp.Models;
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

namespace FitnesGalaxyApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        MainHomeAdminUserControll HomeAdminContent;
        AboutProgrammUserControll AboutProgrammUserControll;
        DataGridTableUserControl DataGridTableUserControl;
        ContractsUserControl ContractsUserControl;

        DataB.DataSet BASED = new DataB.DataSet();
        UsersTableAdapter usersTB = new UsersTableAdapter();
        ContractsTableAdapter ContractsTableAdapter = new ContractsTableAdapter();
        public MainAdminPage(string name,string Surname)
        {

            InitializeComponent();
            TextUserName.Text = name+" "+Surname;
            HelloText.Text = "Добрый день,"+name;
            TextUserNameDefolt.Text =Surname[0].ToString()+name[0].ToString();
            Home.Style = (Style)FindResource("menuButtonsActive");

            usersTB.Fill(BASED.Users);
            ContractsTableAdapter.Fill(BASED.Contracts);
            HomeAdminContent = new MainHomeAdminUserControll(BASED.Users.Count, BASED.Contracts.Count);
            AboutProgrammUserControll = new AboutProgrammUserControll();
            DataGridTableUserControl = new DataGridTableUserControl();
            ContractsUserControl = new ContractsUserControl();

            ContentGrid.Children.Add(HomeAdminContent);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home.Style = (Style)FindResource("menuButtonsActive");


            if (!ContentGrid.Children.Contains(HomeAdminContent))
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(HomeAdminContent);
            }
            
            Contracts.Style = (Style)FindResource("menuButtons");
            TableData.Style = (Style)FindResource("menuButtons");
            Settings.Style = (Style)FindResource("menuButtons");
            About.Style = (Style)FindResource("menuButtons");
        }

        private void Contracts_Click(object sender, RoutedEventArgs e)
        {
            Contracts.Style = (Style)FindResource("menuButtonsActive");


            if (!ContentGrid.Children.Contains(ContractsUserControl))
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(ContractsUserControl);
            }

            Home.Style = (Style)FindResource("menuButtons");
            TableData.Style = (Style)FindResource("menuButtons");
            Settings.Style = (Style)FindResource("menuButtons");
            About.Style = (Style)FindResource("menuButtons");
        }

        private void TableData_Click(object sender, RoutedEventArgs e)
        {
            TableData.Style = (Style)FindResource("menuButtonsActive");


            if (!ContentGrid.Children.Contains(DataGridTableUserControl))
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(DataGridTableUserControl);
            }

            Home.Style = (Style)FindResource("menuButtons");
            Contracts.Style = (Style)FindResource("menuButtons");
            Settings.Style = (Style)FindResource("menuButtons");
            About.Style = (Style)FindResource("menuButtons");
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Style = (Style)FindResource("menuButtonsActive");

            Home.Style = (Style)FindResource("menuButtons");
            Contracts.Style = (Style)FindResource("menuButtons");
            TableData.Style = (Style)FindResource("menuButtons");
            About.Style = (Style)FindResource("menuButtons");
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow.GetType() == typeof(StartWindow))
            {
                (App.Current.MainWindow as StartWindow)._NavigationFrame.Navigate(new StartPage());

            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About.Style = (Style)FindResource("menuButtonsActive");

            if (!ContentGrid.Children.Contains(AboutProgrammUserControll))
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(AboutProgrammUserControll);
            }

            Home.Style = (Style)FindResource("menuButtons");
            Contracts.Style = (Style)FindResource("menuButtons");
            TableData.Style = (Style)FindResource("menuButtons");
            Settings.Style = (Style)FindResource("menuButtons");
        }
    }
}
