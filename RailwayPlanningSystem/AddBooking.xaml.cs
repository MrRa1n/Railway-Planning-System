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
using Business;
using Business.BookingClasses;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : Window
    {

        ObjectLists objectLists = new ObjectLists();
        public AddBooking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load available coaches
            for (char i = 'a'; i <= 'h'; ++i)
            {
                comboCoach.Items.Add(i);
            }
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {

            bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
            bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

            Booking booking = new Booking(
                txtName.Text,
                "gfhgf",
                comboDeparture.Text,
                comboArrival.Text,
                firstClass,
                sleeperCabin,
                char.Parse(comboCoach.Text),
                int.Parse(comboSeat.Text)
                );

            

            if (objectLists.BookedSeats(char.Parse(comboCoach.Text), int.Parse(comboSeat.Text)))
            {
                MessageBox.Show("Seat is taken.");
            }
            else
            {
                objectLists.Add(booking);
            }
            
        }

        private void ComboCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
