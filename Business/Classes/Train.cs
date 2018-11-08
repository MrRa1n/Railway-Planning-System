using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Train
    {
        public String TrainID { get; set; }
        public String[] Departure { get; set; }
        public String[] Destination { get; set; }
        public enum Type { Express, Stopping, Sleeper }
        public String[] Intermediate { get; set; } // child classes
        public DateTime DepartureTime { get; set; }
        public DateTime DepartureDay { get; set; }
        public bool SleeperCabin { get; set; }
        public bool FirstClass { get; set; }
    }
}
