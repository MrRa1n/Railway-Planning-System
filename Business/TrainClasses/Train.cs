using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.TrainClasses;
using Business.BookingClasses;

namespace Business
{
    public class Train
    {
        // Private variables
        private String _trainId;
        private String _departure;
        private String _destination;
        private String _type;
        private TimeSpan _departureTime;
        private DateTime _departureDay;
        private bool _firstClass;
        private List<Coach> _coachList;

        // Getters and Setters
        public String TrainID
        {
            get { return _trainId; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Train must have an ID!");
                }
                _trainId = value;
            }
        }

        public String Departure
        {
            get { return _departure; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Please select a departure station!");
                }
                _departure = value;
            }
        }

        public String Destination
        {
            get { return _destination; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Please select a destination!");
                }
                _destination = value;
            }
        }
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

        public bool FirstClass
        {
            get { return _firstClass; }
            set
            {
                _firstClass = value;
            }
        }

        public List<Coach> CoachList
        {
            get { return _coachList; }
            set
            {
                _coachList = value ?? throw new ArgumentNullException("No coaches available for train!");
            }
        }

        // Constructors
        public Train() { }

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

        // Public methods
        public void Add(Booking booking)
        {
            Coach coach = FindCoach(booking.Coach);
            coach.addBookingToCoach(booking);
        }

        public Coach FindCoach(char coachId)
        {
            foreach (Coach c in CoachList)
            {
                if (coachId.Equals(c.coachId))
                    return c;
            }
            return null;
        }
    }
}
