using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace jour4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String myBatchFile = "data.bat";
             if (File.Exists(myBatchFile))
            {
                List<Passport> passports = new List<Passport>();
                StreamReader SR = new StreamReader(myBatchFile);
                string line;

                Passport currentPP = new Passport();

                while ((line = SR.ReadLine()) != null)
                {
                    String[] subs = line.Split(' ');
                    if(subs[0].Length==0)
                    {
                        passports.Add(currentPP);
                        currentPP = new Passport();
                    }
                    else{
                        foreach (String subString in subs)
                        {
                            String[] parameters = subString.Split(':');
                            switch (parameters[0])
                            {
                                case "byr":
                                    currentPP.setByr(Int32.Parse(parameters[1]));
                                    break;
                                case "iyr":
                                    currentPP.setIyr(Int32.Parse(parameters[1]));
                                    break;
                                case "eyr":
                                    currentPP.setEyr(Int32.Parse(parameters[1]));
                                    break;
                                case "hgt":
                                    currentPP.setHgt(Int32.Parse(Regex.Replace(parameters[1], "[^0-9.]", "")));
                                    currentPP.setHgtType(Regex.Replace(parameters[1], "[0-9. ]", ""));
                                    break;
                                case "hcl":
                                    currentPP.setHcl(parameters[1]);
                                    break;
                                case "ecl":
                                    currentPP.setEcl(parameters[1]);
                                    break;
                                case "pid":
                                    currentPP.setPid(parameters[1]);
                                    break;
                                case "cid":
                                    currentPP.setCid(parameters[1]);
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
 
                }
                passports.Add(currentPP);
                Console.WriteLine(passports.Count);
                SR.Close();
                SR.Dispose();

                int validPassports = 0;

                foreach (Passport pp in passports)
                {
                    if(pp.validate())
                    {
                        validPassports++;
                    }
                }
                Console.WriteLine(validPassports);
            }
        }
    }

    class Passport
    {
        int byr =0;
        int iyr = 0;
        int eyr = 0;
        int hgt = 0;

        String hgtType = "";
        String hcl = "";
        String ecl = "";
        String pid = "";
        String cid = "";

        public void setByr(int byr){
            this.byr=byr;
        }
        public void setIyr(int iyr){
            this.iyr=iyr;
        }
        public void setEyr(int eyr){
            this.eyr=eyr;
        }
        public void setHgt(int hgt){
            this.hgt=hgt;
        }
        public void setHgtType(String hgtType){
            this.hgtType = hgtType;
        }
        public void setHcl(String hcl){
            this.hcl = hcl;
        }
        public void setEcl(String ecl){
            this.ecl = ecl;
        }
        public void setPid(String pid){
            this.pid = pid;
        }
        public void setCid(String cid){
            this.cid = cid;
        }

        public int getByr(){
            return this.byr;
        }
        public int getIyr(){
            return this.iyr;
        }
        public int getEyr(){
            return this.eyr;
        }
        public int getHgt(){
            return this.hgt;
        }
        public String getHcl(){
            return this.hcl;
        }
        public String getEcl(){
            return this.ecl;
        }
        public String getPid(){
            return this.pid;
        }
        public String getCid(){
            return this.cid;
        }

        public bool validate(){
            bool valid = false;
            if(validateByr() && validateIyr() && validateEyr() && validateHgt() && validateHcl() && validateEcl() && validatePid())
            {
                valid = true;
            }
            return valid;
        }

        private bool validateByr(){
            bool valid = false;
            if(this.byr>= 1920 && this.byr<= 2002)
            {
                valid = true;
            }
            return valid;

        }
        private bool validateIyr(){
            bool valid = false;
            if(this.iyr>= 2010 && this.iyr<= 2020)
            {
                valid = true;
            }
            return valid;

        }
        private bool validateEyr(){
            bool valid = false;
            if(this.eyr>= 2020 && this.eyr<= 2030)
            {
                valid = true;
            }
            return valid;

        }
        private bool validateHgt(){
            bool valid = false;
            if(this.hgtType=="cm")
            {
                if(this.hgt>=150 && this.hgt<= 193)
                valid = true;
            }
            else if(this.hgtType=="in")
            {
                if(this.hgt>=59 && this.hgt<= 76)
                valid = true;
            }
            return valid;

        }
        private bool validateHcl(){
            bool valid = false;
            if(this.hcl.Length>0){
                if(this.hcl[0]=='#' && Regex.Replace(this.hcl, "[^a-zA-Z0-9]*", "").Length == 6)
                {
                    valid = true;
                }

            }
            return valid;

        }
        private bool validateEcl(){
            bool valid = false;
            String[] validColors = {"amb","blu","brn","gry","grn","hzl","oth"};
            if(validColors.Contains(this.ecl))
            {
                valid = true;
            }
            else{
                Console.WriteLine("Invalid : "+this.ecl);
            }
            return valid;

        }
        private bool validatePid(){
            bool valid = false;

            if(Regex.Replace(this.pid, "[^0-9]*", "").Length == 9)
            {
                valid = true;
            }
            return valid;

        }
    }
}
