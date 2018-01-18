using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{
    public class Tournament
    {
        private static Random rand = new Random();
        public static int StartTournament(int[] SumDistancesInRoutes, int amountOfRoutes)
        {
            int min = 0;
            int winnerIndex = -1;
            for (int i = 0; i < amountOfRoutes; i++)
            {
                int randomIndex = rand.Next(0, SumDistancesInRoutes.Length);
                if(i == 0)
                {
                    min = SumDistancesInRoutes[randomIndex];
                    winnerIndex = randomIndex;
                }
                if(min > SumDistancesInRoutes[randomIndex])
                {
                    min = SumDistancesInRoutes[randomIndex];
                    winnerIndex = randomIndex;
                } 
            }
            return winnerIndex;
        }

        public static int[,] FillArrayAfterTournament(int[,] arrayBeforeTournament, int[] arrayWinnersOfTournament, int numberOfPopulation,int numberOfCities)
        {
            int[,] arrayAfterTournament = new int[numberOfPopulation,numberOfCities];
            for (int i = 0; i < numberOfPopulation; i++)
            {
                for (int j = 0; j< numberOfCities; j++)
                {                 
                    arrayAfterTournament[i,j] = arrayBeforeTournament[arrayWinnersOfTournament[i],j];
                }               
            }
            return arrayAfterTournament;
        }
    }
}
