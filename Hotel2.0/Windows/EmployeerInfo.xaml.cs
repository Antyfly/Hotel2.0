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
using static Hotel2._0.Windows.Delta;

namespace Hotel2._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EmployeerInfo : Window
    {
        public Employers employeers;
        //List<int> empsourse = new List<int>();
        public EmployeerInfo(Employers emp)
        {
            InitializeComponent();
            WorkingStation.Text = "Дата начала работы: " + emp.WorkDate;
            Post.Text = "Занимаемая должность: " + emp.EmployersPost.PostName;
            FullNameBox.Text = "Полное имя: " + emp.FullName;
            PassportBox.Text = "Паспортные данные: " + emp.Passport ;
            BirthdayDate.Text = "Дата рождения: " + emp.BirthDate;
            INN.Text = "ИНН: " + emp.INN;
            SNILS.Text = "Страховой полис: " + emp.SNILS;
            Gender.Text = "Пол: " + emp.Gender1.GenderName;
            Age.Text = "Возраст: " + emp.Age;
            employeers = emp;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            context.Employers.Remove(employeers);
            context.SaveChanges();
            MessageBox.Show("Сотрудник удален!", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            
        }
    }
}
