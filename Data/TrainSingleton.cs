using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public double calculateBookingCost(String trainId, String departure, String destination, bool firstClass, bool sleeperCabin)
        {
            double bookingCost = 0.00;

            // Check what departure and arrival stations have been selected
            if (departure.Contains("Edinburgh") && !destination.Contains("London"))
            {
                bookingCost = 25;
            } 
            else if (!departure.Contains("Edinburgh") && destination.Contains("London"))
            {
                bookingCost = 25;
            }
            else
            {
                bookingCost = 50;
            }
            
            // Add £10 if First Class is selected
            if (firstClass)
            {
                bookingCost += 10;
            }

            // Add £10 if train type is sleeper, then add £20 if sleeper cabin
            if (FindTrain(trainId).Type == "Sleeper")
            {
                bookingCost += 10;
                if (sleeperCabin)
                {
                    bookingCost += 20;
                }
            }

            return bookingCost;
        }

        public void serializeTrain()
        {
            string json = "";
            json = JsonConvert.SerializeObject(listOfTrains);
            
         

            StreamWriter sw = new StreamWriter(@"trains.txt");
            
            sw.Write(json);

            sw.Close();

        }

        /*
         * issue when train is loaded into list - shows there is 1 booking but all seats are still available
         * 
         */
        public void deserializeTrain()
        {
            StreamReader sr = new StreamReader(@"trains.txt");
            string output = sr.ReadToEnd();
            listOfTrains = JsonConvert.DeserializeObject<List<Train>>(output);
            
            Console.WriteLine(listOfTrains);
        }
    }

}
