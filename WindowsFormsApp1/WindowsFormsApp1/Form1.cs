﻿using System;
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
using WindowsFormsApp1.Bayes;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		NeuralNetwork network;
		List<Glass> dataList;
		public const int NUMBER_OF_SEGMENTS = 5;

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
            button3.Enabled = true;
		}
        

		private void button10_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
			for (int i = 0; i < 9; i++)
			{
				double sum = 0;
				double max = 0;
				double min = 1000000;
				foreach (var gl in dataList)
				{
					if (gl.GetMainValues()[i] >= max)
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
				foreach (var gl in dataList)
				{
					gl.SetMainValues(i, (gl.GetMainValues()[i] - average) / (max - min));
				}
			}
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			GetDataFromWeb dataFromWeb = new GetDataFromWeb();
			dataList = dataFromWeb.GetGlasses();
            var rnd = new Random();
            dataList = dataList.OrderBy(x => rnd.NextDouble()).ToList();
            network.Shuffle(dataList);
			//dataList.RemoveRange(71,40);
			//dataList.RemoveRange(0, 40);
			knn_start.Enabled = true;
			button6.Enabled = true;
			bajes_start.Enabled = true;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			double averageAccurasy = 0;
			List<Glass> glasses = new List<Glass>();
			if (radioButton1.Checked)
			{
				glasses = dataList;
			}
			else
			{
				glasses = clearDistantValuesFromList(dataList);
			}
			int testingFileCount = glasses.Count / NUMBER_OF_SEGMENTS;
			for (int segment = 0; segment < NUMBER_OF_SEGMENTS; segment++)
			{
				richTextBox1.AppendText(String.Format("crosscheck segment {0} \n ", segment + 1));
				int correctGuesses = 0;
				int guessCounter = 0;
				int testingDataFromIndex = segment * testingFileCount;
				int testingDataToIndex = (segment + 1) * testingFileCount;
				var trainingData = new List<Glass>();
				var testingData = new List<Glass>();
				for (int i = 0; i < glasses.Count; i++)
				{
					if (i >= testingDataFromIndex && i <= testingDataToIndex) testingData.Add(glasses[i]);
					else trainingData.Add(glasses[i]);
				}

				output(string.Format("TRAIN: {0, 3}; TEST: {1, 3}", trainingData.Count, testingData.Count));
				network.Train(trainingData);
				foreach (Glass gl in testingData)
				{
					List<double> outPuts = network.GetOutputs(gl);
					//richTextBox1.AppendText("[");
					//foreach (var output in outPuts)
					//{
					//    richTextBox1.AppendText(String.Format("{0}; ", output));
					//}
					//richTextBox1.AppendText("]\n");
					//richTextBox1.AppendText(String.Format("Tikroji: {0}; Did:{1}\n", gl.group_type, outPuts.IndexOf(outPuts.Max()) + 1));
					if (gl.group_type == outPuts.IndexOf(outPuts.Max()) + 1) correctGuesses++;
					guessCounter++;
				}
				double accuracy = Math.Round(((double)correctGuesses / guessCounter) * 100, 2);
				averageAccurasy += accuracy;
				richTextBox1.AppendText(string.Format("Correct guesses: {0, 3} ; Total guesses: {1, 3} ; Accuracy: {2, 4}%\n", correctGuesses, guessCounter, accuracy));
			}
			richTextBox1.AppendText(string.Format("Average accurasy of all segments - {0}%\n", averageAccurasy / NUMBER_OF_SEGMENTS));
            
		}

		private List<Glass> clearDistantValuesFromList(List<Glass> input)
		{
			int k = 2;
			int acceptableDistantItems = 2;
			int removedItems = 0;

			List<Glass> outputList = new List<Glass>();

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
                    if (distantFieldCount <= acceptableDistantItems) outputList.Add(item);
                    else
                    {
                        //output(string.Format("{0}", item.ToString()));
                        removedItems++;
                    }
				}
			}
			richTextBox1.AppendText(string.Format("Removed {0} items out of {1}\n", removedItems, input.Count));
			return outputList;
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
			double averageAccurasy = 0;
			List<Glass> glasses = new List<Glass>();
			if (radioButton1.Checked)
			{
				glasses = dataList;
			}
			else
			{
				glasses = clearDistantValuesFromList(dataList);
			}
			int testingFileCount = glasses.Count / NUMBER_OF_SEGMENTS;
			for (int segment = 0; segment < NUMBER_OF_SEGMENTS; segment++)
			{
				richTextBox1.AppendText(String.Format("Crosscheck segment {0} \n ", segment + 1));
				int correctGuesses = 0;
				int guessCounter = 0;
				int falseGuesses = 0;
				int testingDataFromIndex = segment * testingFileCount;
				int testingDataToIndex = (segment + 1) * testingFileCount;
				var trainingData = new List<Glass>();
				var testingData = new List<Glass>();
				for (int i = 0; i < glasses.Count; i++)
				{
					if (i >= testingDataFromIndex && i <= testingDataToIndex) testingData.Add(glasses[i]);
					else trainingData.Add(glasses[i]);
				}
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
				averageAccurasy += accuracy;

				richTextBox1.AppendText(string.Format("Total: {0, 3}; Training: {1, 3}({2, 4}%); Testing: {3, 3}({4, 4}%)\n", totalGlasses, totalTrain, trainProc, totalTest, testProc));
				richTextBox1.AppendText(string.Format("Correct guesses: {0, 3} ; Total guesses: {1, 3} ; Accuracy: {2, 4}%\n", correctGuesses, guessCounter, accuracy));
			}
			richTextBox1.AppendText(string.Format("Average accurasy of all segments - {0}%\n", averageAccurasy / NUMBER_OF_SEGMENTS));
		}

		private void output(Object obj)
		{
			richTextBox1.AppendText(obj.ToString() + '\n');
		}

		private void bajes_start_Click(object sender, EventArgs e)
		{
			double averageAccurasy = 0;
			List<Glass> glasses = new List<Glass>();
			if (radioButton1.Checked)
			{
				glasses = dataList;
			}
			else
			{
				glasses = clearDistantValuesFromList(dataList);
			}
			int testingFileCount = glasses.Count / NUMBER_OF_SEGMENTS;
			for (int segment = 0; segment < NUMBER_OF_SEGMENTS; segment++)
			{
				richTextBox1.AppendText(String.Format("Crosscheck segment {0} \n ", segment + 1));
				int correctGuesses = 0;
				int guessCounter = 0;
				int falseGuesses = 0;
				int testingDataFromIndex = segment * testingFileCount;
				int testingDataToIndex = (segment + 1) * testingFileCount;
				var trainingData = new List<Glass>();
				var testingData = new List<Glass>();
				for (int i = 0; i < glasses.Count; i++)
				{
					if (i >= testingDataFromIndex && i <= testingDataToIndex) testingData.Add(glasses[i]);
					else trainingData.Add(glasses[i]);
				}
				BayesClassifier bayes = new BayesClassifier(trainingData.Count);
				bayes.trainClassifier(trainingData);
				foreach (Glass glass in testingData)
				{
					int guess = bayes.test(glass);
					if (guess == glass.group_type)
						correctGuesses++;
					else falseGuesses++;
					guessCounter++;

				}
				var totalGlasses = glasses.Count;
				var totalTrain = trainingData.Count;
				var totalTest = testingData.Count;
				double trainProc = Math.Round(((double)totalTrain / totalGlasses) * 100, 2);
				double testProc = Math.Round(((double)totalTest / totalGlasses) * 100, 2);
				double accuracy = Math.Round(((double)correctGuesses / guessCounter) * 100, 2);
				averageAccurasy += accuracy;

				richTextBox1.AppendText(string.Format("Total: {0, 3}; Training: {1, 3}({2, 4}%); Testing: {3, 3}({4, 4}%)\n", totalGlasses, totalTrain, trainProc, totalTest, testProc));
				richTextBox1.AppendText(string.Format("Correct guesses: {0, 3} ; Total guesses: {1, 3} ; Accuracy: {2, 4}%\n", correctGuesses, guessCounter, accuracy));
			}
			richTextBox1.AppendText(string.Format("Average accurasy of all segments - {0}%\n", averageAccurasy / NUMBER_OF_SEGMENTS));
		}

        private void button3_Click(object sender, EventArgs e)
        {
            Glass newGlass = new Glass(-1, (double)riNum.Value, (double)naNum.Value, (double)mgNum.Value, (double)alNum.Value, (double)siNum.Value, (double)kNum.Value, (double)caNum.Value, (double)baNum.Value, (double)feNum.Value, -1);
            var neuralOutput = network.GetOutputs(newGlass);
            output(("[BACK PROPOGATION] Siūloma tipas: " + (neuralOutput.IndexOf(neuralOutput.Max()) + 1)));
            var knn = new KNearestNeighbor(7, dataList);
            output(("[K-Nearest-Neighbors] Siūloma tipas: " + knn.classify(newGlass)));
            BayesClassifier bayes = new BayesClassifier(dataList.Count);
            bayes.trainClassifier(dataList);
            output(("[Bayes] Siūloma tipas: " + bayes.test(newGlass)));
        }
    }
}
