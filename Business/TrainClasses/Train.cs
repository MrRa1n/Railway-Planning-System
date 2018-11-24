using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.TrainClasses;

namespace Business
{
    public abstract class Train
    {
        public String TrainID { get; private set; }
        public String Departure { get; private set; }
        public String Destination { get; set; }
        public String Type { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime DepartureDay { get; set; }
        public bool FirstClass { get; set; }

        public List<Coach> coachList { get; set; }

        public Train(
            String trainId, 
            String departure, 
            String destination, 
            String type, 
            TimeSpan departureTime, 
            DateTime departureDay, 
            bool firstClass
            )
        {
            TrainID = trainId;
            Departure = departure;
            Destination = destination;
            Type = type;
            DepartureTime = departureTime;
            DepartureDay = departureDay;
            FirstClass = firstClass;

            coachList = new List<Coach>();
            // when expresstrain object is created, create objects for coach
            for (char coachLetter = 'A'; coachLetter <= 'H'; ++coachLetter)
            {
                Coach coach = new Coach(coachLetter);
                coachList.Add(coach);
            }
        }

        public abstract void printTrain();
    }
}
