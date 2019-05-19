using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.DataFormating;
using WindowsFormsApp1.Network;
using WindowsFormsApp1.kNN;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        NeuralNetwork network;
        List<Glass> dataList;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            network = new NeuralNetwork();
            network.AddLayer(9);
            network.AddLayer(7);
            button2.Enabled = true;
        }

        public void VisualizeNeuralNetwork()
        {
            ClearChart();
            ChartSetSizes(0f, network.NetworkLayers.Count + 1, 0f, 15f);
            Series Nodes = new Series("Nodes");
            Nodes.Color = Color.Salmon;
            Nodes.ChartType = SeriesChartType.Point;
            int x = 0;
            int y = 0;
            foreach (var layer in network.NetworkLayers)
            {
                x++;
                y = 0;
                foreach (var node in layer.NetworkNeurons)
                {
                    y++;
                    Nodes.Points.AddXY(x, y);
                }
            }
            chart1.Series.Add(Nodes);
        }

        public void ChartSetSizes(float minX, float maxX, float minY, float maxY)
        {
            chart1.ChartAreas[0].AxisX.Maximum = maxX;
            chart1.ChartAreas[0].AxisX.Minimum = minX;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;
            chart1.ChartAreas[0].AxisY.Minimum = minY;
        }

        public void ClearChart()
        {
            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisualizeNeuralNetwork();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            for(int  i = 0; i < 9; i++)
            {
                double sum = 0;
                double max = 0;
                double min = 1000000;
                foreach(var gl in dataList)
                {
                    if(gl.GetMainValues()[i] >= max)
                    {
                        max = gl.GetMainValues()[i];
                    }
                    if (gl.GetMainValues()[i] <= min)
                    {
                        min = gl.GetMainValues()[i];
                    }
                    sum += gl.GetMainValues()[i];
                }
                double average = sum / dataList.Count;
                foreach(var gl in dataList)
                {
                    gl.SetMainValues(i,(gl.GetMainValues()[i] - average) / (max - min));
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GetDataFromWeb dataFromWeb = new GetDataFromWeb();
            dataList = dataFromWeb.GetGlasses();
            //dataList.RemoveRange(71,40);
            //dataList.RemoveRange(0, 40);
            knn_start.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int correctGuesses = 0;
            int guessCounter = 0;
            richTextBox1.AppendText("Starting learning...\n");
            List<Glass> glasses = new List<Glass>();
            if (radioButton1.Checked)
            {
                glasses = dataList;
            }
            else
            {
                glasses = clearDistantValuesFromList(dataList);
            }
            int testData = (int) Math.Floor(glasses.Count * 0.9);
            network.Shuffle(glasses);
            network.Train(glasses.GetRange(0, testData));
            for (int i = testData; i < glasses.Count; i++)
            {
                Glass gl = glasses[i];
                List<double> outPuts = network.GetOutputs(gl);
                richTextBox1.AppendText("[");
                foreach (var output in outPuts)
                {
                    richTextBox1.AppendText(String.Format("{0}; ", output));
                }
                richTextBox1.AppendText("]\n");
                richTextBox1.AppendText(String.Format("Tikroji: {0}; Did:{1}\n", gl.group_type, outPuts.IndexOf(outPuts.Max())+1));
                if (gl.group_type == outPuts.IndexOf(outPuts.Max()) + 1) correctGuesses++;
                guessCounter++;
            }
            var totalGlasses = glasses.Count;
            var totalTrain = testData;
            var totalTest = totalGlasses - testData;         
            double trainProc =  Math.Round(((double) totalTrain     / totalGlasses)*100, 2);
            double testProc =   Math.Round(((double) totalTest      / totalGlasses)*100, 2);
            double accuracy =   Math.Round(((double) correctGuesses / guessCounter)*100, 2);

            richTextBox1.AppendText(string.Format("Total: {0, 3}; Training: {1, 3}({2, 4}%); Testing: {3, 3}({4, 4}%)\n", totalGlasses, totalTrain, trainProc, totalTest, testProc));
            richTextBox1.AppendText(string.Format("Correct guesses: {0, 3} ; Total guesses: {1, 3} ; Accuracy: {2, 4}%\n", correctGuesses, guessCounter, accuracy));
            button5.Enabled = true;
            button4.Enabled = true;
        }

        private List<Glass> clearDistantValuesFromList(List<Glass> input)
        {
            int k = 2;
            int acceptableDistantItems = 2;
            int removedItems = 0;

            List<Glass> output = new List<Glass>();

            HashSet<int> groups = new HashSet<int>();
            foreach (var item in input)
            {
                groups.Add(item.group_type);
            }

            foreach (int group in groups)
            {
                var groupItems = input.Where(x => x.group_type == group).ToList();

                double ri_upper = getUpperBound(groupItems.Select(field => field.refractive_index).ToList(), k);
                double ri_lower = getLowerBound(groupItems.Select(field => field.refractive_index).ToList(), k);

                double so_upper = getUpperBound(groupItems.Select(field => field.sodium).ToList(), k);
                double so_lower = getLowerBound(groupItems.Select(field => field.sodium).ToList(), k);

                double mg_upper = getUpperBound(groupItems.Select(field => field.magnesium).ToList(), k);
                double mg_lower = getLowerBound(groupItems.Select(field => field.magnesium).ToList(), k);

                double al_upper = getUpperBound(groupItems.Select(field => field.aluminum).ToList(), k);
                double al_lower = getLowerBound(groupItems.Select(field => field.aluminum).ToList(), k);

                double si_upper = getUpperBound(groupItems.Select(field => field.silicon).ToList(), k);
                double si_lower = getLowerBound(groupItems.Select(field => field.silicon).ToList(), k);

                double pt_upper = getUpperBound(groupItems.Select(field => field.potassium).ToList(), k);
                double pt_lower = getLowerBound(groupItems.Select(field => field.potassium).ToList(), k);

                double ca_upper = getUpperBound(groupItems.Select(field => field.calcium).ToList(), k);
                double ca_lower = getLowerBound(groupItems.Select(field => field.calcium).ToList(), k);

                double ba_upper = getUpperBound(groupItems.Select(field => field.barium).ToList(), k);
                double ba_lower = getLowerBound(groupItems.Select(field => field.barium).ToList(), k);

                double fe_upper = getUpperBound(groupItems.Select(field => field.iron).ToList(), k);
                double fe_lower = getLowerBound(groupItems.Select(field => field.iron).ToList(), k);

                foreach (Glass item in groupItems)
                {
                    int distantFieldCount = 0;
                    if (ri_lower > item.refractive_index || ri_upper < item.refractive_index) distantFieldCount++;
                    if (so_lower > item.sodium || so_upper < item.sodium) distantFieldCount++;
                    if (mg_lower > item.magnesium || mg_upper < item.magnesium) distantFieldCount++;
                    if (al_lower > item.aluminum || al_upper < item.aluminum) distantFieldCount++;
                    if (si_lower > item.silicon || si_upper < item.silicon) distantFieldCount++;
                    if (pt_lower > item.potassium || pt_upper < item.potassium) distantFieldCount++;
                    if (ca_lower > item.calcium || ca_upper < item.calcium) distantFieldCount++;
                    if (ba_lower > item.barium || ba_upper < item.barium) distantFieldCount++;
                    if (fe_lower > item.iron || fe_upper < item.iron) distantFieldCount++;
                    if (distantFieldCount <= acceptableDistantItems) output.Add(item);
                    else removedItems++;
                }
            }
            richTextBox1.AppendText(string.Format("Removed {0} items out of {1}\n", removedItems, input.Count));
            return output;
        }

        private double getUpperBound(List<double> input, int k)
        {
            double avg = input.Average();
            double stdev = getStandardDeviation(input);
            return avg + k * stdev;
        }

        private double getLowerBound(List<double> input, int k)
        {
            double avg = input.Average();
            double stdev = getStandardDeviation(input);
            return avg - k * stdev;
        }
        private double getStandardDeviation(List<double> input)
        {
            double avg = input.Average();
            double sd = Math.Sqrt(input.Average(v => Math.Pow(v - avg, 2)));
            return sd;
        }

        private void Knn_start_Click(object sender, EventArgs e)
        {
            int correctGuesses = 0;
            int guessCounter = 0;
            int falseGuesses = 0;
            
            List<Glass> glasses = new List<Glass>();
            if (radioButton1.Checked)
            {
                glasses = dataList;
            }
            else
            {
                glasses = clearDistantValuesFromList(dataList);
            }
            int trainingDataCount = (int)Math.Floor(glasses.Count * 0.8);
            List<Glass> trainingData = glasses.GetRange(0, trainingDataCount);
            List<Glass> testingData = glasses.GetRange(trainingDataCount, glasses.Count - trainingDataCount);
            var knn = new KNearestNeighbor(7, trainingData);
            foreach (Glass item in testingData)
            {
                var ans = knn.classify(item);
                guessCounter++;
                if (ans == item.group_type) correctGuesses++;
                else falseGuesses++;
            }
            var totalGlasses = glasses.Count;
            var totalTrain = trainingData.Count;
            var totalTest = testingData.Count;
            double trainProc = Math.Round(((double)totalTrain / totalGlasses) * 100, 2);
            double testProc = Math.Round(((double)totalTest / totalGlasses) * 100, 2);
            double accuracy = Math.Round(((double)correctGuesses / guessCounter) * 100, 2);

            richTextBox1.AppendText(string.Format("Total: {0, 3}; Training: {1, 3}({2, 4}%); Testing: {3, 3}({4, 4}%)\n", totalGlasses, totalTrain, trainProc, totalTest, testProc));
            richTextBox1.AppendText(string.Format("Correct guesses: {0, 3} ; Total guesses: {1, 3} ; Accuracy: {2, 4}%\n", correctGuesses, guessCounter, accuracy));
        }

        private void output(Object obj)
        {
            richTextBox1.AppendText(obj.ToString() + '\n');
        }
    }
}
