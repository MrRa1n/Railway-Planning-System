using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.TrainClasses;

namespace TrainsTest
{
    [TestClass]
    public class SleeperTrainTest
    {
        SleeperTrain exampleTrain = new SleeperTrain();

        /// <summary>
        /// Tests if there are more than the standard number of intermediates and throws and exception if true
        /// </summary>
        [TestMethod]
        public void Intermediate_WhenMaxIntermediatesExceeded_ShouldThrowArgumentOutOfRange()
        {
            List<String> stations = new List<String>() { "Station1","Station2","Station3","Station4","Station5" };
            try
            {
                exampleTrain.Intermediate = stations;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, SleeperTrain.MaxNumberOfIntermediatesExceeded);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
