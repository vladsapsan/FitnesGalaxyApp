using FitnesGalaxyApp.Pages;
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
using FitnesGalaxyApp.DataB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для AuthUserControll.xaml
    /// </summary>
    public partial class AuthUserControll : UserControl
    {
        
        DataB.DataSet BASED = new DataB.DataSet();
        
        UsersTableAdapter usersTB = new UsersTableAdapter();

        public AuthUserControll()
        {
            InitializeComponent();
            usersTB.Fill(BASED.Users);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            


            for (int i = 0; i < BASED.Users.Rows.Count; i++)
            {

                if (Login.Text == BASED.Users.Rows[i][1].ToString() && GetHash(Password.Password) == BASED.Users.Rows[i][2].ToString() && BASED.Users.Rows[i][7].ToString()=="1")
                {

                    (App.Current.MainWindow as StartWindow)._NavigationFrame.Navigate(new MainAdminPage(BASED.Users.Rows[i][3].ToString(), BASED.Users.Rows[i][4].ToString()));

                }
                
            }
            

        }
        public string GetHash(string stringhash)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(stringhash));

            return Convert.ToBase64String(hash);
        }
    }
}
