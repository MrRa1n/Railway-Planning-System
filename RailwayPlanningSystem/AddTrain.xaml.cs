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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Data;
using Business.TrainClasses;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddTrain : Window
    {
        private List<String> intermediates;
        private TrainDAO trainDAO;

        public AddTrain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboDeparture.SelectedIndex = 0;
            comboDestination.SelectedIndex = 1;
            comboType.SelectedIndex = 0;
            int start = 0;
            for (int i = 1; i <= 48; i++)
            {
                if (i % 2 == 0)
                {
                    comboDepartureTime.Items.Add(start + ":30");
                    start++;
                }
                else
                {
                    comboDepartureTime.Items.Add(start + ":00");
                }
            }
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                // Validation for Sleeper Cabin train type
                if (!((ComboBoxItem)comboType.SelectedItem).Content.Equals("Sleeper") && rdoSleeperYes.IsChecked == true)
                {
                    throw new Exception("Sleeper Cabin is not available for this train type");
                }
                intermediates = new List<String>();
                // Add selected stations to List
                foreach (Control control in stackIntermediates.Children)
                {
                    if (((CheckBox)control).IsChecked == true)
                        intermediates.Add(((CheckBox)control).Content.ToString());
                }

                TimeSpan time = TimeSpan.Parse(comboDepartureTime.Text);
                bool firstClass = (rdoFirstClassYes.IsChecked == true) ? true : false;
                bool sleeperCabin = (rdoSleeperYes.IsChecked == true) ? true : false;

                TrainFactory factory = new TrainFactory();

                Train t = factory.CreateTrain(
                    comboDeparture.Text,
                    comboDestination.Text,
                    ((ComboBoxItem)comboType.SelectedItem).Content.ToString(),
                    time,
                    dateDepartureDay.SelectedDate.Value,
                    firstClass,
                    intermediates,
                    sleeperCabin
                    );

                if (t == null)
                {
                    throw new Exception("Couldn't create train!");
                }


                trainDAO = new TrainDAO();
                trainDAO.Add(t);

                trainDAO.printTrains();
                //t.printTrain();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboDeparture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDeparture.SelectedIndex == 1)
            {
                comboDestination.SelectedIndex = 0;
            }
            else
            {
                comboDestination.SelectedIndex = 1;
            }
        }

        private void comboDestination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDestination.SelectedIndex == 1)
            {
                comboDeparture.SelectedIndex = 0;
            }
            else
            {
                comboDeparture.SelectedIndex = 1;
            }
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)comboType.SelectedItem).Content.Equals("Express"))
            {
                stackIntermediates.IsEnabled = false;
            }
            else
            {
                stackIntermediates.IsEnabled = true;
            }
            
     
        }
    }
}
