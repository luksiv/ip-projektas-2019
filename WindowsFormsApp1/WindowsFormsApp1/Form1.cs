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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        NeuralNetwork network;
        List<Glass> dataList;
		public const int NUMBER_OF_SEGMENTS = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            network = new NeuralNetwork();
            network.AddLayer(9);
            network.AddLayer(9);
            network.AddLayer(7);
            network.AddLayer(7);
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
            button7.Enabled = true;
            button8.Enabled = true;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
			int testingFileCount = dataList.Count / NUMBER_OF_SEGMENTS;
			for (int segment = 0; segment < NUMBER_OF_SEGMENTS; segment++)
			{
				richTextBox1.AppendText(String.Format("Kryžminė patikra nr {0} \n ", segment + 1));
				List<Glass> glasses = new List<Glass>();
				if (radioButton1.Checked)
				{
					glasses = dataList;
				}
				else if (radioButton2.Checked)
				{
					//glasses = dataList.ClearNoise();
				}
				else
				{
					//glasses = dataList.ClearDistant();
				}
				int trainingFileFrom = segment * testingFileCount;
				int trainingFileTo = (segment + 1) * testingFileCount;
				//network.Shuffle(glasses);
				network.Train(glasses.GetRange(trainingFileFrom, (trainingFileTo - trainingFileFrom -1)));
				for (int i = 0; i < glasses.Count; i++)
				{
					if (!(trainingFileFrom < i && i < trainingFileTo))
					{
						Glass gl = glasses[i];
						List<double> outPuts = network.GetOutputs(gl);
						richTextBox1.AppendText("[");
						foreach (var output in outPuts)
						{
							richTextBox1.AppendText(String.Format("{0}; ", output));
						}
						richTextBox1.AppendText("]\n");
						richTextBox1.AppendText(String.Format("Tikroji: {0}; Did:{1}\n", gl.group_type, outPuts.IndexOf(outPuts.Max())));
					}
				}
			}
            button5.Enabled = true;
            button4.Enabled = true;
        }
    }
}
