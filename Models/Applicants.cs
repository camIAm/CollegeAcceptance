using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Applicants : IApplicants
    {
        public Stack<Applicant> ApplicantStack {get; set;}
        private List<Applicant> AcceptedApplicants{get;set;} 
        private List<Applicant> DeclinedApplicants{get;set;}
        public Applicants(ApplicationStack applicationStack)
        {
            ApplicantStack = applicationStack.ApplicantStack;
            AcceptedApplicants = AcceptedApplicants ?? new List<Applicant>();
            DeclinedApplicants = DeclinedApplicants ?? new List<Applicant>();
            ApplicantAcceptDeclineListSeparator();
        }
        public int GetTotalNumberOfApplicants() => AcceptedApplicants.Count + DeclinedApplicants.Count;
        public int GetTotalNumberOfAcceptedApplicants() => AcceptedApplicants.Count;
        public int GetTotalNumberOfDeclinedApplicants() => DeclinedApplicants.Count;
        public double AverageApplicantClassAcceptance()
        {
            int totalAcceptedApplicants = AcceptedApplicants.Count;
            int totalOverallApplicants = AcceptedApplicants.Count + DeclinedApplicants.Count;
            double average = ((double)totalAcceptedApplicants/(double)totalOverallApplicants);
            return average;
        }
        public double AcceptedApplicantStandardizedScoreDifference()
        {
            int totalDifference = AcceptedApplicants
                                    .Sum(s=>s.StandardizedTest - s.ScoreNeeded);
            if(totalDifference == 0)
            {
                return 0;
            }
            return totalDifference/(AcceptedApplicants.Count);
        }
        public void ApplicantAcceptDeclineListSeparator()
        {    
            while(ApplicantStack.Count > 0)
            {
                Applicant applicant = ApplicantStack.Pop();
                if(!applicant.AcceptedMatch)
                {
                    DeclinedApplicants.Add(applicant);
                }
                else
                {
                    AcceptedApplicants.Add(applicant);
                }
            }
        }
    }   
}
