using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApp1.DataFormating;

namespace WindowsFormsApp1.Bayes
{
	class BayesClassifier
	{
		const double NEW_VALUE_PROBABILITY = 0.4;

		int dataSetSize { get; set; }

		Dictionary<double, GlassTypes> refractive_index =  new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> sodium = new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> magnesium = new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> aluminum = new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> silicon = new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> potassium = new Dictionary<double, GlassTypes>();
		Dictionary<double, GlassTypes> iron = new Dictionary<double, GlassTypes>();

		Dictionary<double, TypesProbabilities> refractive_indexProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> sodiumProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> magnesiumProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> aluminumProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> siliconProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> potassiumProbability = new Dictionary<double, TypesProbabilities>();
		Dictionary<double, TypesProbabilities> ironProbability = new Dictionary<double, TypesProbabilities>();

		TypesProbabilities typesApperance = new TypesProbabilities();

		public BayesClassifier (int dataSetSize)
		{
			this.dataSetSize = dataSetSize;
		}

		public void trainClassifier(List<Glass> glasses)
		{
			GlassTypes typeCounters = new GlassTypes();
			foreach  (Glass glass in glasses)
			{
				glassTypeAnalise(refractive_index, glass.refractive_index, glass.group_type);
				glassTypeAnalise(sodium, glass.sodium, glass.group_type);
				glassTypeAnalise(magnesium, glass.magnesium, glass.group_type);
				glassTypeAnalise(aluminum, glass.aluminum, glass.group_type);
				glassTypeAnalise(silicon, glass.silicon, glass.group_type);
				glassTypeAnalise(potassium, glass.potassium, glass.group_type);
				glassTypeAnalise(iron, glass.iron, glass.group_type);

				typeCounters = increaseTypeCount(typeCounters, glass.group_type);
			}
			calculateProbabilities(refractive_index, refractive_indexProbability, typeCounters);
			calculateProbabilities(sodium, sodiumProbability, typeCounters);
			calculateProbabilities(magnesium, magnesiumProbability, typeCounters);
			calculateProbabilities(aluminum, aluminumProbability, typeCounters);
			calculateProbabilities(silicon, siliconProbability, typeCounters);
			calculateProbabilities(potassium, potassiumProbability, typeCounters);
			calculateProbabilities(iron, ironProbability, typeCounters);

			calculateTypesApperance(typeCounters);
		}

		private void glassTypeAnalise(Dictionary<double, GlassTypes> dict, double value, int type)
		{
			GlassTypes types;
			if (dict.ContainsKey(value))
			{
				types = dict[value];
				dict[value] = increaseTypeCount(types, type);
			}
			else
			{
				types = new GlassTypes();
				dict.Add(value, increaseTypeCount(types, type));
			}

		}

		private GlassTypes increaseTypeCount(GlassTypes types, int type)
		{
			switch (type)
			{
				case 1:
					types.type1++;
					break;
				case 2:
					types.type2++;
					break;
				case 3:
					types.type3++;
					break;
				case 4:
					types.type4++;
					break;
				case 5:
					types.type5++;
					break;
				case 6:
					types.type6++;
					break;
				case 7:
					types.type7++;
					break;
			}

			return types;
		}

		private void calculateProbabilities(Dictionary<double, GlassTypes> dict, Dictionary<double, TypesProbabilities> probList, GlassTypes typeCounters)
		{
			foreach (KeyValuePair<double, GlassTypes> item in dict)
			{
				probList.Add(item.Key, calculateTypesProbabilities(item.Value, typeCounters));
			}	
		}

		private TypesProbabilities calculateTypesProbabilities(GlassTypes types, GlassTypes typesCounters)
		{
			TypesProbabilities tp = new TypesProbabilities();
			tp.type2Probobility = calculateProbability(types.type1, typesCounters.type1);
			tp.type2Probobility = calculateProbability(types.type2, typesCounters.type2);
			tp.type3Probobility = calculateProbability(types.type3, typesCounters.type3);
			tp.type4Probobility = calculateProbability(types.type4, typesCounters.type4);
			tp.type5Probobility = calculateProbability(types.type5, typesCounters.type5);
			tp.type6Probobility = calculateProbability(types.type6, typesCounters.type6);
			tp.type7Probobility = calculateProbability(types.type7, typesCounters.type7);

			tp.changeZeros();

			return tp;
		}

		private double calculateProbability(int valueCount, int valueTypesCount)
		{
			if (valueCount == 0)
				return 0.01;
			return (double)valueCount / (double)valueTypesCount;
		}

		private void calculateTypesApperance(GlassTypes types)
		{
			typesApperance.type1Probobility = types.type1 / dataSetSize;
			typesApperance.type2Probobility = types.type2 / dataSetSize;
			typesApperance.type3Probobility = types.type3 / dataSetSize;
			typesApperance.type4Probobility = types.type4 / dataSetSize;
			typesApperance.type5Probobility = types.type5 / dataSetSize;
			typesApperance.type6Probobility = types.type6 / dataSetSize;
			typesApperance.type7Probobility = types.type7 / dataSetSize;

			typesApperance.changeZeros();
		}

		public int test(Glass glass)
		{
			double biggestValue = 0, temp;
			int typeGuess = 0;

			temp = calculateType1Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 1;
			}
			temp = calculateType2Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 2;
			}
			temp = calculateType3Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 3;
			}
			temp = calculateType4Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 4;
			}
			temp = calculateType5Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 5;
			}
			temp = calculateType6Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 6;
			}
			temp = calculateType7Probability(glass);
			if (biggestValue < temp)
			{
				biggestValue = temp;
				typeGuess = 7;
			}

			return typeGuess;
		}

		private double calculateType1Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type1Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type1Probobility;
		}
		private double calculateType2Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type2Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type2Probobility; ;
		}
		private double calculateType3Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type3Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type3Probobility; ;
		}
		private double calculateType4Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type4Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type4Probobility; ;
		}
		private double calculateType5Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type5Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type5Probobility; ;
		}
		private double calculateType6Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type6Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type6Probobility; ;
		}
		private double calculateType7Probability(Glass glass)
		{
			double probability = 1;

			if (refractive_indexProbability.ContainsKey(glass.refractive_index))
				probability = probability * refractive_indexProbability[glass.refractive_index].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (sodiumProbability.ContainsKey(glass.sodium))
				probability = probability * sodiumProbability[glass.sodium].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (magnesiumProbability.ContainsKey(glass.magnesium))
				probability = probability * magnesiumProbability[glass.magnesium].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (aluminumProbability.ContainsKey(glass.aluminum))
				probability = probability * aluminumProbability[glass.aluminum].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (siliconProbability.ContainsKey(glass.silicon))
				probability = probability * siliconProbability[glass.silicon].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (potassiumProbability.ContainsKey(glass.potassium))
				probability = probability * potassiumProbability[glass.potassium].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;
			if (ironProbability.ContainsKey(glass.iron))
				probability = probability * ironProbability[glass.iron].type7Probobility;
			else probability = probability * NEW_VALUE_PROBABILITY;

			return probability * typesApperance.type7Probobility; ;

		}
	}

}
