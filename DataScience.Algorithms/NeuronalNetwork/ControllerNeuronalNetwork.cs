using DataScience.Algorithms.NeuronalNetwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Algorithms.NeuronalNetwork
{
    //este es el objeto que establecera la comunicacion con la red...
    public class ControllerNeuronalNetwork: ControllerNNBase
    {

        private INeuronalNetwork neuronalNetwork;

        public INeuronalNetwork NeuronalNetwork
        {
            get { return neuronalNetwork; }
            set { neuronalNetwork = value; }
        }


        /// <summary>
        /// controlador
        /// </summary>
        public ControllerNeuronalNetwork()
        {

        }


    }
}
