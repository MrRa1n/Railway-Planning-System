using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    class ExpressTrain : Train
    {
        

        public ExpressTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            TimeSpan departureTime,
            DateTime departureDay,
            bool firstClass) : base(trainId, departure, destination, type, departureTime, departureDay, firstClass)
        {
            
        }



        public override void printTrain()
        {
            Console.WriteLine("Express Train Created");
        }
    }
}
