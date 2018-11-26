using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class SleeperTrain : Train
    {
        public List<String> Intermediate { get; set; }
        public bool SleeperCabin { get; set; }
        
        public SleeperTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            TimeSpan departureTime,
            DateTime departureDay,
            bool firstClass,
            List<String> intermediate,
            bool sleeperCabin,
            List<Coach> coachList) : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            this.Intermediate = intermediate;
            this.SleeperCabin = sleeperCabin;
            this.CoachList = coachList;
        }

        public override void printTrain()
        {
            Console.WriteLine("Sleeper");
        }
    }
}
