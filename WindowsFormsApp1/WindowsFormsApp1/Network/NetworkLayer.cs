using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.Network
{
    class NetworkLayer
    {
        public List<Neuron> NetworkNeurons { get; set; }

        public NetworkLayer()
        {
            NetworkNeurons = new List<Neuron>();
        }

        public void AddLayer(int neuronCount)
        {
            for(int i = 0; i < neuronCount; i++)
            {
                Neuron newNeuron = new Neuron();
                NetworkNeurons.Add(newNeuron);
            }
        }

        public void ConnectLayers(NetworkLayer previous)
        {
            Random random = new Random();
            foreach (Neuron pvNeuron in previous.NetworkNeurons)
            {
                List<Synapse> newConnections = new List<Synapse>();
                foreach (Neuron nextNeuron in this.NetworkNeurons)
                {
                    double k = random.NextDouble();
                    Synapse newSynapse = new Synapse(pvNeuron, nextNeuron, k/10);
                    nextNeuron.Inputs.Add(newSynapse);
                    newConnections.Add(newSynapse);
                }
                pvNeuron.Outputs = newConnections;
            }
        }

        public void PerformCalculation()
        {
            foreach(var neuron in NetworkNeurons)
            {
                if(neuron.Inputs.Count != 0)
                {
                    double sum = 0;
                    foreach(var synapse in neuron.Inputs)
                    {
                        sum += synapse.NeuronFrom.getValue() * synapse.Weight;
                    }
                    neuron.setValue(CalcActivation(sum));
                }
            }
        }

        public double CalcActivation(double weight)
        {
            return 1 / (1 + Math.Pow(Math.E, -1 * weight));
        }
    }
}
