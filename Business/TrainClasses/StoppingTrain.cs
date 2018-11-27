using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class StoppingTrain : Train
    {
        // Private properties
        private List<String> _intermediate;

        //Public properties
        public List<String> Intermediate
        {
            get { return _intermediate; }
            set
            {
                _intermediate = value;
            }
        }

        // default constructor
        public StoppingTrain() { }

        public StoppingTrain(String trainId,String departure,String destination,String type,TimeSpan departureTime,DateTime departureDay,bool firstClass,List<Coach> coachList, List<String> intermediate)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            Intermediate = intermediate;
            CoachList = coachList;
        }
    }
}
