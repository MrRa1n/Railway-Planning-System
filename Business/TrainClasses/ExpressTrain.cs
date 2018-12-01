using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class ExpressTrain : Train
    {
        /// <summary>
        /// Default constructor for ExpressTrain needed for serialization
        /// </summary>
        public ExpressTrain() { }

        /// <summary>
        /// Constructor for ExpressTrain with parameters
        /// </summary>
        public ExpressTrain(String trainId,String departure,String destination,String type,TimeSpan departureTime,DateTime departureDay,bool firstClass,List<Coach> coachList)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {

        }
    }
}
