using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.Network
{
    class Synapse
    {
        public Neuron NeuronFrom { get; set; }
        public Neuron NeuronTo { get; set; }
        public double Weight { get; set; }
        public double NewWeight { get; set; }
        public double Delta { get; set; }
        public Synapse(Neuron from, Neuron to, double Syn_weight)
        {
            NeuronFrom = from;
            NeuronTo = to;
            Weight = Syn_weight;
        }
        public void ChangeWeight() { Weight = NewWeight; }
    }
}
