using System;
using Business.BookingClasses;
using Business.TrainClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class CoachTest
    {
        Coach exampleCoach;

        /// <summary>
        /// Tests to see if the coach throws exception when ID is not between A and H
        /// </summary>
        [TestMethod]
        public void Coach_CreateCoachWithInvalidID_ShouldThrowArgumentOutOfRange()
        {
            char invalidCoachId = '5';
            try
            {
                exampleCoach = new Coach(invalidCoachId);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, Coach.CoachLetterIsNotValid);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /// <summary>
        /// Tests if a booking can be added to a coach if it is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBookingToCoach_WhenBookingIsNull_ShouldThrowArgumentNull()
        {
            Booking booking = null;
            exampleCoach = new Coach('A');

            exampleCoach.addBookingToCoach(booking);
        }

        /// <summary>
        /// Tests if a booking can be added to a coach when the maximum number of seats have been taken
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBookingToCoach_WhenNoAvailableSeats_ShowThrowArgumentException()
        {
            Booking booking = new Booking();
            exampleCoach = new Coach('A');

            for (int i = 1; i <= 61; ++i)
            {
                booking.Seat = i;
                exampleCoach.addBookingToCoach(booking);
            }
        }
    }
}
