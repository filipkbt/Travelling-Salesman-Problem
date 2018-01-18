using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlin52
{
    public static class Reader
    {
        public static int[,] ReadArrayFromFileAndCreate(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                int linesCount = lines.Length;
                int[,] distanceBetweenCities = new int[linesCount - 1, linesCount - 1];
                for (int i = 1; i < linesCount; i++)
                {
                    string[] substrings = lines[i].Trim().Split(' ');
                    for (int j = 0; j < substrings.Length; j++)
                    {
                        if (j < i)
                        {
                            distanceBetweenCities[i - 1, j] = Convert.ToInt32(substrings[j]);
                            distanceBetweenCities[j, i - 1] = distanceBetweenCities[i - 1, j];
                        }
                        else
                        {
                            distanceBetweenCities[i - 1, j] = 0;
                        }
                    }
                }
                return distanceBetweenCities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
