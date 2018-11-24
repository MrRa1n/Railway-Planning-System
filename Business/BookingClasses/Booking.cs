using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BookingClasses
{
    public class Booking
    {
        public String Name { get; set; }
        public String TrainID { get; set; }
        public String DepartureStation { get; set; }
        public String ArrivalStation { get; set; }
        public bool FirstClass { get; set; }
        public bool SleeperCabin { get; set; }
        public char Coach { get; set; }
        public int Seat { get; set; }

        public Booking(
            String name, 
            String trainId, 
            String departureStation, 
            String arrivalStation, 
            bool firstClass, 
            bool sleeperCabin, 
            char coach, 
            int seat
            )
        {
            Name = name;
            TrainID = trainId;
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            FirstClass = firstClass;
            SleeperCabin = sleeperCabin;
            Coach = coach;
            Seat = seat;
        }
    }
}
