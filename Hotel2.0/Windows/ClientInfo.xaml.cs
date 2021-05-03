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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       // Entities3 context = new Entities3();
        public  Window1(Guest guest)
        {
            InitializeComponent();
            ArriValBox.Text = "Дата заезда: " + guest.ArrDate;
            DepBox.Text = "Дата выезда: " + guest.DepDate;
            PassportBox.Text = "Паспортные данные: " + guest.Passport;
            FullNameBox.Text = "Полное имя: " + guest.FullName;
            Phone.Text = "Телефон: " + guest.Phone;
            Cost.Text = "Цена за проживание: " + guest.Сost;
            Idroom.Text = "Выбранный номер: " + guest.Room.Number;

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
