using FitnesGalaxyApp.DataB.DataSetTableAdapters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace FitnesGalaxyApp.Models
{
    /// <summary>
    /// Логика взаимодействия для DataGridTableUserControl.xaml
    /// </summary>
    public partial class DataGridTableUserControl : UserControl
    {
        

        public class Users
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Bthday { get; set; }
            public string Gender { get; set; }
        }
        List<Users> UsersList = new List<Users> { };

        Users user;
        DataB.DataSet BASED = new DataB.DataSet();
        UsersTableAdapter usersTB = new UsersTableAdapter();
        ContractsTableAdapter ContractsTableAdapter = new ContractsTableAdapter();
        Contracts_TypeTableAdapter Contracts_TypeTableAdapter = new Contracts_TypeTableAdapter();
        DoljnostTableAdapter DoljnostTableAdapter = new DoljnostTableAdapter();
        EmployeeTableAdapter EmployeeTableAdapter = new EmployeeTableAdapter();
        FilialsTableAdapter FilialsTableAdapter = new FilialsTableAdapter();
        GenderTableAdapter GenderTableAdapter = new GenderTableAdapter();
        OtdelTableAdapter OtdelTableAdapter = new OtdelTableAdapter();
        Sport_SectionTableAdapter Sport_SectionTableAdapter = new Sport_SectionTableAdapter();
        Sport_TypeTableAdapter Sport_TypeTableAdapter = new Sport_TypeTableAdapter();



        HttpClient client = new HttpClient();
        private AddUsersControll AddUsersControll;
        int ChooserDataGrid = 0;
        
        public DataGridTableUserControl()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://localhost:7022/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




            usersTB.Fill(BASED.Users);


            AddUsersControll = new AddUsersControll();
            MainDataGrid.ItemsSource = BASED.Users.DefaultView;
            TxtDatetable.Text = "Пользователи";
            ChooserDataGrid = 1;
        }


        

        //Удаление записи
        private async void Delete(int clientID)
        {
            await client.DeleteAsync("contract/" + clientID);
        }

        //Получение всех данных
        private async void GetClient()
        {
            var responce = await client.GetStringAsync("contract");
            var clients = JsonConvert.DeserializeObject<List<FitnesGalaxyApp.Model.Contract>>(responce);
            //data.DataContext = clients;
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ChooserDataGrid == 1)
            {
                if (null != MainDataGrid.SelectedItem)
                {

                    DataGridParse.Children.Add(new EditUserControl((int)BASED.Users.Rows[MainDataGrid.SelectedIndex][0], (string)BASED.Users.Rows[MainDataGrid.SelectedIndex][1], (string)BASED.Users.Rows[MainDataGrid.SelectedIndex][2], (string)BASED.Users.Rows[MainDataGrid.SelectedIndex][3], (string)BASED.Users.Rows[MainDataGrid.SelectedIndex][4], (DateTime)BASED.Users.Rows[MainDataGrid.SelectedIndex][5], int.Parse((string)BASED.Users.Rows[MainDataGrid.SelectedIndex][6]), (int)BASED.Users.Rows[MainDataGrid.SelectedIndex][7]));
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ChooserDataGrid == 1)
            {
                if (null != MainDataGrid.SelectedItem)
                {
                    usersTB.DeleteQuery((int)BASED.Users.Rows[MainDataGrid.SelectedIndex][0]);
                    usersTB.Fill(BASED.Users);
                    MainDataGrid.ItemsSource = BASED.Users.DefaultView;
                }
            }
            
        }

       

        private void Staff_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 1;
            TxtDatetable.Text = "Пользователи";
            usersTB.Fill(BASED.Users);
            MainDataGrid.ItemsSource = BASED.Users.DefaultView;

        }

        private void Contracts_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 2;
            TxtDatetable.Text = "Договора";
            ContractsTableAdapter.Fill(BASED.Contracts);
            MainDataGrid.ItemsSource = BASED.Contracts.DefaultView;
        }

        private void StafDeploy_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 3;
            TxtDatetable.Text = "Должности";
            DoljnostTableAdapter.Fill(BASED.Doljnost);
            MainDataGrid.ItemsSource = BASED.Doljnost.DefaultView;
        }

        private void ContractType_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 4;
            TxtDatetable.Text = "Типы договоров";
            Contracts_TypeTableAdapter.Fill(BASED.Contracts_Type);
            MainDataGrid.ItemsSource = BASED.Contracts_Type.DefaultView;
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 5;
            TxtDatetable.Text = "Сотрудники";
            EmployeeTableAdapter.Fill(BASED.Employee);
            MainDataGrid.ItemsSource = BASED.Employee.DefaultView;
        }

        private void Filials_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 6;
            TxtDatetable.Text = "Филиалы";
            FilialsTableAdapter.Fill(BASED.Filials);
            MainDataGrid.ItemsSource = BASED.Filials.DefaultView;
        }

        private void Gender_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 7;
            TxtDatetable.Text = "Гендер";
            GenderTableAdapter.Fill(BASED.Gender);
            MainDataGrid.ItemsSource = BASED.Gender.DefaultView;
        }

        private void StafOtdel_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 8;
            TxtDatetable.Text = "Отделы";
            OtdelTableAdapter.Fill(BASED.Otdel);
            MainDataGrid.ItemsSource = BASED.Otdel.DefaultView;
        }

        private void SportSection_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 9;
            TxtDatetable.Text = "Спортивные секции";
            Sport_SectionTableAdapter.Fill(BASED.Sport_Section);
            MainDataGrid.ItemsSource = BASED.Sport_Section.DefaultView;
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            if(ChooserDataGrid==1)
            {
                if (DataGridParse.Children.Contains(AddUsersControll))
                {

                }
                else
                {

                    DataGridParse.Children.Add(AddUsersControll);
                }
            }
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            if (ChooserDataGrid == 1)
            {
                usersTB.Fill(BASED.Users);
                MainDataGrid.ItemsSource = BASED.Users.DefaultView;
            }
            if (ChooserDataGrid == 2)
            {
                ContractsTableAdapter.Fill(BASED.Contracts);
                MainDataGrid.ItemsSource = BASED.Contracts.DefaultView;
            }
        }

        private void Sport_Click(object sender, RoutedEventArgs e)
        {
            ChooserDataGrid = 10;
            TxtDatetable.Text = "Спорт";
            Sport_TypeTableAdapter.Fill(BASED.Sport_Type);
            MainDataGrid.ItemsSource = BASED.Sport_Type.DefaultView;
        }

        //Экспорт в Excel файл 
        private void ExportData_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = null;
            Excel.Workbook wb = null;

            object missing = Type.Missing;
            Excel.Worksheet ws = null;
            Excel.Range rng = null;

            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            DataView view = (DataView)MainDataGrid.ItemsSource;
            DataTable dt = DataViewAsDataTable(view);

            for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
            {
                ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
            }

            for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
            {
                ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
            }

            excel.Visible = true;
            wb.Activate();

            
        }

        //Помощник для экспорта
        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
        }


    }
}
