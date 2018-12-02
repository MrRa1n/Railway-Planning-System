using System;
using System.Collections.Generic;

namespace Business.TrainClasses
{
    public class TrainFactorySingleton
    {
        private TrainFactorySingleton() { }

        private static TrainFactorySingleton instance;

        /// <summary>
        /// Check if instance of class exists and return that instance, otherwise create new one
        /// </summary>
        public static TrainFactorySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainFactorySingleton();
                }
                return instance;
            }
        }

        /// <summary>
        /// Creates a new train ID depending on the departures station
        /// </summary>
        /// <param name="departure">Take in departure station as String</param>
        /// <returns>Returns random train ID</returns>
        private String createTrainID(String departure)
        {
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
            switch (type)
            {
                case "Express":
                    return new ExpressTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches()); 
                case "Stopping":
                    return new StoppingTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(), intermediate);
                case "Sleeper":
                    return new SleeperTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(), intermediate, sleeperCabin);
                default:
                    return null;
            }
        }
    }
}
