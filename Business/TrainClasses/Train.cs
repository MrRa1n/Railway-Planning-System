using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class Train
    {
        public String TrainID { get; private set; }
        public String Departure { get; private set; }
        public String Destination { get; set; }
        public String Type { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime DepartureDay { get; set; }
        public bool FirstClass { get; set; }

        public Train(
            String trainId, 
            String departure, 
            String destination, 
            String type, 
            TimeSpan departureTime, 
            DateTime departureDay, 
            bool firstClass
            )
        {
            TrainID = trainId;
            Departure = departure;
            Destination = destination;
            Type = type;
            DepartureTime = departureTime;
            DepartureDay = departureDay;
            FirstClass = firstClass;
        }

        public abstract void printTrain();
    }
}
