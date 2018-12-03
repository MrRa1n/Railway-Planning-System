using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Business;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class TrainStoreTest
    {
        TrainStoreSingleton exampleTrainStore = TrainStoreSingleton.Instance;

        [TestMethod]
        public void AddTrain_WhenTrainIsNull_ShouldThrowArgumentNull()
        {

        }

        [TestMethod]
        public void AddBooking_WhenBookingIsNull_ShouldThrowArgumentNull()
        {

        }

        [TestMethod]
        public void AddBooking_WhenTrainDoesNotExist_ShouldThrowArgumentNull()
        {

        }

        [TestMethod]
        public void GetTrains_WhenListIsEmpty_ShouldReturnEmptyList()
        {
            List<Train> listOfTrains = exampleTrainStore.getTrains();
            int trainCount = 0;


            Assert.AreEqual(trainCount, listOfTrains.Count);
        }

        [TestMethod]
        public void GetCoaches_WhenInvalidTrainID_ShouldThrowArgumentException()
        {
            
        }

        [TestMethod]
        public void GetCoaches_WhenNullTrainID_ShouldThrowArgumentNull()
        {

        }

        [TestMethod]
        public void FindTrain_WhenInvalidTrainID_ShouldThrowArgumentException()
        {

        }

        [TestMethod]
        public void FindTrain_WhenNullTrainID_ShouldThrowArgumentNull()
        {

        }

        [TestMethod]
        public void GetDepartureStations_WhenDeparturesIsEmpty_ShouldThrowArgumentException()
        {

        }

        [TestMethod]
        public void GetDepartureStations_WhenTrainIsNull_ShouldThrowArgumentNull()
        {

        }
    }
}
