namespace ConsoleApplication
{
    public class PostApplicationResults
    {
        private IApplicants _applicants;
        public PostApplicationResults(IApplicants applicants)
        {
            _applicants = applicants;
        }
        public void StatsClass()
        {
            TotalAccpetedApplicants();
            TotalDeclinedApplicants();
            TotalApplicationClass();
            ClassAcceptancePercentage();
            AcceptedApplicantAverageStandardizedScoreDifference();
        }
        public void TotalApplicationClass()
        {
            int totalNumberOfApplicants = _applicants.GetTotalNumberOfApplicants();
            System.Console.WriteLine($"Cummulative applicants class size: {totalNumberOfApplicants}");
        }
        public void TotalAccpetedApplicants()
        {
            int numberOfAcceptedApplicants = _applicants.GetTotalNumberOfAcceptedApplicants();
            System.Console.WriteLine($"Cummulative number of accepted applicants: {numberOfAcceptedApplicants}");
        }
        public void TotalDeclinedApplicants()
        {
            int numberOfDeclinedApplicants = _applicants.GetTotalNumberOfDeclinedApplicants();;
            System.Console.WriteLine($"Cummulative number of declined applicants: {numberOfDeclinedApplicants}");
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
            if(score == 0)
            {
                System.Console.WriteLine($"Standardized Score Difference of accepted applicant {score}, since no applicants were accepted");
            }
            System.Console.WriteLine($"Standardized Score Difference of accepted applicant {score}");
        }
    }
}