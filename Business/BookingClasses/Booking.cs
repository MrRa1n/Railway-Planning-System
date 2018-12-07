/**
 *  Author:             Toby Cook
 *  Description:        This class provide properties for Bookings that can be added to each Train coach.
 *                      Bookings can only be added once a Train has been created.
 *  Last modified:      07/12/18
 *  Design patterns:    
 */


using System;

namespace Business.BookingClasses
{
    public class Booking
    {
        private String _name;
        private String _trainId;
        private String _departureStation;
        private String _arrivalStation;
        private bool _firstClass;
        private bool _sleeperCabin;
        private char _coach;
        private int _seat;

        /// <summary>
        /// Name property
        /// - throws ArgumentNullException if no name provided
        /// </summary>
        public String Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a name");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Train ID property for Booking
        /// - throws ArgumentNullException if no Train has been selected
        /// </summary>
        public String TrainID
        {
            get { return _trainId; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a train ID");
                }
                _trainId = value;
            }
        }

        /// <summary>
        /// Departure station property
        /// - throws ArgumentException if match with the Arrival station
        /// </summary>
        public String DepartureStation
        {
            get { return _departureStation; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a departure station");
                }
                if (_arrivalStation != null && value.Equals(_arrivalStation))
                {
                    throw new ArgumentException("Departure station can't be the same as arrival station");
                }
                _departureStation = value;
            }
        }

        /// <summary>
        /// Arrival Station property
        /// - throws ArgumentException if match with Departure station
        /// </summary>
        public String ArrivalStation
        {
            get { return _arrivalStation; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Please provide an arrival station");
                }
                if (_departureStation != null && value.Equals(_departureStation))
                {
                    throw new ArgumentException("Arrival station can't be the same as departure station");
                }
                _arrivalStation = value;
            }
        }

        /// <summary>
        /// First Class property for Booking
        /// </summary>
        public bool FirstClass
        {
            get { return _firstClass; }
            set
            {
                _firstClass = value;
            }
        }

        /// <summary>
        /// Sleeper Cabin property
        /// </summary>
        public bool SleeperCabin
        {
            get { return _sleeperCabin; }
            set
            {
                _sleeperCabin = value;
            }
        }

        /// <summary>
        /// Coach property
        /// - throws ArgumentNullException if no Coach has been selected
        /// </summary>
        public char Coach
        {
            get { return _coach; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a coach ID");
                }
                _coach = value;
            }
        }

        /// <summary>
        /// Seat property
        /// - throws ArgumentNullException if no seat has been selected
        /// </summary>
        public int Seat
        {
            get { return _seat; }
            set
            { 
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a seat number");
                }
                _seat = value;
            }
        }

        

        public Booking() { }

        /// <summary>
        /// Constructor for Booking with parameters
        /// </summary>
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
    }
}
