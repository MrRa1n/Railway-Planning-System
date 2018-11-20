using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Data
{
    public class TrainDAO
    {
        public List<Train> ListOfTrains { get; set; }

        public TrainDAO()
        {
            ListOfTrains = new List<Train>();
        }

        public void Add(Train t)
        {
            ListOfTrains.Add(t);
        }

        public Train Find(String trainId)
        {
            foreach (Train t in ListOfTrains)
            {
                if (trainId.Equals(t.TrainID))
                {
                    return t;
                }
            }
            return null;
        }

        public void printTrains()
        {
            foreach (Train t in ListOfTrains)
                t.printTrain();
        }
    }
}
