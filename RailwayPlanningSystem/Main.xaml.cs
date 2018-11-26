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

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        private TrainSingleton trainSingleton = TrainSingleton.Instance;

        public Main()
        {
            InitializeComponent();
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddTrain frmAddTrain = new AddTrain();
            frmAddTrain.ShowDialog();
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            AddBooking frmAddBooking = new AddBooking();
            frmAddBooking.ShowDialog();
        }
    }
}
