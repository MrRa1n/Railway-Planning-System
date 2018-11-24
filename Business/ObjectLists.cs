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
        private static List<Train> listOfTrains = new List<Train>();
        private static List<Booking> listOfBookings = new List<Booking>();
        private List<Coach> listOfCoaches = new List<Coach>();

        public ObjectLists() { }

        public void Add(object obj)
        {
            try
            {
                if (obj is Train)
                {
                    listOfTrains.Add((Train)obj);
                    listOfCoaches = ((Train)obj).CoachList;
                }
                else if (obj is Booking)
                {
                    listOfBookings.Add((Booking)obj);
                    // check what coach
                    foreach (Coach c in listOfCoaches)
                    {
                        if (((Booking)obj).Coach == c.coachId)
                        {
                            c.addBookingToCoach(((Booking)obj));
                        }
                    }
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

        public List<Train> getTrains()
        {
            return listOfTrains;
        }

        public List<Coach> getCoaches()
        {
            return listOfCoaches;
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



        public void PrintBookings()
        {
            foreach (Booking b in listOfBookings)
            {
                Console.WriteLine(b.Name);
            }
        }
    }
}
