using System;
using System.Collections.Generic;
using Business.BookingClasses;

namespace Business.TrainClasses
{
    public class Coach
    {
        public const String CoachLetterIsNotValid = "Coaches can only be created with the ID A to H";
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
            if (coachId < 'A' || coachId > 'H')
            {
                throw new ArgumentOutOfRangeException("Invalid Coach ID", coachId, CoachLetterIsNotValid);
            }

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
            if (booking == null)
            {
                throw new ArgumentNullException("No coaches available to add Booking");
            }
            if (ListOfAvailableSeats.Count == 0)
            {
                throw new ArgumentException("There are no more seats available on this coach");
            }

            ListOfAvailableSeats.Remove(booking.Seat);
            ListOfBookings.Add(booking);
        }
    }
}
