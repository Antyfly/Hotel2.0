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
using static Hotel2._0.Windows.Delta;
using static Hotel2._0.Entity.AppData;

namespace Hotel2._0.Windows
{
   
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        public int IDHotel;
        public int tipperem { get; set; }
        List<int> delroomnumb = new List<int>();
        List<int> roomnumb = new List<int>();

        public NewClient(int id_hotel)
        {
            InitializeComponent();
            IDHotel = id_hotel;
            kostilu.Text = id_hotel.ToString();
            var tiperoom = context.TipeRoom.Select(i=>i.TipeRoom1).ToList();
            tiperoom.Insert(0,"");
            Tipe.ItemsSource = tiperoom;
            ArrivalDate.DisplayDateStart = System.DateTime.Today;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
           
            if (id_hotel == 1)
            {
                Delta delt = new Delta();
                this.Close();
                delt.ShowDialog();
                
            }
           else 
            {
                Gamma gam = new Gamma();
                this.Close();
                gam.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    context.Guest.Add(new Entity.Guest
                    {
                        Surname = SurnameTB.Text,
                        Name = NameTB.Text,
                        Patronymic = PatronymicTB.Text,
                        Passport = PassportTB.Text,
                        ArrivalDate = ArrivalDate.SelectedDate.Value,
                        DepartureDate = DepartureDate.SelectedDate.Value,
                        ID_Room = BoxNumber.SelectedIndex,
                        Quantity = Convert.ToInt32(Quantity.Text),
                        Phone = PhoneBox.Text,
                        Сost = Convert.ToInt32(Cost.Content),
                    }); ;
                    MessageBox.Show("Успех");
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }

        private void Tipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipperem = Tipe.SelectedIndex;
            roomnumb.AddRange(context.Room.Where(i => i.ID_Hotel == IDHotel && i.ID_TipeRoom == tipperem).Select(i => i.Number).ToList());
            delroomnumb.AddRange(context.kastil.Where(i => (i.DepartureDate >= ArrivalDate.SelectedDate || ArrivalDate.SelectedDate == null) && (i.ArrivalDate <= DepartureDate.SelectedDate || DepartureDate.SelectedDate == null) && i.ID_Hotel == IDHotel).Select(j=>j.Number).ToList());
            delroomnumb = delroomnumb.Distinct().ToList();

            for (int i = 0; i < delroomnumb.Count; i++)
            {
                roomnumb.Remove(delroomnumb[i]);
            }
             roomnumb.Insert(0, 0); 
             BoxNumber.ItemsSource = roomnumb;
        }

        private void BoxNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var raschet = context.TipeRoom.Where(i => i.ID_TipeRoom == Tipe.SelectedIndex).Select(i => i.Price).ToList();
            decimal rsch = raschet.First();
            var days = DepartureDate.SelectedDate.Value - ArrivalDate.SelectedDate.Value;
            decimal result = Math.Round((days.Days * rsch), 2);
            Cost.Content = result;
        }
    }
}
