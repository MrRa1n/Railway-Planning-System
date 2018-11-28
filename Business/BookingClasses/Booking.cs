using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BookingClasses
{
    public class Booking
    {
        private TrainSingleton trainSingleton = TrainSingleton.Instance;

        // private properties
        private String _name;
        private String _trainId;
        private String _departureStation;
        private String _arrivalStation;
        private bool _firstClass;
        private bool _sleeperCabin;
        private char _coach;
        private int _seat;


        public String Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Please enter a name!");
                }
                _name = value;
            }
        }

        public String TrainID
        {
            get { return _trainId; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Please select a train!");
                }
                _trainId = value;
            }
        }

        public String DepartureStation
        {
            get { return _departureStation; }
            set
            {
                if (value.Equals(_arrivalStation))
                {
                    throw new ArgumentException("Departure station can't be the same as arrival station!");
                }
                _departureStation = value;
            }
        }

        public String ArrivalStation
        {
            get { return _arrivalStation; }
            set
            {
                if (value.Equals(_departureStation))
                {
                    throw new ArgumentException("Arrival station can't be the same as departure station!");
                }
                _arrivalStation = value;
            }
        }

        // perform check if train offers first class
        public bool FirstClass
        {
            get { return _firstClass; }
            set
            {
                if (value && !checkIfTrainHasFirstClass())
                {
                    throw new ArgumentException("The selected train does not offer First Class!");
                }
                _firstClass = value;
            }
        }

        // perform check if train offers sleeper cabin
        public bool SleeperCabin
        {
            get { return _sleeperCabin; }
            set
            {
                if (value && !checkIfTrainHasSleeperCabin())
                {
                    throw new ArgumentException("The selected train does not offer Sleeper Cabin!");
                }
                _sleeperCabin = value;
            }
        }

        public char Coach
        {
            get { return _coach; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException("Please select a coach!");
                }
                _coach = value;
            }
        }
        public int Seat
        {
            get { return _seat; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException("Please select a seat!");
                }
                _seat = value;
            }
        }

        public Booking(String name, String trainId, String departureStation, String arrivalStation, bool firstClass, bool sleeperCabin, char coach, int seat)
        {
            Name = name;
            TrainID = trainId;
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            FirstClass = firstClass;
            SleeperCabin = sleeperCabin;
            Coach = coach;
            Seat = seat;
        }

        private bool checkIfTrainHasFirstClass()
        {
            if (trainSingleton.FindTrain(_trainId).FirstClass)
                return true;

            return false;
        }

        private bool checkIfTrainHasSleeperCabin()
        {
            if (trainSingleton.FindTrain(_trainId).Type == "Sleeper")
                return true;

            return false;
        }
    }
}
