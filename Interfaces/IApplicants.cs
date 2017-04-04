using System.Collections.Generic;

namespace ConsoleApplication
{
    public interface IApplicants
    {
        int GetTotalNumberOfApplicants();
        double AverageApplicantClassAcceptance();
        void ApplicantAcceptDeclineListSeparator();
        Stack<Applicant> ApplicantStack{get;set;}
        double AcceptedApplicantStandardizedScoreDifference();
        
    }
}