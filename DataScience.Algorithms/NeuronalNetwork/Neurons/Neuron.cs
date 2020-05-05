using DataScience.Algorithms.NeuronalNetwork.Enum;
using DataScience.Algorithms.NeuronalNetwork.Layers;
using DataScience.Algorithms.NeuronalNetwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Algorithms.NeuronalNetwork.Neurons
{
    public class Neuron: NeuronBase
    {
        //define el tipo de neurona  suponiendo que definamos distintos tipos.
        private EnumNeuronType neuronType;

        //define el estado de la neurona
        private EnumNeuronState neuronState;

        //entradas
        List<double> inputWeights;
        
        //salida de la neurona
        private double output;

        private double threshold; //umbral

        //crear metodo CalculateOutput


    }
}
