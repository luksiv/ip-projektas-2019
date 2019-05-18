using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.Network
{
    class Neuron
    {
        public List<Synapse> Inputs { get; set; }
        public List<Synapse> Outputs { get; set; }
        public Guid ID { get; private set; }
        public double currentValue { get; set; }

        public Neuron()
        {
            ID = Guid.NewGuid();
            Inputs = new List<Synapse>();
            Outputs = new List<Synapse>();
        }
        public void setValue(double value)
        {
            currentValue = value;
        }

        public double getValue() { return currentValue; }

        public double CalcOutput() { return Inputs.Select(x => x.Weight * x.NeuronFrom.getValue()).Sum(); }
    }
}
