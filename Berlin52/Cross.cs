using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{
    public class Cross
    {
        private static Random rand = new Random();
        public static int[,] StartCrossing(int[,] arrayAfterSelection, int numberOfPopulation, int numberOfCities, int chance)
        {
            if (rand.Next(0, 10000) > chance)
            {
                int[,] emptyArray = fillNewArrayWithInitializeData(numberOfPopulation, numberOfCities);
                int[,] arrayAfterSwitchMiddleDataInRows = switchMiddleDataInRows(arrayAfterSelection, emptyArray, numberOfPopulation, numberOfCities);
                int[,] arrayAfterCrossing = fillNewArrayWithFinalData(arrayAfterSelection, arrayAfterSwitchMiddleDataInRows, numberOfPopulation, numberOfCities);
                return arrayAfterCrossing;
            }

            return arrayAfterSelection;
        }

        private static int[,] switchMiddleDataInRows(int[,] arrayAfterSelection, int[,] emptyArray, int numberOfPopulation, int numberOfCities)
        {
            for (int i = 0; i < numberOfPopulation; i += 2)
            {
                int firstCompartment = rand.Next(1, numberOfCities);
                int secondCompartment = rand.Next(1, numberOfCities);
                if (firstCompartment < secondCompartment)
                {
                    for (int j = firstCompartment; j < secondCompartment; j++)
                    {
                        emptyArray[i, j] = arrayAfterSelection[i + 1, j];
                        emptyArray[i + 1, j] = arrayAfterSelection[i, j];
                    }
                }
                else
                {
                    for (int j = secondCompartment; j < firstCompartment; j++)
                    {
                        emptyArray[i, j] = arrayAfterSelection[i + 1, j];
                        emptyArray[i + 1, j] = arrayAfterSelection[i, j];
                    }
                }
            }
            return emptyArray;
        }

        private static int[,] fillNewArrayWithInitializeData(int numberOfPopulation, int numberOfCities)
        {
            int[,] arrayAfterCrossing = new int[numberOfPopulation, numberOfCities];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    arrayAfterCrossing[i, j] = -1;
                }
            }
            return arrayAfterCrossing;
        }

        private static int[,] fillNewArrayWithFinalData(int[,] arrayAfterSelection, int[,] arrayAfterSwitchMiddleDataInRows, int numberOfPopulation, int numberOfCities)
        {
            int[] route1 = new int[numberOfCities];
            int[] route2 = new int[numberOfCities];
            for (int i = 0; i < numberOfPopulation; i = i + 2)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    route1[j] = arrayAfterSwitchMiddleDataInRows[i, j];
                    route2[j] = arrayAfterSwitchMiddleDataInRows[i + 1, j];
                }

                for (int j = 0; j < numberOfCities; j++)
                {
                    if (route1[j] == -1)
                    {
                        int cityToFill1 = arrayAfterSelection[i, j];
                        int cityToFill2 = arrayAfterSelection[i + 1, j];
                        
                        while (Array.IndexOf(route1, cityToFill1) != -1)
                        {
                            cityToFill1 = arrayAfterSelection[i, Array.IndexOf(route1, cityToFill1)];
                        }
                       
                        while (Array.IndexOf(route2, cityToFill2) != -1)
                        {
                            cityToFill2 = arrayAfterSelection[i + 1, Array.IndexOf(route2, cityToFill2)];
                        }

                        arrayAfterSwitchMiddleDataInRows[i, j] = cityToFill1;

                        arrayAfterSwitchMiddleDataInRows[i + 1, j] = cityToFill2;
                    }
                }
            }
            return arrayAfterSwitchMiddleDataInRows;
        }     
    }
}
