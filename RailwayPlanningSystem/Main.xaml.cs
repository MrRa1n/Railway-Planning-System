﻿/**
 *  Author:             Toby Cook
 *  Description:        This is the code behind the Main form for the Railway Planning System.
 *                      It contains all event handlers that control the user input and how Trains and Bookings
 *                      are displayed and queried by the user.
 *  Last modified:      07/12/18
 *  Design patterns:    This class uses an instance of the TrainStoreSingleton class.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Data;
using Business;
using Business.BookingClasses;
using Business.TrainClasses;
using Microsoft.Win32;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private TrainStoreSingleton trainStore = TrainStoreSingleton.Instance;

        public Main()
        {
            InitializeComponent();
        }

        private void FrmMain_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> stations = new List<String>() { "Edinburgh (Waverley)", "Newcastle", "Darlington", "York", "Peterborough", "London (Kings Cross)" };

            // Load stations into for station search
            comboDeparture.ItemsSource = stations;
            comboArrival.ItemsSource = stations;
        }

        // Button event handler for opening Add Train form
        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddTrain frmAddTrain = new AddTrain();
            frmAddTrain.ShowDialog();
        }

        // Button event handler fpr opening Add Booking form
        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            AddBooking frmAddBooking = new AddBooking();
            frmAddBooking.ShowDialog();
        }

        
        private void BtnSaveTrains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String fileName = "";

                // Create new SaveFileDialog instance and set filter to JSON files
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files (*.json) | *.json";

                // Set the file name of the selected file
                if (saveFileDialog.ShowDialog() == true)
                {
                    fileName = saveFileDialog.FileName;
                }
                // Perform serialization
                trainStore.serializeTrain(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLoadTrains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String fileName = "";
                // Create new OpenFileDialog instance and set filter to JSON files
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON Files (*.json) | *.json";

                // Set the file name of the selected file
                if (openFileDialog.ShowDialog() == true)
                {
                    fileName = openFileDialog.FileName;
                }
                dataAllTrains.DataContext = null;
                dataPassengerList.DataContext = null;
                // Perform deserialization
                trainStore.deserializeTrain(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // View each train by the selected date
        private void BtnViewTrains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new instance of trainDataTable
                DataTable trainDataTable = new DataTable();

                // Assign each column based on Train properties
                trainDataTable.Columns.Add("Train ID");
                trainDataTable.Columns.Add("Type");
                trainDataTable.Columns.Add("Departure");
                trainDataTable.Columns.Add("Destination");
                trainDataTable.Columns.Add("Intermediates");
                trainDataTable.Columns.Add("Departure Time");
                trainDataTable.Columns.Add("Departure Date");
                trainDataTable.Columns.Add("Sleeper Cabin");
                trainDataTable.Columns.Add("First Class");

                // Loop over the list of stored trains returned from getTrains() method
                foreach (Train t in trainStore.getTrains())
                {
                    bool sleeperValue = false;

                    // Set sleeper value to that of SleeperTrain's
                    if (t is SleeperTrain)
                        sleeperValue = ((SleeperTrain)t).SleeperCabin;

                    // Format the date to remove trailing time
                    String formattedDate = t.DepartureDay.ToString("dd/MM/yy");

                    // Only add trains to DataGrid that match the selected time
                    if (t.DepartureDay.Equals(dateViewTrains.SelectedDate))
                    {
                        trainDataTable.Rows.Add(
                        t.TrainID,
                        t.Type,
                        t.Departure,
                        t.Destination,
                        trainStore.intermediateList(t),
                        t.DepartureTime.ToString(@"hh\:mm"),
                        formattedDate,
                        sleeperValue,
                        t.FirstClass
                        );
                    }
                }
                // Bind DataGrid to our data table to display trains in our form
                dataAllTrains.DataContext = trainDataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void BtnFindTrains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Compare value of combo boxes and throw and exception if they are equal
                if (comboDeparture.Text.Equals(comboArrival.Text))
                    throw new Exception("Stations cannot be the same!");

                // Create new instance of trainDataTable
                DataTable trainDataTable = new DataTable();

                // Assign each column based on Train properties
                trainDataTable.Columns.Add("Train ID");
                trainDataTable.Columns.Add("Departure Date");
                trainDataTable.Columns.Add("Departure Time");

                // Loop over the list of stored trains returned from getTrains() method
                foreach (Train t in trainStore.getTrains())
                {
                    // Compare the destination and arrival values selected to those stored in the train
                    if (trainStore.getDepartureStations(t).Contains(comboDeparture.Text)
                        && trainStore.getArrivalStations(t).Contains(comboArrival.Text))
                    {
                        // Format the date to remove the time
                        String formattedDate = t.DepartureDay.ToString("dd/MM/yy");
                        // Add trains to data table if they travel between selected stations
                        trainDataTable.Rows.Add(t.TrainID, formattedDate, t.DepartureTime.ToString(@"hh\:mm"));
                    }
                }
                // Bind DataGrid to our data table to display trains in our form
                dataAllTrains.DataContext = trainDataTable.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }

        private void DataAllTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Store details from the selected row in a DataRowView
            DataRowView row = (DataRowView)dataAllTrains.SelectedItem;
            
            if (row == null) return;

            // Call FrindTrain method and pass it the Train ID from our DataRowView
            Train t = trainStore.findTrain(row[0].ToString());

            // Create new instance of data table for bookings
            DataTable bookingDataTable = new DataTable();

            // Assign each column name
            bookingDataTable.Columns.Add("Name");
            bookingDataTable.Columns.Add("Coach");
            bookingDataTable.Columns.Add("Seat");

            // Loop over each coach and booking within that coach and add to our data table
            foreach (Coach c in trainStore.getCoaches(t.TrainID))
            {
                foreach (Booking b in c.ListOfBookings)
                {
                    bookingDataTable.Rows.Add(
                        b.Name,
                        b.Coach,
                        b.Seat
                        );
                }
            }
            // Bind DataGrid to our data table to display bookings in our form
            dataPassengerList.DataContext = bookingDataTable.DefaultView;
        }
    }
}
