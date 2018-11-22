using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BookingClasses;

namespace Business.TrainClasses
{
    class Coach
    {
        private int numberOfSeats = 60;
        public char coachLetter { get; set; }

        private List<Booking> _listOfBookings;

        public Coach(List<Booking> bookings)
        {
            _listOfBookings = bookings;
        }

        public void IsItTaken()
        {

        }
    }
}
