using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Berlin52
{
    public class Initializator
    {
        private static Random rand = new Random();
        public static int[,] CreateNArraysWithRandomRoutes(int numberOfPopulation, int numberOfCities)
        {
            int[,] randomUniqueRoutesArray = new int[numberOfPopulation,numberOfCities];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    randomUniqueRoutesArray[i, j] = -1;
                }
            }

            for (int i = 0; i < numberOfPopulation; i++)
            {
                Thread.Sleep(20);
                for (int j = 0; j < numberOfCities; j++)
                {                    
                    int nextValue;
                    nextValue = rand.Next(0, numberOfCities);
                    while (CheckIfArrayContainsCurrentRoute(randomUniqueRoutesArray, nextValue, i,numberOfCities))
                    {
                        nextValue = rand.Next(0, numberOfCities);
                    }

                    randomUniqueRoutesArray[i,j] = nextValue;
                }
            }
            return randomUniqueRoutesArray;
        }

        private static bool CheckIfArrayContainsCurrentRoute(int[,] array, int value,int currentRow,int numberOfCities)
        {
            for (int i = 0; i < numberOfCities; i++)
            {
                if (array[currentRow,i] == value) return true;
            }
            return false;
        }
    }
}
