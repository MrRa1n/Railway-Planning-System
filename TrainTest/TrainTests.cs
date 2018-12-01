using System;
using Business;
using Business.TrainClasses;
using Business.BookingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainTest
{
    [TestClass]
    public class TrainTests
    {

        // 1. test with data type
        // 2. test with station that doesn't exist
        // 3. test with invalid train id
        // 4. test with adding null booking
        // 5. test finding coach where coach is null

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfStationsAreSame()
        {
            // Arrange
            String departureStation = "Edinburgh (Waverley)";
            String arrivalStation = "Edinburgh (Waverley)";

            // Act
            Train train = new ExpressTrain()
            {
                TrainID = "1234",
                Departure = departureStation,
                Destination = arrivalStation,
                Type = "Express",
                DepartureTime = TimeSpan.MaxValue,
                DepartureDay = DateTime.MaxValue,
                FirstClass = false,
                CoachList = null
            };
            
            // Assert handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindCoach_WhenCoachListIsNull_ShouldThrowArgumentNull()
        {
            Train train = new ExpressTrain()
            {
                TrainID = "1234",
                Departure = "station1",
                Destination = "station2",
                Type = "Express",
                DepartureTime = TimeSpan.MaxValue,
                DepartureDay = DateTime.MaxValue,
                FirstClass = false,
                CoachList = null
            };

            train.FindCoach('A');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_WhenBookingIsNull_ShouldThrowArgumentNull()
        {
            Train train = new ExpressTrain()
            {
                TrainID = "1234",
                Departure = "station1",
                Destination = "station2",
                Type = "Express",
                DepartureTime = TimeSpan.MaxValue,
                DepartureDay = DateTime.MaxValue,
                FirstClass = false,
                CoachList = new System.Collections.Generic.List<Coach>()
            };

            Booking booking = null;

            train.Add(booking);
        }
    }
}
