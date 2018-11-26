using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class ExpressTrain : Train
    {

        public ExpressTrain(
            String trainId,
            String departure,
            String destination,
            String type,
            TimeSpan departureTime,
            DateTime departureDay,
            bool firstClass,
            List<Coach> coachList
            ) : base(
                trainId, 
                departure, 
                destination, 
                type, 
                departureTime, 
                departureDay, 
                firstClass, 
                coachList)
        {
            this.CoachList = coachList;
        }



        public override void printTrain()
        {
            Console.WriteLine("Express Train Created");
        }
    }
}
