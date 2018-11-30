using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Business.TrainClasses;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddTrain : Window
    {
        private TrainFactorySingleton trainFactory = TrainFactorySingleton.Instance;
        private TrainStoreSingleton trainStore = TrainStoreSingleton.Instance;

        public AddTrain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set field values upon form loading
            comboDeparture.SelectedIndex = 0;
            comboDestination.SelectedIndex = 1;
            comboType.SelectedIndex = 0;
            dateDepartureDay.Text = DateTime.Today.ToString();

            // Populate combo box with train times
            int hours = 0;
            for (int i = 1; i <= 48; i++)
            {
                if (i % 2 == 0)
                {
                    comboDepartureTime.Items.Add(hours + ":30");
                    hours++;
                }
                else
                {
                    comboDepartureTime.Items.Add(hours + ":00");
                }
            }
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validation for Sleeper Cabin train type
                if (!((ComboBoxItem)comboType.SelectedItem).Content.Equals("Sleeper") && rdoSleeperYes.IsChecked == true)
                    throw new Exception("Sleeper cabin is not available for this train type");
                
                // Loop over each checkbox item and add to intermediates if checked
                List<String> intermediates = null;
                if (stackIntermediates.IsEnabled == true)
                {
                    intermediates = new List<String>();
                    foreach (Control control in stackIntermediates.Children)
                    {
                        if (((CheckBox)control).IsChecked == true)
                            intermediates.Add(((CheckBox)control).Content.ToString());
                    }
                }
                
                // Check if FirstClass and Sleeper have been checked and set value
                bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
                bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

                // Build the train using our factory
                Train t = trainFactory.BuildTrain(
                    comboDeparture.Text,
                    comboDestination.Text,
                    comboType.Text,
                    TimeSpan.Parse(comboDepartureTime.Text),
                    DateTime.Parse(dateDepartureDay.Text),
                    firstClass,
                    intermediates,
                    sleeperCabin
                    );

                if (t == null) throw new Exception("Train failed to create");

                // If train has been created sucessfully, store it and prompt user
                trainStore.Add(t);
                MessageBox.Show("Train has been added successfully");
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    MessageBox.Show("Please select a valid time");
                else
                    MessageBox.Show(ex.Message);
            }
        }

        // If the departure is the same as the destination, change it
        private void comboDeparture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboDestination.SelectedIndex = (comboDeparture.SelectedIndex == 1) ? 0 : 1;
        }
        // If the destination is the same as the departure, change it
        private void comboDestination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboDeparture.SelectedIndex = (comboDestination.SelectedIndex == 1) ? 0 : 1;
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Uncheck and disable all checkboxes if train is Express
            if (((ComboBoxItem)comboType.SelectedItem).Content.Equals("Express"))
            {
                stackIntermediates.IsEnabled = false;
                chkDarlington.IsChecked = false;
                chkNewcastle.IsChecked = false;
                chkPeterborough.IsChecked = false;
                chkYork.IsChecked = false;
            }
            else
            {
                stackIntermediates.IsEnabled = true;
            }
        }
    }
}
