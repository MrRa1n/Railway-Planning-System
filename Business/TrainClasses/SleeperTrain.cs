using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrainClasses
{
    public class SleeperTrain : Train
    {
        // Private properties
        private List<String> _intermediate;
        private bool _sleeperCabin;

        //Public properties
        public List<String> Intermediate
        {
            get { return _intermediate; }
            set
            {
                _intermediate = value;
            }
        }

        public bool SleeperCabin
        {
            get { return _sleeperCabin; }
            set
            {
                _sleeperCabin = value;
            }
        }
        
        // default constructor
        public SleeperTrain() { }

        public SleeperTrain(String trainId, String departure, String destination, String type, TimeSpan departureTime, DateTime departureDay, bool firstClass, List<Coach> coachList, List<String> intermediate, bool sleeperCabin)
            : base(trainId, departure, destination, type, departureTime, departureDay, firstClass, coachList)
        {
            Intermediate = intermediate;
            SleeperCabin = sleeperCabin;
            CoachList = coachList;
        }

    }
}
