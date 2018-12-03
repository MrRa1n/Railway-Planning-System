using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Business.TrainClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainsTest
{
    [TestClass]
    public class TrainFactoryTest
    {
        TrainFactory exampleTrainFactory = new TrainFactory();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTrainID_WhenDepartureIsNull_ShouldThrowArgumentNull()
        {
            Train mytrain = exampleTrainFactory.BuildTrain(
                departure: null,
                destination: "London",
                type: "Express",
                departureTime: TimeSpan.MaxValue,
                departureDay: DateTime.MaxValue,
                firstClass: false,
                intermediate: null,
                sleeperCabin: false);
        }
    }
}
