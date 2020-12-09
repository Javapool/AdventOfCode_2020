using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace jour8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String filepath = "data.txt";
            int programSize = countLines(filepath);
            
            String[] instructions = new String[programSize];
            int[] values = new int[programSize];

            Console.WriteLine(programSize);

            StreamReader SR = new StreamReader(filepath);
            String line;

            int count = 0;

            while((line = SR.ReadLine()) != null)
            {
                String[] splitLine = line.Split(' ');
                instructions[count] = splitLine[0];
                values[count] = int.Parse(splitLine[1], NumberStyles.AllowLeadingSign);
                count++;
            }

            debugProgram(programSize, instructions, values);
        }

        static void debugProgram(int programSize, String[] instructions, int[] values)
        {
            bool run = true;
            bool[] alreadyDone = new bool[programSize];
            int currLine = 0;
            int accumulator = 0;

            while(run){
                if(alreadyDone[currLine]){
                    Console.WriteLine("Faulty line at : "+currLine+"\nAccumulator at : "+ accumulator);
                    run=false;
                    

                }
                else
                {
                    alreadyDone[currLine]=true;
                    switch (instructions[currLine])
                    {
                        case "acc":
                            accumulator+=values[currLine];
                            currLine++;
                            break;
                        case "jmp":
                            currLine+=values[currLine];
                            break;
                        case "nop":
                            currLine++;
                            break;
                        default:
                            Console.WriteLine("Error: default value assigned");
                            break;
                    }
                }
            }
        }

        static int countLines(String filepath)
        {
            int count = 0;
            StreamReader SR = new StreamReader(filepath);
            String line;

            while((line = SR.ReadLine()) != null)
            {
                count++;
            }
            return count;
        }
    }
}
