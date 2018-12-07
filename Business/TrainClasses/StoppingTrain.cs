/**
 *  Author:             Toby Cook
 *  Description:        This class is a child class to Train and is a more specified implementation
 *                      of the Train class.
 *  Last modified:      07/12/18
 *  Design patterns:    This class is a part of the Factory design pattern.
 */

using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class StoppingTrain : Train
    {
        public const String MaxNumberOfIntermediatesExceeded = "There cannot be more than 4 intermediate stations";

        private List<String> intermediate;

        /// <summary>
        /// Intermediate property to store list of stations
        /// - can be null
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
