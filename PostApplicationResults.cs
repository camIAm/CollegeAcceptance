namespace ConsoleApplication
{
    public class PostApplicationResults
    {
        private IApplicants _applicants;
        public PostApplicationResults(IApplicants applicants)
        {
            _applicants = applicants;
        }
        public void TotalApplicationClass()
        {
            int totalNumberOfApplicants = _applicants.GetTotalNumberOfApplicants();
            System.Console.WriteLine($"Cummulative applicants class size: {totalNumberOfApplicants}");
        }
        public void ClassAcceptancePercentage()
        {
            double acceptedApplicants = _applicants.AverageApplicantClassAcceptance();
            double percentAccepted = acceptedApplicants * 100;
            System.Console.WriteLine($"Percent of applicants accepted to 'match' institute {percentAccepted}");
        }
        public void AcceptedApplicantAverageStandardizedScoreDifference()
        {
            double score = _applicants.AcceptedApplicantStandardizedScoreDifference();
            System.Console.WriteLine($"Standardized Score Difference of accepted applicant {score}");
        
        }
    }
}