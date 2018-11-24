using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    class StoppingTrain : Train
    {
        public List<String> Intermediate { get; set; }

        public StoppingTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            TimeSpan departureTime,
            DateTime departureDay,
            bool firstClass,
            List<String> intermediate,
            List<Coach> coachList) : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            this.Intermediate = intermediate;
            this.CoachList = coachList;
        }

        private String listIntermediates()
        {
            return String.Join(", ", Intermediate);
        }

        public override void printTrain()
        {
            Console.WriteLine("--- Stopping Train ---");
            Console.WriteLine(
                TrainID + "\n" +
                Departure + "\n" +
                Destination + "\n" +
                Type + "\n" +
                DepartureTime + "\n" +
                DepartureDay + "\n" +
                FirstClass + "\n" +
                listIntermediates()
                );
        }
    }
}
