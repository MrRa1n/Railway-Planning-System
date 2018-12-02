using System;
using System.Collections.Generic;
using System.Text;
using Business.BookingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class BookingTest
    {
        Booking exampleBooking = new Booking();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WhenNameIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Name = null;
        }

        // Check if train exists also...
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainID_WhenTrainIDIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.TrainID = null;
        }

        // comment
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DepartureStation_WhenDepartureIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.DepartureStation = null;
        }

        [TestMethod]
        public void DepartureStation_WhenDepartureIsSameAsArrival_ShouldThrowArgumentException()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrivalStation_WhenArrivalStationIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.ArrivalStation = null;
        }

        [TestMethod]
        public void ArrivalStation_WhenArrivalIsSameAsDeparture_ShouldThrowArgumentException()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Coach_WhenCoachIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Coach = ' ';
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Seat_WhenSeatIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Seat = int.Parse(" ");
        }

    }
}
