using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Berlin52
{
    class Program
    {
        private static Random rand = new Random();
        private static string path = @"C:\filip\berlin52.txt";
        private static string[] whiteSpaces = { " ", ",", ";", ".'" };
        private const int numberOfCities = 52;
        private const int numberOfPopulation = 68;
        private static int minDistanceGlobal = 150000;
        private static int amountOfRoutes = 14;
        private static int chanceToCross = 1000;
        private static int chanceToMutation = 9475;

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int[,] distanceBetweenCities = Reader.ReadArrayFromFileAndCreate(path);
            int[,] randomUniqueRoutesArray = Initializator.CreateNArraysWithRandomRoutes(numberOfPopulation, numberOfCities);
            #region program
            for (int o = 0; o < 500000; o++)
            {
                if (o % 20000 == 0)
                {
                    chanceToMutation += 25;
                }

                int[,] tripDistanceBetweenCities = RouteDistanceCounter.CountDistanceBetweenCities(randomUniqueRoutesArray, distanceBetweenCities, numberOfCities, numberOfPopulation);

                int[] SumDistancesInRoutes = RouteDistanceCounter.CountSumDistancesBetweenCities(tripDistanceBetweenCities, numberOfCities, numberOfPopulation);
                for (int i = 0; i < SumDistancesInRoutes.Length; i++)
                {
                    if (SumDistancesInRoutes[i] < minDistanceGlobal)
                    {
                        minDistanceGlobal = SumDistancesInRoutes[i];
                        Console.WriteLine("New minimum : {0} iteration number {1}", minDistanceGlobal, o);
                        for (int j = 0;j < numberOfCities;j++)
                        {
                            Console.Write(randomUniqueRoutesArray[i,j] + "-");
                        }
                        Console.WriteLine();                            
                    }
                }

                #region tournament selection
                int[] arrayWinnersOfTournaments = new int[numberOfPopulation];
                for (int i = 0; i < numberOfPopulation; i++)
                {
                    arrayWinnersOfTournaments[i] = Tournament.StartTournament(SumDistancesInRoutes, amountOfRoutes);
                }
                int[,] arrayAfterTournament = Tournament.FillArrayAfterTournament(randomUniqueRoutesArray, arrayWinnersOfTournaments, numberOfPopulation, numberOfCities);
                #endregion

                //int[,] arrayAfterRoulette = Roulette.StartRoulette(SumDistancesInRoutes, numberOfPopulation, numberOfCities, randomUniqueRoutesArray);

                int[,] arrayAfterCrossing = Cross.StartCrossing(arrayAfterTournament, numberOfPopulation, numberOfCities, chanceToCross);

                    randomUniqueRoutesArray = Mutation.StartMutation(arrayAfterCrossing, numberOfPopulation, numberOfCities, chanceToMutation);

            }
            #endregion
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("koniec " + elapsedTime);
            Console.ReadKey();
        }
    }
}

