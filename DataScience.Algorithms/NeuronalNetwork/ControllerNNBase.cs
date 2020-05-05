using DataScience.Algorithms.NeuronalNetwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Algorithms.NeuronalNetwork
{
    public class ControllerNNBase : IControllerNNBase
    {
        public virtual void  Classify()
        {
            throw new NotImplementedException();
        }

        public virtual void Training()
        {
            throw new NotImplementedException();
        }
    }
}
