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

        public String createTrainID(String departure)
        {
            String trainId;

            if (departure.Contains("Edinburgh"))
                trainId = "1E";
            else
                trainId = "1S";

            
            trainId += rnd.Next(99).ToString("00");


            foreach (String id in trainIds.ToList())
            {
                if (id.Equals(trainId))
                {
                    return createTrainID(departure);
                }
            }

            trainIds.Add(trainId);

            return trainId;
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
            String trainId = createTrainID(departure);
            
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
