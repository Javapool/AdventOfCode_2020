using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace jour7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bag> possibleBags = new List<Bag>();
            String file = "data.txt";

            StreamReader SR = new StreamReader(file);
            string line;

            while ((line = SR.ReadLine()) != null)
            {
                line = Regex.Replace(line," bag(s*)\\.*", "");

                String[] splitInput = line.Split("contain ");
                String[] containedBags = splitInput[1].Split(", ");

                foreach (String  str in containedBags)
                {
                    Console.WriteLine(str);
                }

                Bag mainBag = addBag(splitInput[0]);
                foreach (String bag in containedBags)
                {
                    if(bag=="no other")
                    {
                        break;
                    }
                    int number = Int32.Parse(Regex.Match(bag, @"\d+").Value);
                    String color = Regex.Replace(bag,@"\d+ ", "");

                    Bag current = addBag(color);
                    mainBag.addChild(current,number);
                    current.addParent(mainBag);
                }
            }

            foreach (Bag bag in possibleBags)
            {
                Console.WriteLine(bag.ToString());
            }

            Bag bagExists(String color)
            {
                foreach (Bag bag in possibleBags)
                {
                    if(bag.getColor()==color)
                    {
                        return bag;
                    }
                }
                return null;
            }

            Bag addBag(String color){
                Bag current = bagExists(color);
                if(current ==null )
                {
                    current = new Bag(color);
                    possibleBags.Add(current);
                }
                return current;
            }
        }

    }

    class Bag
    {
        String color;

        public Bag(String color){
            this.color = color;
        }

        List<(Bag, int)> contains = new List<(Bag, int)>();
        List<Bag> containedBy = new List<Bag>();

        public String getColor(){
            return this.color;
        }

        public void addParent(Bag parent)
        {
            this.containedBy.Add(parent);
        }

        public void addChild(Bag child, int number)
        {
            this.contains.Add((child,number));

        }

        public override String ToString(){
            String result = "Color-"+this.color+"\nChildren :\n";
            foreach ((Bag,int) child in contains)
            {
                result+="\t"+child.Item2+" "+child.Item1.getColor()+"\n";
            }
            return result;
        }
    }
}
