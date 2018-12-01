using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class StoppingTrain : Train
    {
        private List<String> _intermediate;

        /// <summary>
        /// Intermediate property to store list of stations
        /// - can be null
        /// </summary>
        public List<String> Intermediate
        {
            get { return _intermediate; }
            set
            {
                _intermediate = value;
            }
        }

        /// <summary>
        /// Default StoppingTrain constructor required for serialization
        /// </summary>
        public StoppingTrain() { }

        /// <summary>
        /// Constructor for StoppingTrain with parameters
        /// </summary>
        public StoppingTrain(String trainId,String departure,String destination,String type,TimeSpan departureTime,DateTime departureDay,bool firstClass,List<Coach> coachList, List<String> intermediate)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            Intermediate = intermediate;
        }
    }
}
