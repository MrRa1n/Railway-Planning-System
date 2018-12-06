using System;
using Business.BookingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class BookingTest
    {
        Booking exampleBooking = new Booking();

        /// <summary>
        /// Tests Name property to see if exception is thrown when name is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WhenNameIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Name = null;
        }

        /// <summary>
        /// Tests TrainID property to see if exception is thrown when train ID is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainID_WhenTrainIDIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.TrainID = null;
        }

        /// <summary>
        /// Tests DepartureStation property to see if exception is thrown when departure station is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DepartureStation_WhenDepartureIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.DepartureStation = null;
        }

        /// <summary>
        /// Tests DepartureStation property to see if exception is thrown when departure is same as arrival
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepartureStation_WhenDepartureIsSameAsArrival_ShouldThrowArgumentException()
        {
            String station = "Edinburgh (Waverley)";

            exampleBooking.DepartureStation = station;
            exampleBooking.ArrivalStation = station;
        }

        /// <summary>
        /// Tests ArrivalStation property to see if exception is thrown when arrival station is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrivalStation_WhenArrivalStationIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.ArrivalStation = null;
        }

        /// <summary>
        /// Tests ArrivalStation property to see if exception is thrown when arrival is same as departure
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrivalStation_WhenArrivalIsSameAsDeparture_ShouldThrowArgumentException()
        {
            String station = "Edinburgh (Waverley)";

            exampleBooking.DepartureStation = station;
            exampleBooking.ArrivalStation = station;
        }

        /// <summary>
        /// Tests Coach property to see if exception is thrown when coach is empty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Coach_WhenCoachIsNull_ShouldThrowArgumentNull()
        {
            exampleBooking.Coach = ' ';
        }

    }
}
