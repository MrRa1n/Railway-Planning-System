using System;
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

        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DepartureStation_WhenDepartureIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.DepartureStation = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepartureStation_WhenDepartureIsSameAsArrival_ShouldThrowArgumentException()
        {
            String station = "Edinburgh (Waverley)";

            exampleBooking.DepartureStation = station;
            exampleBooking.ArrivalStation = station;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrivalStation_WhenArrivalStationIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.ArrivalStation = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrivalStation_WhenArrivalIsSameAsDeparture_ShouldThrowArgumentException()
        {
            String station = "Edinburgh (Waverley)";

            exampleBooking.DepartureStation = station;
            exampleBooking.ArrivalStation = station;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Coach_WhenCoachIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Coach = ' ';
        }

    }
}
