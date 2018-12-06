using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Business.BookingClasses;
using Business.TrainClasses;
using Business;

namespace Data
{
    public class TrainStoreSingleton
    {
        private TrainStoreSingleton() { }
        private static List<Train> listOfTrains;
        private static TrainStoreSingleton instance;

        /// <summary>
        /// Singleton - checks if there isnt existing instance then creates new instance of TrainStoreSingleton and Train list
        /// </summary>
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

        /// <summary>
        /// Add Train object to listOfTrains
        /// </summary>
        /// <param name="train">Takes Train object and adds to list</param>
        public void Add(Train train)
        {
            if (train == null)
                throw new ArgumentNullException(nameof(train), "The train provided is null");
            listOfTrains.Add(train);
        }

        /// <summary>
        /// Find the Train using TrainID from Booking and add the booking to the Train
        /// </summary>
        /// <param name="booking">Takes Booking object as parameter and adds to Train</param>
        public void Add(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking), "The booking provided is null");
            if (String.IsNullOrWhiteSpace(booking.TrainID))
                throw new ArgumentNullException(nameof(booking), "The booking provided is has no Train ID");

            findTrain(booking.TrainID).Add(booking);
        }

        /// <summary>
        /// Get all Trains currently stored
        /// </summary>
        /// <returns>List of stored trains</returns>
        public List<Train> getTrains()
        {
            return listOfTrains;
        }

        /// <summary>
        /// Return the list of coaches based on the Train ID provided
        /// </summary>
        /// <param name="trainId">Takes trainID as String and searches listOfTrains</param>
        /// <returns>Returns list of coaches for that train</returns>
        public List<Coach> getCoaches(String trainId)
        {
            foreach (Train train in listOfTrains)
            {
                if (train.TrainID.Equals(trainId))
                    return train.CoachList;
            }
            throw new ArgumentNullException(nameof(trainId), "Could not find coaches from Train ID provided");
        }

        /// <summary>
        /// Return single Train from list based on Train ID provided
        /// </summary>
        /// <param name="trainId">Takes trainID as String and searches listOfTrains</param>
        /// <returns>Returns Train object based on Train ID provided</returns>
        public Train findTrain(String trainId)
        {
            foreach (Train train in listOfTrains)
            {
                if (trainId.Equals(train.TrainID))
                    return train;
            }
            throw new ArgumentNullException(nameof(trainId), "Could not find train from Train ID provided");
        }

        /// <summary>
        /// Method used to get a list of departure stations that doesn't include the arrival station
        /// </summary>
        /// <param name="train">Takes Train object to search list of all stations</param>
        /// <returns>Returns a list of all possible departure stations for a provided Train</returns>
        public List<String> getDepartureStations(Train train)
        {
            if (train == null)
                throw new ArgumentNullException(nameof(train), "The train provided is null");
            List<String> listOfDepartures = getAllStations(train);
            listOfDepartures.Remove(train.Destination);
            return listOfDepartures;
        }

        /// <summary>
        /// Method used to get a list of arrival stations that doesn't include the departure station
        /// </summary>
        /// <param name="train">Takes Train object to search list of all stations</param>
        /// <returns>Returns a list of all possible arrival stations for a provided Train</returns>
        public List<String> getArrivalStations(Train train)
        {
            if (train == null)
                throw new ArgumentNullException(nameof(train), "The train provided is null");
            List<String> listOfArrivals = getAllStations(train);
            listOfArrivals.Remove(train.Departure);
            return listOfArrivals;
        }

        /// <summary>
        /// Return all stations for a given train
        /// </summary>
        /// <param name="train">Takes Train object to retrieve all stations stored</param>
        /// <returns>Returns a combined list of all stations Train will stop at</returns>
        public List<String> getAllStations(Train train)
        {
            if (train == null)
                throw new ArgumentNullException(nameof(train), "The train provided is null");
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

        /// <summary>
        /// Produce a comma-separated list of a Train's intermediate stations
        /// </summary>
        /// <param name="train">Takes Train object to retrieve any intermediates it may have</param>
        /// <returns>Returns a string of each intermediate station, separated by commas</returns>
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

        /// <summary>
        /// Calculate the total cost of a booking based off what options the user selects
        /// </summary>
        /// <param name="trainId">The ID of the train the user has selected</param>
        /// <param name="departure">The name of the departure station for the booking</param>
        /// <param name="destination">The name of the destination for the booking</param>
        /// <param name="firstClass">Whether the booking will have first class (True or False)</param>
        /// <param name="sleeperCabin">Whether the booking will have a sleeper cabin (True or False)</param>
        /// <returns>Returns a double value for the total cost of the booking</returns>
        public double calculateBookingCost(String trainId, String departure, String destination, bool firstClass, bool sleeperCabin)
        {
            // Check that a minimum of trainId, departure and destination have been provided
            if (trainId == null || String.IsNullOrWhiteSpace(departure) || String.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Please provide at least a Train ID, Departure and Destination");

            // Set price to £50 if Edinburgh-London or London-Edinburgh have been selected, otherwise set price to £25
            double bookingCost = (departure.Contains("Edinburgh") && destination.Contains("London") 
                || destination.Contains("Edinburgh") && departure.Contains("London")) ? 50 : 25;

            // Add £10 if First Class is selected
            if (findTrain(trainId).FirstClass == false && firstClass)
            {
                throw new ArgumentException("This train does not offer First Class");
            }
            else
            {
                // Add £10 if seat is first class
                if (firstClass)
                {
                    bookingCost += 10;
                }
            }

            // Add £10 if train type is sleeper, then add £20 if sleeper cabin
            if (findTrain(trainId).Type != "Sleeper" && sleeperCabin)
            {
                throw new ArgumentException("This train does not offer Sleeper Cabin");
            }

            if (findTrain(trainId).Type == "Sleeper")
            {
                // if train is a sleeper add £10
                bookingCost += 10;
                // If sleeper train has a cabin add £20
                if (sleeperCabin)
                {
                    bookingCost += 20;
                }
            }
            return bookingCost;
        }

        /// <summary>
        /// Checks the order of the stations depending on the departure and arrival set on the train
        /// </summary>
        /// <param name="trainId">The ID of the train to get the stations from</param>
        /// <param name="departure">The selected departure station by the user</param>
        /// <param name="arrival">The selected arrival station by the user</param>
        public void checkStationOrder(String trainId, String departure, String arrival)
        {
            // Find train by Train ID and get all the stations of that train
            Train train = findTrain(trainId);
            List<String> stations = getAllStations(train);

            // Get the index of the departure of the departure and arrival stations selected
            int departureIndex = stations.IndexOf(departure);
            int arrivalIndex = stations.IndexOf(arrival);

            // Check if selected departure station is after the arrival in the list
            // if the train's departure station is Edinburgh
            if (train.Departure.Contains("Edinburgh") && departureIndex >= arrivalIndex)
            {
                throw new ArgumentException("Train doesn't go in that direction");
            }
            // Check if selected arrival station is before the departure in the list
            // if the train's departure station is London
            if (train.Departure.Contains("London") && departureIndex <= arrivalIndex)
            {
                throw new ArgumentException("Train doesn't go in that direction");
            }
        }

        // Enable TypeNameHandling to determine if Train is ExpressTrain, StoppingTrain or SleeperTrain
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        /// <summary>
        /// Serializes Train and Booking objects and writes them to a JSON file
        /// </summary>
        /// <param name="fileName">The name and path of the file to save the Trains and Bookings</param>
        public void serializeTrain(String fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "No file name provided");
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

        /// <summary>
        /// Reads JSON file and deserializes Trains and Bookings
        /// </summary>
        /// <param name="fileName">The name and path of the file to open</param>
        public void deserializeTrain(String fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "No file name provided");
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
