using System;
using System.Collections.Generic;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            List<int> numbers = new List<int>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =  new System.IO.StreamReader("D:\\Prog\\AdventOfCode_2020\\myapp\\data.txt");

            while((line = file.ReadLine()) != null)
            {
            numbers.Add(Int16.Parse(line));
            counter++;
            }


            file.Close();

            int[] numbersArray = new int[counter];

            counter = 0;
            foreach (int number in numbers)
            {
                numbersArray[counter] = number;
                counter++;
            }

            Array.Sort(numbersArray);

            Console.WriteLine(counter);
            int counterUp = 0;
            int counterDown = numbersArray.Length-1;

            int nb1=numbersArray[counterUp];
            int nb2=numbersArray[counterDown];

            while(nb1+nb2!=2020){
                int current = nb1+nb2;
                if (current<2020)
                {
                    counterUp++;
                    nb1 = numbersArray[counterUp];   
                }
                else
                {
                    counterDown--;
                    nb2 = numbersArray[counterDown]; 
                }
                Console.WriteLine(nb1+nb2);
            }
            Console.WriteLine("Solution : "+nb1*nb2);
            

            // Suspend the screen.
            Console.ReadLine();



            Console.WriteLine("Hello World!");
        }
    }
}
