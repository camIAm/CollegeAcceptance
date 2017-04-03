using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class SampleApplicantData
    {
        public List<Applicant> _applicants;
        string[] firstnames = new string[5]{"jim","tom", "jack","jake","mitch"};
        string[] lastnames = new string[5]{"johnson","thomas", "jackson","montgomery","jackson"};
        int[] scores = new int[5]{1500, 1200, 1000, 950, 1350};
        public List<Applicant> GetApplicants()
        {
            List<Applicant> applicantPool = new List<Applicant>();
            Applicant applicant;
            byte[] randomByteArr = new byte[20];
            Random rnd = new Random();
            rnd.NextBytes(randomByteArr);
            
            Console.WriteLine("starting random mix and match applicants");
            for(int i=randomByteArr.GetLowerBound(0);
             i<=randomByteArr.GetUpperBound(0);
              i++){
                applicant = new Applicant{
                    FirstName = firstnames[randomByteArr[i] % firstnames.Length],
                    LastName = lastnames[randomByteArr[i] % lastnames.Length],
                    StandardizedTest = scores[randomByteArr[i] % scores.Length]
                };
                applicantPool.Add(applicant);
            }
            return applicantPool;
        }
    }
}