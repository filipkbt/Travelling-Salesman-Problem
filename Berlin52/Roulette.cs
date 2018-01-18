using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{ 
    public class Roulette
    {
        private static Random rand = new Random();
        public static int[,] StartRoulette(int[] sumDistancesInRoutes, int numberOfPopulation, int numberOfCities, int[,]arrayBeforeRoulette)
        {
            int max = FindMax(sumDistancesInRoutes);
            int[] arrayCompartments = CreateCompartments(sumDistancesInRoutes, max);
            //for (int i = 0; i < arrayCompartments.Length; i++)
            //    if (i == 0)
            //        Console.WriteLine("Compartment {0} from {1} to {2}", i, 0, arrayCompartments[i]);
            //    else
            //        Console.WriteLine("Compartment {0} from {1} to {2}", i, arrayCompartments[i - 1], arrayCompartments[i]);
            //Console.WriteLine("MAX : " + max);
            int[,] arrayAfterRoulette = CreateRoulettePopulationArray(arrayCompartments, numberOfPopulation,numberOfCities, max,arrayBeforeRoulette);
            return arrayAfterRoulette;
        }

        private static int FindMax(int[] sumDistancesInRoutes)
        {
            int max = 0;
            foreach (int sum in sumDistancesInRoutes)
            {
                if (sum > max)
                    max = sum;
            }
            return max + 1;
        }

        private static int[] CreateCompartments(int[] sumDistancesInRoutes, int max)
        {
            int[] arrayCompartments = new int[sumDistancesInRoutes.Length];
            for (int i = 0; i < sumDistancesInRoutes.Length ; i++)
            {
                if (i == 0)
                {
                    arrayCompartments[0] = max - sumDistancesInRoutes[i];
                }
                else
                {
                    arrayCompartments[i] = arrayCompartments[i - 1] + max - sumDistancesInRoutes[i];
                }
            }
            return arrayCompartments;
        }

        private static int[,] CreateRoulettePopulationArray (int[] arrayCompartments, int numberOfPopulation, int numberOfCities, int max, int[,] arrayBeforeRoulette)
        {
            int[,] roulettePopulationArray = new int[numberOfPopulation,numberOfCities];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                int randomRouteToNewPopulation = rand.Next(0, arrayCompartments[arrayCompartments.Length - 1]);

                int rouletteIndex = -1;
                for(int j=0; j <arrayCompartments.Length; j++)
                {
                    if(randomRouteToNewPopulation < arrayCompartments[j])
                    {
                        rouletteIndex = j;
                        break;
                    }
                }

                for (int j = 0; j < numberOfCities; j++)
                {
                    roulettePopulationArray[i,j] = arrayBeforeRoulette[rouletteIndex,j];
                }
            }
            return roulettePopulationArray;
        }

    }
}
