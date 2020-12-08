using System;
using System.Collections.Generic;
using System.Numerics;

namespace jour3p1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string line;
            List<String> steps = new List<String>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =  new System.IO.StreamReader("data.txt");

            while((line = file.ReadLine()) != null)
            {
            steps.Add(line);
            }

            BigInteger trees11 = calibrateRoute(steps, 1,1);
            Console.WriteLine(trees11);
            BigInteger trees31 = calibrateRoute(steps, 3,1);
            Console.WriteLine(trees31);
            BigInteger trees51 = calibrateRoute(steps, 5,1);
            Console.WriteLine(trees51);
            BigInteger trees71 = calibrateRoute(steps, 7,1);
            Console.WriteLine(trees71);
            BigInteger trees12 = calibrateRoute(steps, 1,2);
            Console.WriteLine(trees12);

            BigInteger product = trees11*trees12*trees31*trees51*trees71;
            Console.Write(product);
       
        }

        static int calibrateRoute(List<String> steps, int rightInc, int downInc){

            int treesEncountered = 0;
            int stepsLength = steps.Count;
            int length = steps[0].Length;
            int indexX = 0;

            for (int i = 0; i < stepsLength; i+=downInc)
            {
                if(steps[i][indexX]=='#'){
                    treesEncountered++;
                }
                indexX+=rightInc;
                indexX = indexX % length;
            }

            return treesEncountered;

        }
    }
}
