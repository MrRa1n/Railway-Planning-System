using System;
using System.Collections.Generic;
using Data;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.BookingClasses;
using Business.TrainClasses;

namespace TrainsTest
{
    [TestClass]
    public class TrainStoreTest
    {
        TrainStoreSingleton exampleTrainStore = TrainStoreSingleton.Instance;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTrain_WhenTrainIsNull_ShouldThrowArgumentNull()
        {
            Train train = null;
            exampleTrainStore.Add(train);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBooking_WhenBookingIsNull_ShouldThrowArgumentNull()
        {
            Booking booking = null;
            exampleTrainStore.Add(booking);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBooking_WhenTrainDoesNotExist_ShouldThrowArgumentNull()
        {
            Booking booking = new Booking();
            
            booking.TrainID = "RGKREGREJK$£%$£%";

            exampleTrainStore.Add(booking);
        }

        [TestMethod]
        public void GetTrains_WhenListIsEmpty_ShouldReturnEmptyList()
        {
            List<Train> listOfTrains = exampleTrainStore.getTrains();
            int trainCount = 0;

            Assert.AreEqual(trainCount, listOfTrains.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCoaches_WhenInvalidTrainID_ShouldThrowArgumentNull()
        {
            String trainId = "IUH7YER7";
            List<Coach> coaches = exampleTrainStore.getCoaches(trainId);

            Assert.IsNull(coaches);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindTrain_WhenInvalidTrainID_ShouldThrowArgumentNull()
        {
            String trainId = "rtgh54t54t45ty4r5thtgrthg54e";
            Train train = exampleTrainStore.findTrain(trainId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDepartureStations_WhenDeparturesIsEmpty_ShouldThrowArgumentNull()
        {
            StoppingTrain train = new StoppingTrain();
            train.Departure = "";
            List<String> departures = exampleTrainStore.getDepartureStations(train);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetArrivalStations_WhenDestinationIsNull_ShouldThrowArgumentNull()
        {
            StoppingTrain train = new StoppingTrain();
            train.Destination = "";
            List<String> arrivals = exampleTrainStore.getArrivalStations(train);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAllStations_WhenTrainIsNull_ShouldThrowArgumentNull()
        {
            Train train = null;
            List<String> stations = exampleTrainStore.getAllStations(train);
        }

        [TestMethod]
        public void IntermediateList_WhenTrainIsNull_ShouldReturnEmptyString()
        {
            Train train = null;
            StoppingTrain stoppingTrain = null;
            ExpressTrain expressTrain = null;
            SleeperTrain sleeperTrain = null;


            String genericTrainList = exampleTrainStore.intermediateList(train);
            String stoppingTrainList = exampleTrainStore.intermediateList(stoppingTrain);
            String expressTrainList = exampleTrainStore.intermediateList(expressTrain);
            String sleeperTrainList = exampleTrainStore.intermediateList(sleeperTrain);

            Assert.AreEqual(String.Empty, genericTrainList);
            Assert.AreEqual(String.Empty, stoppingTrainList);
            Assert.AreEqual(String.Empty, expressTrainList);
            Assert.AreEqual(String.Empty, sleeperTrainList);
        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateBookingCost_WhenInvalidTrainID_ShouldThrowArgumentNull()
        {
            String trainId = "GRRELGMREKLOKSEWPFLE";
            String departure = "Station 1";
            String destination = "Station 2";
            bool firstClass = false;
            bool sleeperCabin = false;

            exampleTrainStore.calculateBookingCost(trainId, departure, destination, firstClass, sleeperCabin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateBookingCost_SleeperCabinOnExpressTrain_ShouldThrowArgumentException()
        {
            ExpressTrain expressTrain = new ExpressTrain();
            expressTrain.TrainID = "1234";
            expressTrain.Departure = "Edinburgh";
            expressTrain.Destination = "London";
            expressTrain.FirstClass = true;
            bool sleeperCabin = true;

            exampleTrainStore.Add(expressTrain);

            exampleTrainStore.calculateBookingCost(expressTrain.TrainID, expressTrain.Departure, expressTrain.Destination, expressTrain.FirstClass, sleeperCabin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckStationOrder_IfStationsNotInOrder_ShouldThrowArgumentException()
        {
            SleeperTrain sleeperTrain = new SleeperTrain();
            sleeperTrain.TrainID = "1234";
            sleeperTrain.Departure = "Edinburgh";
            sleeperTrain.Destination = "London";
            sleeperTrain.Intermediate = new List<String>() { "Station 1", "Station 2", "Station 3" };

            exampleTrainStore.Add(sleeperTrain);

            exampleTrainStore.checkStationOrder("1234", "Station 3", "Station 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckStationOrder_IfStationsAreSame_ShouldThrowArgumentException()
        {
            SleeperTrain sleeperTrain = new SleeperTrain();
            sleeperTrain.TrainID = "1234";
            sleeperTrain.Departure = "Edinburgh";
            sleeperTrain.Destination = "London";
            sleeperTrain.Intermediate = new List<String>() { "Station 1", "Station 2", "Station 3" };

            exampleTrainStore.Add(sleeperTrain);

            exampleTrainStore.checkStationOrder("1234", "London", "London");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SerializeTrain_IfFileNameIsNull_ShouldThrowArgumentNull()
        {
            exampleTrainStore.serializeTrain(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SerializeTrain_IfTrainListIsEmpty_ShouldThrowException()
        {
            exampleTrainStore.serializeTrain("filename");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeserializeTrain_IfFileNameIsNull_ShouldThrowArgumentNull()
        {
            exampleTrainStore.deserializeTrain(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void DeserializeTrain_IfFileNameNotFound_ShouldThrowArgumentNull()
        {
            exampleTrainStore.deserializeTrain("Test String");
        }
    }
}
