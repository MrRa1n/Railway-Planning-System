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
using Business.TrainClasses;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : Window
    {

        ObjectLists objectLists = new ObjectLists();
        List<Train> availableTrains;

        public AddBooking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load trains
            availableTrains = objectLists.getTrains();

            foreach (Train t in availableTrains)
            {
                listTrains.Items.Add(t.TrainID);
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

            objectLists.Add(booking);
            GetSeatList();
        }

        

        private void ListTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboCoach.Items.Clear();
            foreach (Train t in availableTrains)
            {
                if (listTrains.SelectedItem.ToString() == t.TrainID)
                {
                    foreach (Coach c in objectLists.getCoaches())
                    {
                        comboCoach.Items.Add(c.coachId);
                    }
                }
            }
        }

        private void ComboCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSeatList();
        }

        private void GetSeatList()
        {
            foreach (Coach c in objectLists.getCoaches())
            {
                if (char.Parse(comboCoach.SelectedItem.ToString()) == c.coachId)
                {
                    comboSeat.ItemsSource = c.getAvailableSeats();
                }
            }
        }
    }
}
