using System;
using Business.TrainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class TrainFacade
    {
        private StoppingTrain _stoppingTrain;
        private ExpressTrain _expressTrain;
        private SleeperTrain _sleeperTrain;

        public TrainFacade()
        {
            _stoppingTrain = new StoppingTrain();
            _expressTrain = new ExpressTrain();
            _sleeperTrain = new SleeperTrain();
        }

        public void CreateNewTrain()
        {

        }
    }
}
