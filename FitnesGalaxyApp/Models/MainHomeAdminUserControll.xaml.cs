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
    /// Логика взаимодействия для MainHomeAdminUserControll.xaml
    /// </summary>
    public partial class MainHomeAdminUserControll : UserControl
    {
        public MainHomeAdminUserControll(int UserCounter,int ActiveContract)
        {
            InitializeComponent();
            UserCounts.Number = UserCounter.ToString();
            ContratsCounts.Number = ActiveContract.ToString();
            
        }
    }
}
