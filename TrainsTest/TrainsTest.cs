using System;
using Business;
using Business.TrainClasses;
using Business.BookingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class TrainsTest
    {

        // 1. test with data type
        // 2. test with station that doesn't exist
        // 3. test with invalid train id
        // 4. test with adding null booking
        // 5. test finding coach where coach is null

        Train exampleTrain = new ExpressTrain();
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainID_WhenTrainIDIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.TrainID = null;
        }

        [TestMethod]
        public void TrainID_WhenTrainIDIsNot4Chars_ShouldThrowArgumentOutOfRange()
        {
            int correctIdLength = 4;
            String tooLongTrainId = "12345";

            try
            {
                exampleTrain.TrainID = tooLongTrainId;
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreNotEqual(tooLongTrainId.Length, correctIdLength);
                return;
            }

            Assert.Fail("Expected exception was not thrown.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Departure_WhenDepartureIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.Departure = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Departure_WhenDepartureIsSameAsDestination_ShouldThrowArgumentException()
        {
            String station = "London (Kings Cross)";

            exampleTrain.Departure = station;
            exampleTrain.Destination = station;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Destination_WhenDestinationIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.Destination = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Destination_WhenDestinationIsSameAsDeparture_ShouldThrowArgumentException()
        {
            String station = "Edinburgh (Waverley)";

            exampleTrain.Destination = station;
            exampleTrain.Departure = station;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Type_WhenTypeIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.Type = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DepartureTime_WhenDepartureTimeIsNull_ShouldThrowArgumentNull()
        {
            // FormatException thrown for TimeSpan.Parse("")
            exampleTrain.DepartureTime = TimeSpan.Parse(null);
        }

        // Only works on sleepertrain
        [TestMethod]
        public void DepartureTime_WhenTimeIsOutOfRange_ShouldThrowArgumentOutOfRange()
        {
            exampleTrain = new SleeperTrain();
            TimeSpan selectedDepartureTime = TimeSpan.Parse("20:59");

            try
            {
                exampleTrain.DepartureTime = selectedDepartureTime;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, Train.SelectedDepartureTimeOutOfRange);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DepartureDay_WhenDepartureDayIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.DepartureDay = DateTime.Parse(null);
        }

        [TestMethod]
        public void DepartureDay_WhenDateIsNotInFuture_ShouldThrowArgumentException()
        {
            DateTime selectedDepartureDay = DateTime.Today;

            try
            {
                exampleTrain.DepartureDay = selectedDepartureDay;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, Train.SelectedDateMustBeInFuture);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CoachList_WhenNoCoachesInList_ShouldThrowArgumentNull()
        {
            System.Collections.Generic.List<Coach> emptyCoachList = new System.Collections.Generic.List<Coach>();

            exampleTrain.CoachList = emptyCoachList;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindCoach_WhenCoachListIsNull_ShouldThrowArgumentNull()
        {
            exampleTrain.CoachList = null;

            exampleTrain.FindCoach('A');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_WhenBookingIsNull_ShouldThrowArgumentNull()
        {
            Booking booking = null;

            exampleTrain.Add(booking);
        }
    }
}
