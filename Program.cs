using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class AcceptanceLetter:EventArgs
    {
        readonly string greeting = "Congrats";
        private string message;
        public string Message {get; set;}
        public Institute Institute;
        public AcceptanceLetter(Institute institute)
        {
            message = greeting;
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
        //private List<string> _applicantsNames = new List<string>();
        //private Stack<string> _applicantsNames;// = new Stack<string>();
        public Subscriber(string id, string applicant,int score, Publisher pub){
            _id = id;
            _applicant = applicant;
            //_applicantsNames.Push(_applicant);
            _score = score;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            Console.WriteLine("applicant #:{3} \n For: {0}\n {1}\n You were accepted based on your standardized score of {2} " , _applicant, e.Message, _score, _id);
            //System.Console.WriteLine("List of applicants {0}",_applicantsNames.Count);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Applicants applicantTotalList = new Applicants();
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
                applicantTotalList.ApplicantStack.Push(app);
                if(app==null)
                {
                    Console.WriteLine("null ref");
                }
                new Subscriber(countString, app.FirstName, app.StandardizedTest, pub);
                new Institute(institutes[counter % institutes.Count].InstituteName, pub, institutes[counter % institutes.Count].MinimumScore);
                pub.DoSomething(institutes[counter % institutes.Count]);
                System.Console.WriteLine($"Applicants Stack {applicantTotalList.ApplicantStack.Count}");
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
