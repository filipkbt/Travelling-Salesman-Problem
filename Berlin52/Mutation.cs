using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{
    public class Mutation
    {
        private static Random rand = new Random();

        public static int[,] StartMutation(int[,] arrayAfterCross, int numberOfPopulation, int numberOfCities, int chance)
        {
            for(int i = 0; i < numberOfPopulation ; i++)
            {
                for(int j = 0; j < numberOfCities; j++)
                {
                    if (rand.Next(0, 10000) > chance)
                    {
                        int exchangedCityIndex = rand.Next(0, numberOfCities);
                        int exchangedCity2 = arrayAfterCross[i, j];
                        arrayAfterCross[i, j] = arrayAfterCross[i, exchangedCityIndex];
                        arrayAfterCross[i, exchangedCityIndex] = exchangedCity2;
                    }
                }
            }
            return arrayAfterCross;
        }
    }
}
