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
        private const int MAX_CAPACITY = 60;
        private List<int> listOfAvailableSeats;
        private List<Booking> _listOfBookings;
        private char coachId { get; set; }

        // make this a singleton?


        public Coach(char c)
        {
            // object gets created and assigned an id
            coachId = c;

            listOfAvailableSeats = new List<int>();

            for (int i = 1; i <= MAX_CAPACITY; ++i)
            {
                listOfAvailableSeats.Add(i);
            }


        }

        public void addBookingsToCoach(List<Booking> bookings)
        {
            _listOfBookings = bookings;

            foreach (Booking b in _listOfBookings)
            {
                listOfAvailableSeats.Remove(b.Seat);
            }
        }

        public List<int> getAvailableSeats()
        {
            return listOfAvailableSeats;
        }

        public void printCoachBookings()
        {
            foreach (Booking b in _listOfBookings)
                Console.WriteLine(b.Coach + b.Seat);
        }
    }
}
