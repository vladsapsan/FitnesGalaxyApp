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
    /// Логика взаимодействия для LastNewUserControll.xaml
    /// </summary>
    public partial class LastNewUserControll : UserControl
    {
        public LastNewUserControll()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(LastNewUserControll));

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string), typeof(LastNewUserControll));
        public string SecName
        {
            get { return (string)GetValue(SecNameProperty); }
            set { SetValue(SecNameProperty, value); }
        }
        public static readonly DependencyProperty SecNameProperty = DependencyProperty.Register("SecName", typeof(string), typeof(LastNewUserControll));

        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(LastNewUserControll));
    }
}
