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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Business.TrainClasses;

namespace RailwayPlanningSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboDeparture.SelectedIndex = 0;
            comboDestination.SelectedIndex = 1;

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

            

            TrainFactory factory = new TrainFactory();

            Train t = factory.CreateTrain("","",null,"Express",DateTime.MinValue,DateTime.MinValue,true,null,true);

            t.printTrain();
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