using DataScience.Algorithms.NeuronalNetwork.Enum;
using DataScience.Algorithms.NeuronalNetwork.Graph;
using DataScience.Algorithms.NeuronalNetwork.Helpers;
using DataScience.Algorithms.NeuronalNetwork.Layers;
using DataScience.Algorithms.NeuronalNetwork.Models;
using DataScience.Algorithms.NeuronalNetwork.Neurons;
using DataScience.Algorithms.NeuronalNetwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Algorithms.NeuronalNetwork.Networks
{
    public abstract class NeuronalNetwork: Graph<Neuron>, INeuronalNetwork
    {
     
        //tipo de aprendizaje que usará la red
        private EnumLearningType learningType;

        //la funcion de activacion de la red...
        private IActivationFunction activationFunction;

        private ITransferFunction transferFunction;

        private List<Layer> layers;

        private LearningRate learningRate;

        private Error error;

        private Iterations iterations;

      
        public NeuronalNetwork()
        {

        }

        //metodo que genera la red neuronal que solicitada
        public abstract Result CreateNeuronalNetwork();

        public abstract Result AjustWeights();

       


    }
}
