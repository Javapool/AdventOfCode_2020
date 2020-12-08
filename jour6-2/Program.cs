using System;
using System.Collections.Generic;

namespace jour6_2
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

    class Person{
        bool[] answerSheet = new bool[26];

        public bool[] GetSheet(){
            return answerSheet;
        }
    }

    class Group{
        //a == 97


        bool initialized = false;
        bool[] groupAnswerSheet = new bool[26];
        List<Person> members = new List<Person>();

        public int compoundAnswers(){
            int memberNB = members.Count;
            bool[,] sheets= new bool[memberNB,26];

            for (int i = 0; i < memberNB; i++)
            {
                sheets[i]=members[i].GetSheet();
            }


        }

        public void addAnswers(String answers){
            if(!initialized){
                foreach (char c in answers)
                {
                    groupAnswerSheet[((int)c)-97]=true;
                }

            }
        }

        public int countTrues(){
            int result = 0;
            foreach (bool b in groupAnswerSheet)
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
