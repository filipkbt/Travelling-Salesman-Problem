using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{
    public static class RouteDistanceCounter
    {

        public static int[,] CountDistanceBetweenCities(int[,] nArrayWithRandomValues, int[,] distanceBetweenCities, int numberOfCities, int numberOfPopulation)
        {
            int[,] tripDistanceBetweenCities = new int[numberOfPopulation, numberOfCities];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (j != numberOfCities - 1)
                    {
                        tripDistanceBetweenCities[i, j] = distanceBetweenCities[nArrayWithRandomValues[i, j], nArrayWithRandomValues[i, j + 1]];
                    }
                    else
                    {
                        tripDistanceBetweenCities[i, j] = distanceBetweenCities[nArrayWithRandomValues[i, j], nArrayWithRandomValues[i, 0]];
                    }
                }
            }
            return tripDistanceBetweenCities;
        }

        //returns route sum between all cities in current travel
        public static int[] CountSumDistancesBetweenCities(int[,] tripDistanceBetweenCities, int numberOfCities, int numberOfPopulation)
        {
            int[] SumDistancesBetweenCities = new int[numberOfPopulation];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                int sum = 0;
                for (int j = 0; j < numberOfCities; j++)
                {
                    sum += tripDistanceBetweenCities[i, j];
                }
                SumDistancesBetweenCities[i] = sum;
            }

            return SumDistancesBetweenCities;
        }      

    }
}
