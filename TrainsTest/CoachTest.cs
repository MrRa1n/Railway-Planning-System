using System;
using System.Collections.Generic;
using System.Text;
using Business.BookingClasses;
using Business.TrainClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class CoachTest
    {
        Coach exampleCoach;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBookingToCoach_WhenBookingIsNull_ShouldThrowArgumentNull()
        {
            Booking booking = null;
            exampleCoach = new Coach('A');

            exampleCoach.addBookingToCoach(booking);
        }

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
