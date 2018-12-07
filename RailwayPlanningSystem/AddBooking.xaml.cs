/**
 *  Author:             Toby Cook
 *  Description:        This is the code behind the Add Booking form for the Railway Planning System.
 *                      It contains all event handlers that control the user input and how bookings are added
 *                      to a train.
 *  Last modified:      07/12/18
 *  Design patterns:    This class uses an instance of the TrainStoreSingleton class.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using Data;
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
        private TrainStoreSingleton trainStore = TrainStoreSingleton.Instance;
        private String selectedTrainId;

        public AddBooking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate listbox with train IDs when form loads
            foreach (Train t in trainStore.getTrains())
            {
                listTrains.Items.Add(t.TrainID);
            }
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check that the order of the stations is correct
                trainStore.checkStationOrder(selectedTrainId, comboDeparture.Text, comboArrival.Text);

                // Check if FirstClass and Sleeper have been checked and set value
                bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
                bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

                // Throw exception if user tries to book first class on train that doesnt offer it
                if (firstClass && !trainStore.findTrain(selectedTrainId).FirstClass)
                    throw new ArgumentException("The selected train does not offer First Class!");

                // Throw exception if user tries to book sleeper cabin on train that doesnt offer it
                if (sleeperCabin && trainStore.findTrain(selectedTrainId).Type != "Sleeper")
                    throw new ArgumentException("The selected train does not offer Sleeper Cabin!");
                
                // Create new booking
                Booking booking = new Booking(
                    txtName.Text,
                    selectedTrainId,
                    comboDeparture.Text,
                    comboArrival.Text,
                    firstClass,
                    sleeperCabin,
                    char.Parse(comboCoach.Text),
                    int.Parse(comboSeat.Text)
                    );

                // Store the booking
                trainStore.Add(booking);

                MessageBox.Show("Booking added successfully");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listTrains.SelectedItem == null) return;
                clearAllFields();

                // Get id of selected train and return train info
                selectedTrainId = listTrains.SelectedItem.ToString();
                Train t = trainStore.findTrain(selectedTrainId);

                // Fill combo box with stations set in train form
                comboDeparture.ItemsSource = trainStore.getDepartureStations(t);
                comboArrival.ItemsSource = trainStore.getArrivalStations(t);

                // Add available coaches to combo box
                foreach (Coach coach in t.CoachList)
                {
                    comboCoach.Items.Add(coach.CoachID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ComboCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (comboCoach.SelectedItem == null) return;

                // Get the selected coach id
                char selectedCoachId = char.Parse(comboCoach.SelectedItem.ToString());

                // Get the train information for the selected train id
                Train train = trainStore.findTrain(selectedTrainId);

                // Find the coach within the train by its id
                Coach coach = train.FindCoach(selectedCoachId);

                // Set the item source for combo box to the list of available seats
                comboSeat.ItemsSource = coach.ListOfAvailableSeats;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCalculateFare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Pass the selected fields to calculate the cost
                double bookingCost = trainStore.calculateBookingCost(selectedTrainId, comboDeparture.Text, comboArrival.Text, rdoFirstClassYes.IsChecked.Value, rdoSleeperYes.IsChecked.Value);
                // Display the cost to the user
                MessageBox.Show("Total ticket price: £" + bookingCost);
                btnAddBooking.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void clearAllFields()
        {
            comboCoach.Items.Clear();
            comboSeat.ItemsSource = null;
            comboDeparture.ItemsSource = null;
            comboArrival.ItemsSource = null;
        }
    }
}
