using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class AcceptanceLetter:EventArgs
    {
         readonly string greeting = "Congrats";
        public AcceptanceLetter(Institute institute){
            message = greeting;
            Institute = institute;
        }
        public string Message {get ; set ;}
        private string message;
        public Institute Institute;
    }
    public class Publisher
    {
        public event EventHandler<AcceptanceLetter> RaiseCustomEvent;
        public void DoSomething(Institute institute)
        {
            OnRaisedEvent(new AcceptanceLetter(institute)); // make canidate object
        }
        void OnRaisedEvent(AcceptanceLetter e)
        {
            EventHandler<AcceptanceLetter> handler = RaiseCustomEvent;

            if(handler != null)
            {
                e.Message += String.Format(" Date: {0}",DateTime.Now);
                handler(this,e);
            }
    }
    public class Subscriber
    {
        private string _id;
        private string _applicant;
        private int _score;
        public Subscriber(string id, string applicant,int score, Publisher pub){
            _id = id;
            _applicant = applicant;
            _score = score;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            Console.WriteLine("applicant #:{3} \n For: {0}\n {1}\n You were accepted based on your standardized score of {2} " , _applicant, e.Message, _score, _id);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            SampleApplicantData sampleData = new SampleApplicantData();
            List<Applicant> applicants = sampleData.GetApplicants();
            SampleInstituteData sampleInstituteData = new SampleInstituteData();
             List<Institute> institutes = sampleInstituteData.GetInstitutes();
            int counter =0;
            foreach(Applicant app in applicants)
            {
               
                counter ++;
                string countString = counter.ToString();
                Console.WriteLine($"counter:{counter} \t");
                if(app==null)
                {
                    Console.WriteLine("null ref");
                }
                new Subscriber(countString, app.FirstName, app.StandardizedTest, pub);
                new Institute(institutes[counter % institutes.Count].InstituteName, pub, institutes[counter % institutes.Count].MinimumScore);
                pub.DoSomething(institutes[counter % institutes.Count]);
                Console.WriteLine("SampleData.application:{0}", app);
            }
// incorporate this Working shuffle into the mail service to randomize letter acceptances
/*            Random rnd = new Random();
            applicants.Shuffle<Applicant>(rnd);
            foreach(var applicant in applicants){
            Console.WriteLine("Post Fish-Yates SampleData.application :{0}", applicant);
            }
  */           
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
    }
}
