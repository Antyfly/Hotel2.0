using Hotel2._0.Entity;
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
using System.Windows.Shapes;
using static Hotel2._0.Entity.AppData;

namespace Hotel2._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для Delta.xaml
    /// </summary>
    public partial class Delta : Window
    {
        List<Guest> datasourse = new List<Guest>();
        List<Employers> empsourse = new List<Employers>();
        public static int id_hotel;
        public int Page { get; set; } = 0;
        public int RoomNumber { get; set; } = 0;
        public Delta()
        {
            InitializeComponent();
            DataContext = this;
            //var roomnumb = context.Room.Where(i=>i.ID_Hotel==1).Select(i => i.Number).ToList();
            //roomnumb.Insert(0, 0);
            //BoxNumber.ItemsSource = roomnumb;
            Update();
            datasourse = context.Guest.Where(i => i.ID_Hotel == 1).ToList();
            empsourse = context.Employers.Where(i => i.HotelID == 1).ToList();
        }

        public  void Update()
        {
            List.ItemsSource = datasourse;
            Employee.ItemsSource = empsourse;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mi = new MainWindow();
            this.Close();
            mi.Show();
        }

        private void MainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page = 0;
            Update();
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(List.SelectedItem is Guest guest)
            {
                Window1 wi = new Window1(guest);
                wi.ShowDialog();

            }
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            if (TBPoisk.Text == "" && DepartureDate.SelectedDate == null && ArrivalDate.SelectedDate != null)
            {
                datasourse= datasourse.Where(i => i.ArrivalDate == ArrivalDate.SelectedDate).ToList();

            }
            else if (TBPoisk.Text == "" && DepartureDate.SelectedDate != null && ArrivalDate.SelectedDate != null)
            {
                datasourse = datasourse.Where(i => i.ArrivalDate == ArrivalDate.SelectedDate && i.DepartureDate == DepartureDate.SelectedDate).ToList();
            }
            else if (TBPoisk.Text != "" && DepartureDate.SelectedDate == null && ArrivalDate.SelectedDate == null)
            {
                datasourse = datasourse.Where(i => i.Surname.ToLower() == TBPoisk.Text).ToList();
            }
            else if (TBPoisk.Text == "" && DepartureDate.SelectedDate != null && ArrivalDate.SelectedDate == null)
            {
                datasourse = datasourse.Where(i => i.DepartureDate == DepartureDate.SelectedDate).ToList();
            }
            else if (TBPoisk.Text == "" && DepartureDate.SelectedDate == null && ArrivalDate.SelectedDate == null)
            {
                datasourse = context.Guest.Where(i => i.ID_Hotel == 1).ToList();
            }
            Update();
        }

        private void New_btn_Click(object sender, RoutedEventArgs e)
        {
            int idhotel = datasourse.Select(i => i.ID_Hotel).FirstOrDefault();
            NewClient client = new NewClient(idhotel);
            this.Hide();
            client.ShowDialog();
        }

        private void NewBtnEmp_Click(object sender, RoutedEventArgs e)
        {
            int idhotel = datasourse.Select(i => i.ID_Hotel).FirstOrDefault();
            NewEmployeer newEmp = new NewEmployeer(idhotel);
            this.Hide();
            newEmp.ShowDialog();
        }

        private void PoiskEmpBT_Click(object sender, RoutedEventArgs e)
        { 
            if (lnEmp.Text != "" && NEmp.Text == ""  && PEmp.Text == "")
            {
                 empsourse= empsourse.Where(i => i.FirstName.ToLower() == lnEmp.Text).ToList();

            }
            else if (lnEmp.Text != "" && NEmp.Text != "" && PEmp.Text == "")
            {
                empsourse = empsourse.Where(i => i.FirstName.ToLower() == lnEmp.Text && i.LastName.ToLower() == NEmp.Text).ToList();
            }
            else if (lnEmp.Text == "" && NEmp.Text != "" && PEmp.Text == "")
            {
                empsourse = empsourse.Where(i => i.LastName.ToLower() == NEmp.Text).ToList();
            }
            else if (lnEmp.Text == "" && NEmp.Text != "" && PEmp.Text != "")
            {
                empsourse = empsourse.Where(i => i.LastName.ToLower() == NEmp.Text && i.FirstName.ToLower() == PEmp.Text).ToList();
            }
            else if (lnEmp.Text != "" && NEmp.Text != "" && PEmp.Text != "")
            {
                empsourse = empsourse.Where(i => i.LastName.ToLower() == NEmp.Text && i.FirstName.ToLower() == PEmp.Text && i.Patronymic.ToLower() == PEmp.Text).ToList();
            }
            else if (lnEmp.Text == "" && NEmp.Text == "" && PEmp.Text == "")
            {
                empsourse = context.Employers.Where(i => i.HotelID == 1).ToList();
            }
            Update();
        }

        private void Employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Employee.SelectedItem is Employers emp)
            {
                EmployeerInfo wi = new EmployeerInfo(emp);
                wi.ShowDialog();
                Update();

            }
        }
    }
}
