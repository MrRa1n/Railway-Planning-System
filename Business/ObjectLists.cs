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
        private List<Train> listofTrains = new List<Train>();
        private List<Booking> listOfBookings = new List<Booking>();
        private List<Coach> listOfCoaches = new List<Coach>();

        public ObjectLists() { }

        public void Add(object obj)
        {
            try
            {
                if (obj is Train)
                {
                    listofTrains.Add((Train)obj);
                    Console.WriteLine("Train Added!!!!");
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

        public object Find()
        {

        }
    }
}
