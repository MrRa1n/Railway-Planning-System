using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BookingClasses
{
    class Booking
    {
        public String Name { get; set; }
        public String TrainID { get; set; }
        public String DepartureStation { get; set; }
        public String ArrivalStation { get; set; }
        public bool FirstClass { get; set; }
        public bool SleeperCabin { get; set; }
        public char Coach { get; set; }
        public int Seat { get; set; }
    }
}
