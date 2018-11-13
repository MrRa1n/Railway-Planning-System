using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    class SleeperTrain : Train
    {
        public List<String> Intermediate { get; set; }
        public bool SleeperCabin { get; set; }

        public SleeperTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            DateTime departureTime,
            DateTime departureDay,
            bool firstClass,
            List<String> intermediate,
            bool sleeperCabin) : base(trainId, departure, destination, type, departureTime, departureDay, firstClass)
        {
            this.Intermediate = intermediate;
            this.SleeperCabin = sleeperCabin;
        }

        public override void printTrain()
        {
            Console.WriteLine("Sleeper");
        }
    }
}
