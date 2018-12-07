/**
 *  Author:             Toby Cook
 *  Description:        This class makes use of a Facotry pattern to generate Train IDs and build trains based off 
 *                      the context provided by the user.
 *  Last modified:      07/12/18
 *  Design patterns:    This class uses Factory pattern to build coaches and trains
 */

using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class TrainFactory
    {
        public TrainFactory() { }

        /// <summary>
        /// Creates a new train ID depending on the departures station
        /// </summary>
        /// <param name="departure">Take in departure station as String</param>
        /// <returns>Returns random train ID</returns>
        private String createTrainID(String departure)
        {
            if (String.IsNullOrWhiteSpace(departure))
                throw new ArgumentNullException(nameof(departure), "Please provide a departure station");

            Random random = new Random();
            List<String> trainIds = new List<String>();
            // set TrainID prefix based on departure station
            String trainId = (departure.Contains("Edinburgh")) ? "1E" : "1S";
            // append random number to prefix
            trainId += random.Next(99).ToString("00");
            // if TrainID exists in list call function again
            foreach (String id in trainIds)
            {
                if (id.Equals(trainId)) return createTrainID(departure);
            }
            // add TrainID to list and return it
            trainIds.Add(trainId);
            return trainId;
        }

        /// <summary>
        /// Creates a new List of Coaches and loops from A-H,
        /// creating a new coach with each letter as its ID
        /// </summary>
        /// <returns>Returns Coach List</returns>
        private List<Coach> buildCoaches()
        {
            List<Coach> coachList = new List<Coach>();
            // Loop from A-H and create new coaches with letter as its ID
            for (char coachLetter = 'A'; coachLetter <= 'H'; ++coachLetter)
            {
                Coach coach = new Coach(coachLetter);
                coachList.Add(coach);
            }
            return coachList;
        }

        /// <summary>
        /// Builds a specific Train object based on the Type value passed as an argument
        /// </summary>
        /// <returns>Returns new ExpressTrain, StoppingTrain or SleeperTrain instance</returns>
        public Train BuildTrain(String departure, String destination, String type, TimeSpan departureTime, DateTime departureDay, bool firstClass, List<String> intermediate, bool sleeperCabin)
        {
            String trainId = createTrainID(departure);
            switch (type)
            {
                case "Express":
                    return new ExpressTrain(trainId, departure, destination, type, departureTime, departureDay, firstClass, buildCoaches()); 
                case "Stopping":
                    return new StoppingTrain(trainId, departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(), intermediate);
                case "Sleeper":
                    return new SleeperTrain(trainId, departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(), intermediate, sleeperCabin);
                default:
                    return null;
            }
        }
    }
}
