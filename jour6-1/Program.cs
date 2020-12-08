using System;
using System.Collections.Generic;

namespace jour6_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string line;
            List<Group> groups = new List<Group>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =  new System.IO.StreamReader("data.txt");
            Group currentGroup = new Group();


            while((line = file.ReadLine()) != null)
            {
                if(line.Length==0)
                {

                    groups.Add(currentGroup);
                    currentGroup = new Group();
                }
                else{
                    currentGroup.addAnswers(line);
                }
            }
            groups.Add(currentGroup);

            int total = 0;

            foreach (Group g in groups)
            {
                int somme = g.countTrues();
                Console.WriteLine("Groupe : "+somme);
                total+= somme;
            }
            Console.WriteLine("Total : "+total);
        }
    }

    class Group{
        //a == 97;
        bool[] answerSheet = new bool[26];

        public void addAnswers(String answers){
            foreach (char c in answers)
            {
                answerSheet[((int)c)-97]=true;
            }
        }

        public int countTrues(){
            int result = 0;
            foreach (bool b in answerSheet)
            {
                if (b)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
