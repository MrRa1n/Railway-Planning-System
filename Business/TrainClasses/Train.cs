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
        
        public DateTime DepartureTime { get; set; }
        public DateTime DepartureDay { get; set; }
        
        public bool FirstClass { get; set; }

        public Train()
        {

        }

        public Train(
            String trainId, 
            String departure, 
            String destination, 
            String type, 
            DateTime departureTime, 
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
    }
}
