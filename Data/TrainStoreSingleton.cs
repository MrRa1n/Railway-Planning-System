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
    public class TrainStoreSingleton
    {
        private TrainStoreSingleton() { }

        private static List<Train> listOfTrains;
        private static TrainStoreSingleton instance;

        // Singleton - checks if there isnt existing instance then creates 
        // new instance of TrainStoreSingleton and Train list
        public static TrainStoreSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainStoreSingleton();
                    listOfTrains = new List<Train>();
                }
                return instance;
            }
        }

        // Add Train object to listOfTrains
        public void Add(Train t)
        {
            listOfTrains.Add(t);
        }

        // Pass Booking to our Train object
        public void Add(Booking b)
        {
            findTrain(b.TrainID).Add(b);
        }

        // Get all Trains currently stored
        public List<Train> getTrains()
        {
            return listOfTrains;
        }

        // Return the list of coaches based on the Train ID provided
        public List<Coach> getCoaches(String trainId)
        {
            foreach (Train t in listOfTrains)
            {
                if (t.TrainID.Equals(trainId))
                    return t.CoachList;
            }
            return null;
        }

        // Return single Train from list based on Train ID provided
        public Train findTrain(String trainId)
        {
            foreach (Train t in listOfTrains)
            {
                if (trainId.Equals(t.TrainID))
                    return t;
            }
            return null;
        }

        // Return a list of all possible departure stations for a provided Train
        public List<String> getDepartureStations(Train train)
        {
            List<String> st = getAllStations(train);
            st.Remove(train.Destination);
            return st;
        }

        // Return a list of all possible arrival stations for a provided Train
        public List<String> getArrivalStations(Train train)
        {
            List<String> st = getAllStations(train);
            st.Remove(train.Departure);
            return st;
        }

        // Return all stations for a given train
        public List<String> getAllStations(Train train)
        {
            // Store departure station and departure in list
            List<String> listOfStations = new List<String>()
            {
                train.Departure,
                train.Destination
            };

            // If train is either a stopping or sleeper, insert intermediates and return list
            if (train is StoppingTrain)
            {
                listOfStations.InsertRange(1, ((StoppingTrain)train).Intermediate);
                return listOfStations;
            }

            if (train is SleeperTrain)
            {
                listOfStations.InsertRange(1, ((SleeperTrain)train).Intermediate);
                return listOfStations;
            }

            // If train is express, just return departure and arrival stations
            return listOfStations;
            
        }

        // Produce a comma-separated list of a Train's intermediate stations
        public String intermediateList(Train train)
        {
            if (train is StoppingTrain)
            {
                return String.Join(", ", ((StoppingTrain)train).Intermediate);
            }
            if (train is SleeperTrain)
            {
                return String.Join(", ", ((SleeperTrain)train).Intermediate);
            }
            return String.Empty;
        }

        public double calculateBookingCost(String trainId, String departure, String destination, bool firstClass, bool sleeperCabin)
        {
            if (trainId == null)
                throw new ArgumentException("Please provide a Train ID to calculate fare!");

            // Set price to £50 if Edinburgh-London or London-Edinburgh have been selected, otherwise set price to £25
            double bookingCost = (departure.Contains("Edinburgh") && destination.Contains("London") 
                || destination.Contains("Edinburgh") && departure.Contains("London")) ? 50 : 25;

            // Add £10 if First Class is selected
            if (findTrain(trainId).FirstClass == false && firstClass)
            {
                throw new Exception("This train does not offer First Class");
            }
            else
            {
                if (firstClass)
                {
                    bookingCost += 10;
                }
            }

            // Add £10 if train type is sleeper, then add £20 if sleeper cabin
            if (findTrain(trainId).Type != "Sleeper" && sleeperCabin)
            {
                throw new Exception("This train does not offer Sleeper Cabin");
            }
            else
            {
                bookingCost += 10;
                if (sleeperCabin)
                {
                    bookingCost += 20;
                }
            }
            return bookingCost;
        }

        // Enable TypeNameHandling to determine if Train is ExpressTrain, StoppingTrain or SleeperTrain
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public void serializeTrain(String fileName)
        {
            // Throw exception if the list of trains is empty
            if (listOfTrains.Count == 0)
                throw new Exception("There are no trains to save");

            // Serialize the list of trains to JSON
            String jsonTrainList = JsonConvert.SerializeObject(listOfTrains, jsonSerializerSettings);

            // Create new JSON file to store our train objects
            StreamWriter streamWriter = new StreamWriter(fileName);
            
            // Write the output of our serializer to file
            streamWriter.Write("TRAINS" + jsonTrainList);
            
            streamWriter.Close();
        }

        public void deserializeTrain(String fileName)
        {
            // Create new instance of StreamReader with file name
            StreamReader streamReader = new StreamReader(fileName);

            // Read contents of file
            string output = streamReader.ReadToEnd();

            // Throw exception if file does not contain prefix
            if (!output.StartsWith("TRAINS"))
                throw new Exception("Please select a valid train list");

            // Remove the prefix
            output = output.Remove(0,6);

            //Deserialize the file and store in our list of trains
            listOfTrains = JsonConvert.DeserializeObject<List<Train>>(output, jsonSerializerSettings);

            streamReader.Close();
        }
    }

}
