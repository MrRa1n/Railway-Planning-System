using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.TrainClasses;

namespace TrainsTest
{
    [TestClass]
    public class StoppingTrainTest
    {
        StoppingTrain exampleTrain = new StoppingTrain();

        [TestMethod]
        public void Intermediate_WhenMaxIntermediatesExceeded_ShouldThrowArgumentOutOfRange()
        {
            List<String> stations = new List<String>() { "Station1", "Station2", "Station3", "Station4", "Station5" };

            try
            {
                exampleTrain.Intermediate = stations;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, StoppingTrain.MaxNumberOfIntermediatesExceeded);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
