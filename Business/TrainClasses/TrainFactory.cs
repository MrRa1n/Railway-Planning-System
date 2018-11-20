using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class TrainFactory
    {
        private String trainId = "";
        private Random rnd = new Random();

        public void createTrainID(String departure)
        {
            if (departure.Contains("Edinburgh"))
                trainId = "1E";
            else
                trainId = "1S";

            trainId += rnd.Next(10,99).ToString();
        }

        public Train CreateTrain(
            String departure,
            String destination,
            String type,
            TimeSpan departureTime,
            DateTime departureDay,
            bool firstClass,
            List<String> intermediate,
            bool sleeperCabin)
        {
            createTrainID(departure);
            switch (type)
            {
                case "Express":
                    return new ExpressTrain(trainId,departure,destination,type,departureTime,departureDay,firstClass); 
                case "Stopping":
                    return new StoppingTrain(trainId,departure,destination,type,departureTime,departureDay,firstClass,intermediate);
                case "Sleeper":
                    return new SleeperTrain(trainId,departure,destination,type,departureTime,departureDay,firstClass,intermediate,sleeperCabin);
                default:
                    return null;
            }
        }
    }
}
