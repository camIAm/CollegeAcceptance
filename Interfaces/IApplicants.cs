using System.Collections.Generic;

namespace ConsoleApplication
{
    public interface IApplicants
    {
        int GetTotalNumberOfApplicants();
        int GetTotalNumberOfAcceptedApplicants();
        int GetTotalNumberOfDeclinedApplicants();
        decimal AverageApplicantClassAcceptance();
        void ApplicantAcceptDeclineListSeparator();
        Stack<Applicant> ApplicantStack{get;set;}
        decimal AcceptedApplicantStandardizedScoreDifference();
        
    }
}