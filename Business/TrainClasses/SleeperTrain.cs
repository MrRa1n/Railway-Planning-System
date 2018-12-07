/**
 *  Author:             Toby Cook
 *  Description:        This class is a child class to Train and is a more specified implementation
 *                      of the Train class. It addes two more specific properties; intermediates and sleeper cabin
 *  Last modified:      07/12/18
 *  Design patterns:    This class is a part of the Factory design pattern.
 */

using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class SleeperTrain : Train
    {
        public const String MaxNumberOfIntermediatesExceeded = "There cannot be more than 4 intermediate stations";

        private List<String> intermediate;
        private bool sleeperCabin;

        /// <summary>
        /// Intermediate property to store a list of selected stations
        /// </summary>
        public List<String> Intermediate
        {
            get { return intermediate; }
            set
            {
                if (value.Count > 4)
                {
                    throw new ArgumentOutOfRangeException("Intermediate Stations Exceeded", value, MaxNumberOfIntermediatesExceeded);
                }
                intermediate = value;
            }
        }

        /// <summary>
        /// Sleeper Cabin property to store whether train offers sleeper cabin
        /// </summary>
        public bool SleeperCabin
        {
            get { return sleeperCabin; }
            set
            {
                sleeperCabin = value;
            }
        }
        
        /// <summary>
        /// Default constructor for SleeperTrain required for serialization
        /// </summary>
        public SleeperTrain() { }

        /// <summary>
        /// Constructor for SleeperTrain with parameters
        /// </summary>
        public SleeperTrain(String trainId, String departure, String destination, String type, TimeSpan departureTime, DateTime departureDay, bool firstClass, List<Coach> coachList, List<String> intermediate, bool sleeperCabin)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            Intermediate = intermediate;
            SleeperCabin = sleeperCabin;
        }

    }
}
