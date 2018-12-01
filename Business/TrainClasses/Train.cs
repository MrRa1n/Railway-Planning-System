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
                    throw new ArgumentNullException("Train must have an ID!");
                }
                if (value.Length > 4)
                {
                    throw new ArgumentException("Train ID must not exceed 4 characters");
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
                    throw new ArgumentNullException("Please select a departure station");
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
                    throw new ArgumentNullException("Please select a destination");
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
                    throw new ArgumentNullException("Please select a train type!");
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
                    throw new ArgumentNullException("Please select a departure time!");
                }
                else if (this is SleeperTrain && (value > TimeSpan.Parse("01:00") && value < TimeSpan.Parse("21:00")))
                {
                    throw new ArgumentException("This train can only depart between 21:00 and 01:00");
                }
                _departureTime = value;
            }
        }

        /// <summary>
        /// Departure Day property
        /// - throws ArgumentNullException if null
        /// - throws ArgumentException if departure day is before or on the current day
        /// </summary>
        public DateTime DepartureDay
        {
            get { return _departureDay.Date; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Please select a departure date!");
                }
                else if (value <= DateTime.Now)
                {
                    throw new ArgumentException("Please select a date in the future!");
                }
                _departureDay = value.Date;
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
        /// - throws ArgumentNullException if value is null
        /// </summary>
        public List<Coach> CoachList
        {
            get { return _coachList; }
            set
            {
                _coachList = value ?? throw new ArgumentNullException("No coaches available for train!");
            }
        }

        /// <summary>
        /// Default constructor for Train - required for serialization
        /// </summary>
        public Train() { }

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
            foreach (Coach c in CoachList)
            {
                if (coachId.Equals(c._coachId))
                    return c;
            }
            return null;
        }
    }
}
