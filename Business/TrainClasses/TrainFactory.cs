using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class TrainFactory
    {
        private Random rnd = new Random();
        private List<String> trainIds = new List<String>();
        private List<Coach> coachList;

        private String createTrainID(String departure)
        {
            // set TrainID prefix based on departure station
            String trainId = (departure.Contains("Edinburgh")) ? "1E" : "1S";
            // append random number to prefix
            trainId += rnd.Next(99).ToString("00");
            // if TrainID exists in list call function again
            foreach (String id in trainIds.ToList())
            {
                if (id.Equals(trainId)) return createTrainID(departure);
            }
            // add TrainID to list and return it
            trainIds.Add(trainId);
            return trainId;
        }

        private List<Coach> buildCoaches(ref List<Coach> coachList)
        {
            coachList = new List<Coach>();
            // when expresstrain object is created, create objects for coach
            for (char coachLetter = 'A'; coachLetter <= 'H'; ++coachLetter)
            {
                Coach coach = new Coach(coachLetter);
                coachList.Add(coach);
            }
            return coachList;
        }

        public Train BuildTrain(String departure, String destination, String type, TimeSpan departureTime, DateTime departureDay, bool firstClass, List<String> intermediate, bool sleeperCabin)
        {
            
            switch (type)
            {
                case "Express":
                    return new ExpressTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(ref coachList)); 
                case "Stopping":
                    return new StoppingTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(ref coachList), intermediate);
                case "Sleeper":
                    return new SleeperTrain(createTrainID(departure), departure, destination, type, departureTime, departureDay, firstClass, buildCoaches(ref coachList), intermediate, sleeperCabin);
                default:
                    return null;
            }
        }
    }
}
