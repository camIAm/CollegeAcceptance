using System;

using System.Collections.Generic;
namespace ConsoleApplication
{
    public class SampleInstituteData
    {
        string[] instituteArr = new string[5]{"USC", "Clemson", "Citadel", "CofC", "UGA"};
        public List<Institute> GetInstitutes()
        {

            List<Institute> institutes = new List<Institute>();
            Institute institute;

            Random rnd = new Random();
            byte[] byteArr = new byte[20];
            rnd.NextBytes(byteArr);
            
            for(int i = byteArr.GetLowerBound(0);
                i<= byteArr.GetUpperBound(0);
                i++){
                    institute = new Institute
                    {
                        InstituteName = instituteArr[byteArr[i] % instituteArr.Length]
                    };
                    institutes.Add(institute);
                }
                return institutes;
        }
    }
}