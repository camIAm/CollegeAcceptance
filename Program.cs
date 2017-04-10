using System;
using System.Collections.Generic;

namespace ConsoleApplication
{ 
    public class Program
    {
        public static void AdmissionDeciled(Applicant applicant, Institute institute)
        {
            Console.WriteLine("We are sorry to inform you");
            System.Console.WriteLine($"Applicant {applicant.FirstName} was rejected with as score of {applicant.StandardizedTest}");
            System.Console.WriteLine($"Institue {institute.InstituteName} required {institute.MinimumScore}");
        }
        public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            // All this data should probably be in a static class
            var dataSourceDict = new Dictionary<DataSource, Lazy<ILoadApplicants>>
            {
                {DataSource.Mock , new Lazy<ILoadApplicants>(() => new SampleApplicantData())},
                {DataSource.CSV, new Lazy<ILoadApplicants>(() => new CSVData())},
                {DataSource.Db, new Lazy<ILoadApplicants>(() => new DbData())},
                {DataSource.InternetService, new Lazy<ILoadApplicants>(() => new InternetServiceData())}
            };
            DataFactory dtFactory = new DataFactory(dataSourceDict);
            var dtSource = dtFactory.GetApplicantSource(DataSource.Mock);
            var applicants = dtSource.GetApplicants();

            SampleInstituteData sampleInstituteData = new SampleInstituteData();
            sampleInstituteData.PoolSize = 30; // this can be changed to take user input
            List<Institute> institutes = sampleInstituteData.GetInstitutes();
            
            int counter = 0; // used to vary item selection, will use random number generator once this portion is moved from main 
            int instituteMinimumScoreNeededForAcceptance = institutes[counter % institutes.Count].MinimumScore;
            string instituteAppliedTo = institutes[counter % institutes.Count].InstituteName;
            Institute institute = new Institute(pub);
            institute.InstituteName = instituteAppliedTo;
            institute.MinimumScore = instituteMinimumScoreNeededForAcceptance;
            ApplicationStack applicantStack = new ApplicationStack();
            Subscriber subscriber = new Subscriber(pub);
            foreach(Applicant applicant in applicants)
            {
                if(applicant==null)
                {
                    Console.WriteLine("null ref");
                }

                applicant.SchoolAppliedTo = instituteAppliedTo;
                //applicant.ScoreNeeded = instituteMinimumScoreNeededForAcceptance;
                counter ++;
                applicant.ScoreNeeded = instituteMinimumScoreNeededForAcceptance;

                if(applicant.StandardizedTest < instituteMinimumScoreNeededForAcceptance)
                {
                    Program.AdmissionDeciled(applicant, institute);
                    applicant.AcceptedMatch = false;
                }
                else
                {  
                    applicant.AcceptedMatch = true;
                    subscriber.Applicant = applicant.FirstName;
                    subscriber.Score = applicant.StandardizedTest;
                    // not sure if initiallizing AcceptanceLetter's Institue property through pub.DoSomething() is decoupling or code smell
                    pub.DoSomething(institutes[counter % institutes.Count].InstituteName);
                } 
                string countString = counter.ToString();
                Console.WriteLine($"counter:{counter} \t");    
                
                applicantStack.ApplicantStack.Push(applicant);
                Console.WriteLine($"Applicants Stack {applicantStack.ApplicantStack.Count}");
                Console.WriteLine($"SampleData.application:{applicant}\n");
            }
            PostApplicationResults postApplicationResults = new PostApplicationResults(new Applicants(applicantStack));
            postApplicationResults.StatsClass();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
// incorporate this Working shuffle into the mail service to randomize letter acceptances
/*            Random rnd = new Random();
            applicants.Shuffle<Applicant>(rnd);
            foreach(var applicant in applicants){
            Console.WriteLine("Post Fish-Yates SampleData.application :{0}", applicant);
            }
  */           

