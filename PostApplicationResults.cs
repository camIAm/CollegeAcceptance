namespace ConsoleApplication
{
    public class PostApplicationResults
    {
        private IApplicants _applicantStack;
        public PostApplicationResults(IApplicants applicantStack)
        {
            _applicantStack = applicantStack;
        }
        public void TotalApplicationClass()
        {
            int totalNumberOfApplicants = _applicantStack.GetTotalNumberOfApplicants();
            System.Console.WriteLine($"Cummulative applicants class size: {totalNumberOfApplicants}");
        }
        public void ClassAcceptancePercentage()
        {
            double acceptedApplicants = _applicantStack.AverageApplicantClassAcceptance();
            double percentAccepted = acceptedApplicants * 100;
            System.Console.WriteLine($"Percent of applicants accepted to 'match' institute {percentAccepted}");
        }
        public void AcceptedApplicantAverageStandardizedScoreDifference()
        {
            double score = _applicantStack.AcceptedApplicantStandardizedScoreDifference();
        
        }
    }
}