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
