using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class SampleInstituteData
    {
        public int PoolSize { get; set; }
        string[] instituteArr = new string[14]{"USC", "Clemson", "Citadel", "CofC", "UGA", "UF","FSU", "GT", "UGA","JMU","UVA","VT", "UNC", "NCST"};
        public int[] instituteMinScores{ get; set; }
        public void SetInstituteTestRequirements()
        {
            instituteMinScores = new int [PoolSize];
            Random randomNum = new Random();
            for(int i = 0; i < PoolSize; i++ )
            {
                instituteMinScores[i] = randomNum.Next(1000, 1600);
            }
        }
        public List<Institute> GetInstitutes()
        {
            SetInstituteTestRequirements();
            List<Institute> institutes = new List<Institute>();
            Institute institute = new Institute();

            Random rnd = new Random();
            byte[] byteArr = new byte[20];
            rnd.NextBytes(byteArr);
            
            for(int i = byteArr.GetLowerBound(0);
                i<= byteArr.GetUpperBound(0);
                i++)
                {
                    institute = new Institute
                    {
                        InstituteName = instituteArr[byteArr[i] % instituteArr.Length],
                        MinimumScore = instituteMinScores[byteArr[i] % instituteMinScores.Length]
                    };
                    institutes.Add(institute);
                }
                return institutes;
        }
    }
}