using System.Collections.Generic;
using Business.BookingClasses;

namespace Business.TrainClasses
{
    public class Coach
    {
        private const int MAX_CAPACITY = 60;
        public List<int> ListOfAvailableSeats { get; private set; }
        public List<Booking> ListOfBookings { get; private set; }
        public char CoachID { get; private set; }

        /// <summary>
        /// Constructor for Coach class that assigns each coachId and creates list
        /// of available seats and list of bookings
        /// </summary>
        /// <param name="coachId">Takes a coachId from TrainFactory</param>
        public Coach(char coachId)
        {
            CoachID = coachId;

            ListOfAvailableSeats = new List<int>();
            ListOfBookings = new List<Booking>();

            // Add values 1-60 to ListOfAvailableSeats
            for (int i = 1; i <= MAX_CAPACITY; ++i)
            {
                ListOfAvailableSeats.Add(i);
            }
        }

        /// <summary>
        /// Removes seat number from list of available seats and adds booking to list
        /// </summary>
        /// <param name="booking">Takes Booking object and adds to ListOfBookings</param>
        public void addBookingToCoach(Booking booking)
        {
            ListOfAvailableSeats.Remove(booking.Seat);
            ListOfBookings.Add(booking);
        }
    }
}
