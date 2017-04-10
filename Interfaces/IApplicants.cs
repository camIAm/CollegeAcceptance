using System.Collections.Generic;

namespace ConsoleApplication
{
    public interface IApplicants
    {
        int GetTotalNumberOfApplicants();
        int GetTotalNumberOfAcceptedApplicants();
        int GetTotalNumberOfDeclinedApplicants();
        double AverageApplicantClassAcceptance();
        void ApplicantAcceptDeclineListSeparator();
        Stack<Applicant> ApplicantStack{get;set;}
        double AcceptedApplicantStandardizedScoreDifference();
        
    }
}