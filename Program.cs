using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class AcceptanceLetter :EventArgs
    {
        readonly string greeting = "Congrats";
        public string Message {get; set;}
        //public Institute Institute;
        public string Institute{ get;set; }
        public AcceptanceLetter(string institute) // should take (Institute institute), 
        // make lone institute call with zip, and shit
        // change Institute class to something including score criteria
        // 
        {
            Message = greeting;
            Institute = institute;
        }
    }
    public class Publisher
    {
        Object objectLock = new Object();
        public event EventHandler<AcceptanceLetter> RaiseCustomEvent;
        public event EventHandler<AcceptanceLetter> RaiseCustomEvents
        {
            add
            {
                lock (objectLock)
                {
                    RaiseCustomEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    RaiseCustomEvent -= value;
                }
            }
        }
        public void DoSomething(string institute)    //Institute institute)
        {
            OnRaisedEvent(new AcceptanceLetter(institute)); // make canidate object
        }
        void OnRaisedEvent(AcceptanceLetter e)
        {
            EventHandler<AcceptanceLetter> handler = RaiseCustomEvent;

            if(handler != null)
            {
                e.Message += String.Format($" Date: {DateTime.Now}");
                handler(this,e);
            }
    }
    public class Subscriber
    {
        private string _applicant;
        private int _score;
        public Subscriber(string applicant,int score, Publisher pub)
        {
            pub.RaiseCustomEvent = null;
            _applicant = applicant;
            _score = score;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            System.Console.WriteLine("From Subscriber.HandleCustomeEvent:");
            System.Console.WriteLine($"\t Type:ConsoleApplication.Institute \n\t\t e.Message: {e.Message} e.Institute: {e.Institute}");
            System.Console.WriteLine($"\t ConsoleApplication.Publisher.Subscriber \n\t\t _applicant: {_applicant}, _score: {_score}");
            //Console.WriteLine("applicant #:{3} \n For: {0}\n {1}\n You were accepted based on your standardized score of {2} " , _applicant, e.Message, _score, _id);
            //System.Console.WriteLine("List of applicants {0}",_applicantsNames.Count);
        }
    }
    
    public class Program
    {
        public static void AdmissionDeciled()
        {
            Console.WriteLine("We are sorry to inform you");
        }
        public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            // All this data should probably be in a static class
            SampleApplicantData sampleData = new SampleApplicantData();
            List<Applicant> applicants = sampleData.GetApplicants();
            SampleInstituteData sampleInstituteData = new SampleInstituteData();
            List<Institute> institutes = sampleInstituteData.GetInstitutes();
            
            int counter =0; // used to vary item selection, will use random number generator once this portion is moved from main 
            int minimumScoreNeededForAcceptance = institutes[counter % institutes.Count].MinimumScore;
            string schoolAppliedTo =institutes[counter % institutes.Count].InstituteName;
            new Institute(schoolAppliedTo, pub, minimumScoreNeededForAcceptance);
            ApplicationStack applicantTotalList = new ApplicationStack();
            foreach(Applicant applicant in applicants)
            {
                if(applicant==null)
                {
                    Console.WriteLine("null ref");
                }

                counter ++;
                if(applicant.StandardizedTest < minimumScoreNeededForAcceptance)
                {
                    Program.AdmissionDeciled();
                    applicant.AcceptedMatch = false;
                }
                else
                {  
                    applicant.AcceptedMatch = true;
                    //new AcceptanceLetter(institutes[counter % institutes.Count].InstituteName);
                    new Subscriber(applicant.FirstName, applicant.StandardizedTest, pub);
                    // not sure if initiallizing AcceptanceLetter's Institue property through pub.DoSomething() is decoupling or code smell
                    pub.DoSomething(institutes[counter % institutes.Count].InstituteName);
                }
                applicant.SchoolAppliedTo = schoolAppliedTo;
                applicant.ScoreNeeded = minimumScoreNeededForAcceptance; 
                string countString = counter.ToString();
                Console.WriteLine($"counter:{counter} \t");    
                
                applicantTotalList.ApplicantStack.Push(applicant);
                Console.WriteLine($"Applicants Stack {applicantTotalList.ApplicantStack.Count}");
                Console.WriteLine($"SampleData.application:{applicant}\n");
            }
            PostApplicationResults postApplicationResults = new PostApplicationResults(new Applicants(applicantTotalList));
            postApplicationResults.TotalApplicationClass();
            postApplicationResults.ClassAcceptancePercentage();
            postApplicationResults.AcceptedApplicantAverageStandardizedScoreDifference();
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
}
