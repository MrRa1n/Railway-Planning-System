using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class TrainFactory
    {
        public Train CreateTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            DateTime departureTime,
            DateTime departureDay,
            bool firstClass,
            List<String> intermediate,
            bool sleeperCabin)
        {
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
