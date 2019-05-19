using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApp1.DataFormating;

namespace WindowsFormsApp1.Network
{
    class NeuralNetwork
    {
        public List<NetworkLayer> NetworkLayers { get; set; }
        private int epoch { get; set; }
        public double LearningRate { get; set; }

        //private List<double> newWeights { get; set; }

        public NeuralNetwork()
        {
            NetworkLayers = new List<NetworkLayer>();
            epoch = 2000;
            LearningRate = 0.0005;
        }

        public NeuralNetwork(int epochos, double learning_Rate)
        {
            NetworkLayers = new List<NetworkLayer>();
            epoch = epochos;
            LearningRate = learning_Rate;
        }

        public void AddLayer(int NeuronCount)
        {
            NetworkLayer newNetworkLayer = new NetworkLayer();
            newNetworkLayer.AddLayer(NeuronCount);
            if (NetworkLayers.Count > 0)
            {
                newNetworkLayer.ConnectLayers(NetworkLayers.Last());
            }
            NetworkLayers.Add(newNetworkLayer);
        }

        public void SetEpoch(int epochos) { epoch = epochos; }

        public int GetEpoch() { return epoch; }

        public void Train(List<Glass> Inputs)
        {
            double totalError = 0;
            for(int i = 0; i < epoch; i++)
            {
                //newWeights = new List<double>();
                for (int j = 0; j < Inputs.Count; j++)
                {
                    //this.SetNeuralNetworkInputValues(Inputs[j]);
                    List<double> outputs = GetOutputs(Inputs[j]);
                    totalError += CalculateTotalError(outputs, Inputs[j]);
                    CalculateNewWeigths(outputs, ConvertGroupToOutputVector(Inputs[j].group_type));
                    UpdateAllSynapses();
                }
                //UpdateAllSynapsesByAverage();               
                Console.WriteLine(string.Format("Epoch: {0, 4}; MSE: {1, 4}", i+1, totalError));
                totalError = 0;
            }
        }
        
        public List<double> ConvertGroupToOutputVector(int groupType)
        {
            List<double> real_outputs = new List<double>();
            for(int  i = 0; i < 7; i++)
            {
                real_outputs.Add(0.01);
            }
            real_outputs[groupType - 1] = 0.99;
            return real_outputs;
        }

        public void CalculateNewWeigths(List<double> outputs, List<double> correct_outputs)
        {
            //double newWeight = weight - LearningRate * ((outputs - correct_outputs)* synpas.fromNeuron.value);
            for (int i = 0; i < outputs.Count; i++)
            {
                foreach (var synape in NetworkLayers.Last().NetworkNeurons[i].Inputs)
                {
                    double curOutput = NetworkLayers.Last().CalcActivation(NetworkLayers.Last().NetworkNeurons[i].CalcOutput());
                    double delta = synape.NeuronFrom.currentValue * (correct_outputs[i] - curOutput) * LearningRate * curOutput * (1 - curOutput);
                    synape.Delta = (outputs[i] - correct_outputs[i]) * outputs[i] * (1 - outputs[i]) * synape.NeuronFrom.currentValue;
                    //if(newWeights.Count <= i)
                    //{
                    //    newWeights.Add(delta);
                    //}
                    //else
                    //{
                    //    newWeights[i] = (newWeights[i] + delta) / 2;
                    //}

                    //var nodeDelta = (correct_outputs[i] - outputs[i]) * outputs[i] * (1 - outputs[i]);
                    //var delta = -1 * synape.NeuronFrom.currentValue * nodeDelta;
                    //synape.NewWeight = synape.Weight - LearningRate * nodeDelta;
                    //synape.NewWeight = synape.Weight - LearningRate * ((outputs[i] - correct_outputs[i]));
                    //double previouseWeigths = synape.NewWeight;
                }
            }
            for (int j = NetworkLayers.Count - 2; j > 0; j--)
            {
                foreach (var neuron in NetworkLayers[j].NetworkNeurons)
                {
                    foreach (var synapse in neuron.Inputs)
                    {
                        synapse.Delta = synapse.NeuronFrom.currentValue * synapse.NeuronTo.currentValue * (1 - synapse.NeuronTo.currentValue) * GetAllDeltas(synapse);
                        //synapse.Weight += synapse.NeuronFrom.currentValue * (correct_outputs[i] - outputs[i]) * LearningRate * outputs[i] * (1 - outputs[i]);


                        //double sumPartial = GetPrSynapsesWeigt(synapse.NeuronTo);
                        //synapse.NewWeight = synapse.Weight - LearningRate * ((outputs[i] - correct_outputs[i]) * synapse.NeuronFrom.getValue());
                        //double previouseWeigths = synapse.NewWeight;
                    }
                }
            }
        }

        public double GetAllDeltas(Synapse synapse)
        {
            double delta = 0;
            foreach(var nextSynapse in synapse.NeuronTo.Outputs)
            {
                delta += nextSynapse.Delta;
                if (nextSynapse.NeuronTo.Outputs.Count != 0)
                {
                    for (int i = 0; i < nextSynapse.NeuronTo.Outputs.Count; i++)
                    {
                        delta += GetAllDeltas(nextSynapse.NeuronTo.Outputs[i]);
                    }
                }
            }
            return delta;
        }

        public double GetPrSynapsesWeigt(Neuron neuron)
        {
            if(neuron.Outputs.Count > 0)
            {
                double nmb = 1;
                foreach(var synapse in neuron.Outputs)
                {
                    GetPrSynapsesWeigt(synapse.NeuronTo);
                    nmb *= synapse.Weight;
                }
                return nmb;
            }
            else
            {
                return 1;
            }
        }

        public void UpdateAllSynapses()
        {
            foreach(var layer in NetworkLayers)
            {
                foreach(var neuron in layer.NetworkNeurons)
                {
                    foreach(var synapse in neuron.Inputs)
                    {
                        synapse.Weight = synapse.Weight - LearningRate * synapse.Delta;
                    }
                }
            }
        }

        public void UpdateAllSynapsesByAverage()
        {
            for (int i = 0; i < 7; i++)
            {
                foreach (var synapse in NetworkLayers.Last().NetworkNeurons[i].Inputs)
                {
                    //synapse.Weight += newWeights[i];
                }
            }
        }
        public double CalculateTotalError(List<double> outputs, Glass Input)
        {
            double error = 0;
            for(int  i = 0; i < 7; i++)
            {
                switch (Input.group_type)
                {
                    case 1:
                        if(i == 0)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 2:
                        if (i == 1)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 3:
                        if (i == 2)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 4:
                        if (i == 3)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 5:
                        if (i == 4)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 6:
                        if (i == 5)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                    case 7:
                        if (i == 6)
                        {
                            error += Math.Pow(outputs[i] - 0.99, 2) / 2;
                        }
                        else
                        {
                            error += Math.Pow(outputs[i] - 0.01, 2) / 2;
                        }
                        break;
                }
            }
            return error;
        }

        public List<double> GetOutputs(Glass Input)
        {
            SetNeuralNetworkInputValues(Input);            
            List<double> outputValues = new List<double>();
            foreach(var layer in NetworkLayers)
            {
                layer.PerformCalculation();
            }
            foreach(var neuron in NetworkLayers.Last().NetworkNeurons)
            {
                outputValues.Add(neuron.getValue());
            }
            return outputValues;
        }
        public void SetNeuralNetworkInputValues(Glass glass_obj)
        {
            List<double> glass_values = glass_obj.GetMainValues();
            for(int i = 0; i < 9; i++)
            {
                NetworkLayers.First().NetworkNeurons[i].setValue(glass_values[i]);
            }
        }



        public void Shuffle(List<Glass> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Glass value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
