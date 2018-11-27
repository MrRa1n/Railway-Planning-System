using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class ExpressTrain : Train
    {
        // default constructor
        public ExpressTrain() { }

        public ExpressTrain(String trainId,String departure,String destination,String type,TimeSpan departureTime,DateTime departureDay,bool firstClass,List<Coach> coachList)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            CoachList = coachList;
        }
    }
}
