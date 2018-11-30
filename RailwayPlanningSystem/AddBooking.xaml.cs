﻿using System;
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
        private TrainStoreSingleton trainStore = TrainStoreSingleton.Instance;
        private string selectedTrainId;

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
                // Check if FirstClass and Sleeper have been checked and set value
                bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
                bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

                // Throw exception if user tries to book first class on train that doesnt offer it
                if (firstClass && !trainStore.FindTrain(selectedTrainId).FirstClass)
                    throw new ArgumentException("The selected train does not offer First Class!");

                // Throw exception if user tries to book sleeper cabin on train that doesnt offer it
                if (sleeperCabin && trainStore.FindTrain(selectedTrainId).Type != "Sleeper")
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

                // Reset the form fields
                txtName.Clear();
                listTrains.SelectedIndex = -1;
                clearAllFields();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                    MessageBox.Show("Please select a coach and a seat");
                else
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
                Train t = trainStore.FindTrain(selectedTrainId);

                // Fill combo box with stations set in train form
                comboDeparture.ItemsSource = trainStore.getDepartureStations(t);
                comboArrival.ItemsSource = trainStore.getArrivalStations(t);

                // Add available coaches to combo box
                foreach (Coach coach in t.CoachList)
                {
                    comboCoach.Items.Add(coach.coachId);
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
                Train train = trainStore.FindTrain(selectedTrainId);

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
            double bookingCost = trainStore.calculateBookingCost(selectedTrainId, comboDeparture.Text, comboArrival.Text, rdoFirstClassYes.IsChecked.Value, rdoSleeperYes.IsChecked.Value);

            MessageBox.Show("Total ticket price: £" + bookingCost);
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
