using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.TrainClasses;
using Business.BookingClasses;

namespace Business
{
    public abstract class Train
    {
        public const String SelectedDepartureTimeOutOfRange = "This train can only depart between 21:00 and 01:00";
        public const String SelectedDateMustBeInFuture = "Please select a date in the future!";

        private String _trainId;
        private String _departure;
        private String _destination;
        private String _type;
        private TimeSpan _departureTime;
        private DateTime _departureDay;
        private bool _firstClass;
        private List<Coach> _coachList;

        /// <summary>
        /// Train ID property
        /// - throws ArgumentNullException if null
        /// - throws ArgumentException if more than 4 characters
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
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException("Train ID must be 4 characters");
                }
                _trainId = value;
            }
        }

        /// <summary>
        /// Departure station property
        /// - throws ArgumentNullException if null
        /// </summary>
        public String Departure
        {
            get { return _departure; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a departure station");
                }
                if (value.Equals(_destination))
                {
                    throw new ArgumentException("Departure station can't be the same as destination");
                }
                _departure = value;
            }
        }

        /// <summary>
        /// Destination property
        /// - throws ArgumentNullException if null
        /// </summary>
        public String Destination
        {
            get { return _destination; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a destination");
                }
                if (value.Equals(_departure))
                {
                    throw new ArgumentException("Destination can't be the same as departure station");
                }
                _destination = value;
            }
        }

        /// <summary>
        /// Train Type property
        /// - throws ArgumentNullException if null
        /// </summary>
        public String Type
        {
            get { return _type; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a train type");
                }
                _type = value;
            }
        }

        /// <summary>
        /// Departure Time property
        /// - throws ArgumentNullException if null
        /// - throws ArgumentException if selected time is out of range 21:00 and 01:00
        /// </summary>
        public TimeSpan DepartureTime
        {
            get { return _departureTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a departure time");
                }
                if (this is SleeperTrain && (value > TimeSpan.Parse("01:00") && value < TimeSpan.Parse("21:00")))
                {
                    throw new ArgumentOutOfRangeException("Departure Time", value, SelectedDepartureTimeOutOfRange);
                }
                _departureTime = value;
            }
        }

        /// <summary>
        /// Departure Day property
        /// - throws ArgumentNullException if null
        /// </summary>
        public DateTime DepartureDay
        {
            get { return _departureDay; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Please provide a departure date");
                }
                _departureDay = value;
            }
        }

        /// <summary>
        /// First Class property
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
        /// Coach List property
        /// - throws ArgumentNullException if Coach List is null or empty
        /// </summary>
        public List<Coach> CoachList
        {
            get { return _coachList; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentNullException(nameof(value), "No coaches available for train");
                }
                _coachList = value;
            }
        }

        /// <summary>
        /// Default constructor for Train - required for serialization
        /// </summary>
        protected Train() { }

        /// <summary>
        /// Constructor for train with parameters
        /// </summary>
        public Train(String trainId, String departure, String destination, String type, TimeSpan departureTime, DateTime departureDay, bool firstClass, List<Coach> coachList)
        {
            TrainID = trainId;
            Departure = departure;
            Destination = destination;
            Type = type;
            DepartureTime = departureTime;
            DepartureDay = departureDay;
            FirstClass = firstClass;
            CoachList = coachList;
        }

        /// <summary>
        /// Calls FindCoach method to assign Booking to coach based on Coach ID
        /// </summary>
        /// <param name="booking">Takes booking object and adds it to Coach</param>
        public void Add(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking), "Please provide a valid booking");

            Coach coach = FindCoach(booking.Coach);
            coach.addBookingToCoach(booking);
        }

        /// <summary>
        /// Method for finding a Coach in order to add a Booking to it
        /// </summary>
        /// <param name="coachId">Takes coachId and checks if it matches Coach in list</param>
        /// <returns>Returns Coach that matches the input coachId, if no coach is found it returns null</returns>
        public Coach FindCoach(char coachId)
        {
            foreach (Coach coach in CoachList)
            {
                if (coachId.Equals(coach.CoachID))
                    return coach;
            }
            return null;
        }
    }
}
