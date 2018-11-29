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
        private List<int> listOfAvailableSeats;
        private List<int> listOfUnavailableSeats;
        public List<Booking> listOfBookings;
        public char coachId { get; set; }

        public Coach(char c)
        {
            // object gets created and assigned an id
            coachId = c;

            listOfAvailableSeats = new List<int>();
            listOfUnavailableSeats = new List<int>();
            listOfBookings = new List<Booking>();

            for (int i = 1; i <= MAX_CAPACITY; ++i)
            {
                listOfAvailableSeats.Add(i);
            }
        }

        public void addBookingToCoach(Booking booking)
        {
            listOfAvailableSeats.Remove(booking.Seat);
            listOfUnavailableSeats.Add(booking.Seat);
            listOfBookings.Add(booking);
        }

        public List<int> getAvailableSeats()
        {
            return listOfAvailableSeats;
        }

        public void printCoachBookings()
        {
            foreach (Booking b in listOfBookings)
                Console.WriteLine(b.Coach + b.Seat);
        }
    }
}
