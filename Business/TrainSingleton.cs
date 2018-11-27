using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BookingClasses;
using Business.TrainClasses;

namespace Business
{
    public class TrainSingleton
    {
        private static List<Train> listOfTrains = new List<Train>();
        
        private TrainSingleton() {}

        private static TrainSingleton instance;

        public static TrainSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainSingleton();
                }
                return instance;
            }
        }

        public void Add(Train t)
        {
            listOfTrains.Add(t);
            
        }

        public void Add(Booking b)
        {
            FindTrain(b.TrainID).Add(b);
        }

        public List<Train> getTrains()
        {
            return listOfTrains;
        }

        public List<Coach> getCoaches()
        {
            foreach (Train t in getTrains())
            {
                return t.CoachList;
            }
            return null;
        }

        public Train FindTrain(String trainId)
        {
            foreach (Train t in listOfTrains)
            {
                if (trainId.Equals(t.TrainID))
                {
                    return t;
                }
            }
            return null;
        }

        public List<String> getDepartureStations(Train t)
        {
            List<String> st = getAllStations(t);
            st.Remove(t.Destination);
            return st;
        }

        public List<String> getArrivalStations(Train t)
        {
            List<String> st = getAllStations(t);
            st.Remove(t.Departure);
            return st;
        }

        public List<String> getAllStations(Train t)
        {
            List<String> listOfStations = new List<String>();
            if (t is StoppingTrain)
            {
                listOfStations.Add(t.Departure);
                listOfStations.AddRange(((StoppingTrain)t).Intermediate);
                listOfStations.Add(t.Destination);
                return listOfStations;
            }   
            else if (t is SleeperTrain)
            {
                listOfStations.Add(t.Departure);
                listOfStations.AddRange(((SleeperTrain)t).Intermediate);
                listOfStations.Add(t.Destination);
                return listOfStations;
            }
            else
            {
                listOfStations.Add(t.Departure);
                listOfStations.Add(t.Destination);
                return listOfStations;
            }
        }

        public List<String> getIntermediates(Train t)
        {
            if (t is StoppingTrain)
                return ((StoppingTrain)t).Intermediate;
            else if (t is SleeperTrain)
                return ((SleeperTrain)t).Intermediate;
            else
                return null;
        }
    }
}
