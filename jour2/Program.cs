using System;
using System.Collections.Generic;

namespace jour2
{
    class Program
    {
        static void Main(string[] args)
        {

            char delimiter = ' ';

            int passwordNumber = 0;
            int validPasswords = 0;
            string line;
            List<String[]> passwords = new List<String[]>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =  new System.IO.StreamReader("D:\\Prog\\AdventOfCode_2020\\jour2\\data.txt");

            while((line = file.ReadLine()) != null)
            {
            passwords.Add(line.Split(delimiter));
            passwordNumber++;
            }

            foreach (String[] strings in passwords)
            {

                int countedChar = 0;

                String[] limits = strings[0].Split('-');
                int lowerLimit = Int16.Parse(limits[0]);
                int higherLimit = Int16.Parse(limits[1]);
                char mandatoryLetter = strings[1][0];

                foreach (char c in strings[2])
                {
                    if (c==mandatoryLetter)
                    {
                        countedChar++;
                    }
                }

                if(countedChar>=lowerLimit && countedChar <= higherLimit)
                {
                    validPasswords++;
                }

 
            }

            Console.WriteLine(validPasswords);

        }
    }
}
