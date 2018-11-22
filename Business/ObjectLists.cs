using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BookingClasses;
using Business.TrainClasses;

namespace Business
{
    public class ObjectLists
    {
        private List<Train> listOfTrains = new List<Train>();
        private List<Booking> listOfBookings = new List<Booking>();
        private List<Coach> listOfCoaches = new List<Coach>();

        public ObjectLists() { }

        public void Add(object obj)
        {
            try
            {
                if (obj is Train)
                {
                    listOfTrains.Add((Train)obj);
                }
                else if (obj is Booking)
                {
                    listOfBookings.Add((Booking)obj);
                }
                else if (obj is Coach)
                {
                    listOfCoaches.Add((Coach)obj);
                }
                else throw new Exception("Type not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public bool BookedSeats(char coach, int seat)
        {
            foreach (Booking b in listOfBookings)
            {
                if (coach == b.Coach)
                {
                    // coach match
                    if (seat == b.Seat)
                    {
                        //seat match
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public void PrintBookings()
        {
            foreach (Booking b in listOfBookings)
            {
                Console.WriteLine(b.Name);
            }
        }
    }
}
