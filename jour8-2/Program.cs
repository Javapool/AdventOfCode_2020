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

            List<int> shadowInstructions = new List<int>();
            for (int i = 0; i< programSize; i++)
            {
                if(instructions[i] == "jmp" || instructions[i] == "nop")
                shadowInstructions.Add(i);
                
            }

            Console.WriteLine(shadowInstructions.Count);

            foreach (int i in shadowInstructions)
            {
                Console.WriteLine((i+1) + "---" + instructions[i]);
                if(debugProgram(programSize, instructions, values, i))
                {
                    Console.WriteLine("Victory!!" + (i+1));
                }
                
            }
        }

        static bool debugProgram(int programSize, String[] instructionsGiven, int[] values, int lineChange)
        {
            String[] instructions = new string[programSize];
            for (int i = 0; i < programSize; i++)
            {
                instructions[i]=instructionsGiven[i];
            }

            if(lineChange != -1 && lineChange < programSize)
            {
                if(instructions[lineChange]=="nop")
                {
                    instructions[lineChange]="jmp";
                }
                else if(instructions[lineChange]=="jmp")
                {
                    instructions[lineChange]="nop";
                }

            }
            bool run = true;
            bool[] alreadyDone = new bool[programSize];
            int currLine = 0;
            int accumulator = 0;

            while(run && currLine < programSize){
                if(alreadyDone[currLine]){
                    //Console.WriteLine("Faulty line at : "+currLine+"\nAccumulator at : "+ accumulator);
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
            return run;
            
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
