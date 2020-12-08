using System;
using System.Collections.Generic;
using System.IO;

namespace jour5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = "data.txt";
            StreamReader SR = new StreamReader(file);
            string line;
            List<bPass> passes = new List<bPass>();

            while ((line = SR.ReadLine()) != null)
            {
                passes.Add(new bPass(line));
            }

            int maxId = 0;
            foreach (bPass b in passes)
            {
                int currId=b.SeatId();

                if(currId>maxId){
                    maxId=currId;
                }
            }

            bool[] ids = new bool[maxId];

            foreach (bPass b in passes)
            {
                ids[b.SeatId()-1]=true;
            }

            for (int i = 0; i < ids.Length; i++)
            {
                if(ids[i]==false){
                    Console.WriteLine(i+1);
                }
            }

        }
    }

    class bPass
    {
        int row = 0;
        int column = 0;
        public bPass(String code){
            this.row=readRow(code.Substring(0,7));
            this.column=readColumn(code.Substring(7));
        }
     

        static int readRow(String code){
            int result = 0;
            int refValue=1;

            for (int i = code.Length-1; i >=0; i--)
            {
                if(code[i]=='B'){
                    result+=refValue;
                }
                refValue=refValue*2;
            }

            return result;
        }



        static int readColumn(String code){
            int result = 0;
            int refValue=1;

            for (int i = code.Length-1; i >=0; i--)
            {
                if(code[i]=='R'){
                    result+=refValue;
                }
                refValue=refValue*2;
            }

            return result;

        }

        public override String ToString(){
            return "Row : "+this.row+" -Column : "+this.column;
        }

        public int SeatId(){
            return this.row * 8 + this.column;
        }
    }
}
