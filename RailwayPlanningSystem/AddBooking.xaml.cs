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
        public AddBooking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Add code here to show load available coaches and seats
            int seatNo;
            int maxSeats = 60;
            for (seatNo = 1; seatNo < maxSeats; ++seatNo)
            {
                //if ()
            }
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            booking.Name = "Toby";
            booking.Coach = 'C';
            booking.Seat = 4;

            Booking booking1 = new Booking();
            booking1.Name = "John";
            booking1.Coach = 'F';
            booking1.Seat = 26;

            ObjectLists objectLists = new ObjectLists();
            objectLists.Add(booking);
            objectLists.Add(booking1);

            objectLists.PrintBookings();
            //objectLists.BookedSeats();
        }
    }
}
