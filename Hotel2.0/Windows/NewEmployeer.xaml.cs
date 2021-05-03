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
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewEmployeer : Window
    {
        public int tipperem { get; set; }
        public int IDHotel;
        public NewEmployeer(int id_hotel)
        {
            IDHotel = id_hotel;
            //kostil.Text = id_hotel;
            InitializeComponent();
            var post = context.EmployersPost.Select(i => i.PostName).ToList();
            post.Insert(0, "");
            Post.ItemsSource = post;
            kostil.Text = id_hotel.ToString();
            var gender = context.Gender.Select(i=>i.GenderName).ToList();
            gender.Insert(0,"");
            Gen.ItemsSource = gender;
            Birthday.DisplayDateEnd = System.DateTime.Today;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
           
            if (kostil.Text == "1")
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
                if (IDHotel == 1)
                {
                    context.Employers.Add(new Entity.Employers
                    {
                        FirstName = SurnameTB.Text,
                        LastName = NameTB.Text,
                        Patronymic = PatronymicTB.Text,
                        PassportSerial = Convert.ToInt32(SeriaTB.Text),
                        PassportNumber = Convert.ToInt32(PasNumTB.Text),
                        PostID = Post.SelectedIndex,
                        WorkingStartDate = work.SelectedDate.Value,
                        BirthdayDate = Birthday.SelectedDate.Value,
                        Age = Convert.ToInt32(System.DateTime.Today.Year - Birthday.SelectedDate.Value.Year),
                        INN = Convert.ToInt64(InnTB.Text),
                        SNILS = Convert.ToInt64(snilsTB.Text),
                        HotelID = 1,
                        Gender = Gen.SelectedIndex,
                    }); 
                    MessageBox.Show("Успех");
                    context.SaveChanges();
                }
                else if (IDHotel == 2)
                {
                
                context.Employers.Add(new Entity.Employers
                    {
                        
                        FirstName = SurnameTB.Text,
                        LastName = NameTB.Text,
                        Patronymic = PatronymicTB.Text,
                        PassportSerial = Convert.ToInt32(SeriaTB.Text),
                        PassportNumber = Convert.ToInt32(PasNumTB.Text),
                        PostID = Post.SelectedIndex,
                        WorkingStartDate = work.SelectedDate.Value,
                        BirthdayDate = Birthday.SelectedDate.Value,
                        Age = Convert.ToInt32(System.DateTime.Today.Year - Birthday.SelectedDate.Value.Year),
                        INN = Convert.ToInt64(InnTB.Text),
                        SNILS = Convert.ToInt64(snilsTB.Text),
                        HotelID = 2,
                        Gender = Gen.SelectedIndex,
                    }); 
                    MessageBox.Show("Успех");
                    context.SaveChanges();
                }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }

    }

}
