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
            List<String> intermediate) : base(trainId, departure, destination, type, departureTime, departureDay, firstClass)
        {
            this.Intermediate = intermediate; 
        }

        public override void printTrain()
        {
            Console.WriteLine("Stopping");
        }
    }
}
