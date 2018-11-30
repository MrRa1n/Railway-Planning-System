using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BookingClasses;

namespace Business.TrainClasses
{
    public class Coach
    {
        private const int MAX_CAPACITY = 60;
        public List<int> ListOfAvailableSeats { get; set; }
        public List<Booking> ListOfBookings { get; set; }
        public char coachId { get; set; }

        public Coach(char c)
        {
            // object gets created and assigned an id
            coachId = c;

            ListOfAvailableSeats = new List<int>();
            ListOfBookings = new List<Booking>();

            for (int i = 1; i <= MAX_CAPACITY; ++i)
            {
                ListOfAvailableSeats.Add(i);
            }
        }

        public void addBookingToCoach(Booking booking)
        {
            ListOfAvailableSeats.Remove(booking.Seat);
            ListOfBookings.Add(booking);
        }
    }
}
