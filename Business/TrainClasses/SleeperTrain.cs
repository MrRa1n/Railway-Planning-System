using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class SleeperTrain : Train
    {
        public const String MaxNumberOfIntermediatesExceeded = "";

        private List<String> _intermediate;
        private bool _sleeperCabin;

        /// <summary>
        /// Intermediate property to store a list of selected stations
        /// </summary>
        public List<String> Intermediate
        {
            get { return _intermediate; }
            set
            {
                if (value.Count > 4)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _intermediate = value;
            }
        }

        /// <summary>
        /// Sleeper Cabin property to store whether train offers sleeper cabin
        /// </summary>
        public bool SleeperCabin
        {
            get { return _sleeperCabin; }
            set
            {
                _sleeperCabin = value;
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
