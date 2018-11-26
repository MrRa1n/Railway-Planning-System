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

        TrainSingleton trainSingleton = TrainSingleton.Instance;
        List<Train> availableTrains;
        private string selectedTrainId;
        private char selectedCoachId;

        public AddBooking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load trains
            availableTrains = trainSingleton.getTrains();

            // populate list with each trainID
            foreach (Train t in availableTrains)
            {
                //listTrains.Items.Add(t.TrainID);
            }
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {

            bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
            bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

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

            trainSingleton.Add(booking);

            comboCoach.Items.Clear();
            comboSeat.ItemsSource = null;
        }

        

        private void ListTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboCoach.Items.Clear();
            comboSeat.ItemsSource = null;

            selectedTrainId = listTrains.SelectedItem.ToString();
            Train t = trainSingleton.FindTrain(selectedTrainId);


            foreach (Coach coach in t.CoachList)
            {
                comboCoach.Items.Add(coach.coachId);
            }
                
            
        }

        private void ComboCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (comboCoach.SelectedItem == null)
                return;

            selectedCoachId = char.Parse(comboCoach.SelectedItem.ToString());
            Train train = trainSingleton.FindTrain(selectedTrainId);
            Coach coach = train.FindCoach(selectedCoachId);
            comboSeat.ItemsSource = coach.getAvailableSeats();
                    
                
            
        }

        // load trains into listbox based on what options are selected
        private void BtnFindTrains_Click(object sender, RoutedEventArgs e)
        {
            listTrains.Items.Clear();
            List<String> inters;
            foreach (Train t in availableTrains)
            {
                inters = trainSingleton.getIntermediates(t);
                if (inters == null)
                    listTrains.Items.Add(t.TrainID);
                else if (t.Departure == comboDeparture.Text || inters.Contains(comboDeparture.Text) 
                    && t.Destination == comboArrival.Text || inters.Contains(comboArrival.Text))
                {
                    if (rdoFirstClassYes.IsChecked == true && t.FirstClass == true)
                    {
                        if (rdoSleeperYes.IsChecked == true && t.Type == "Sleeper")
                        {
                            listTrains.Items.Add(t.TrainID);
                            
                        }
                        else
                        {
                            listTrains.Items.Add(t.TrainID);
                        }
                    }
                    else
                    {
                        listTrains.Items.Add(t.TrainID);
                    }
                }
                else
                {
                    listTrains.Items.Add(t.TrainID);
                }
            }
        }
    }
}
