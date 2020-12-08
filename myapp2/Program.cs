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

            Console.WriteLine(counter);

            foreach (int number1 in numbers)
            {
                foreach (int number2 in numbers)
                {
                    foreach (int number3 in numbers)
                    {
                        if (number1+number2+number3==2020)
                        {
                            Console.WriteLine("Solution : "+number1*number2*number3);
                            
                        }
                        
                    }
                }
                
            }

            // Suspend the screen.||
            Console.ReadLine();



            Console.WriteLine("Hello World!");
        }
    }
}
