using System;

namespace ConsoleApplication
{
    public class Subscriber
    {
        internal string Applicant{ get; set; }
        internal int Score{ get; set; }
        public Subscriber(Publisher pub)
        {
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            System.Console.WriteLine("From Subscriber.HandleCustomeEvent:");
            System.Console.WriteLine($"\t Type:ConsoleApplication.Institute \n\t\t e.Message: {e.Message} e.Institute: {e.Institute}");
            System.Console.WriteLine($"\t ConsoleApplication.Publisher.Subscriber \n\t\t _applicant: {Applicant}, _score: {Score}");
            //Console.WriteLine("applicant #:{3} \n For: {0}\n {1}\n You were accepted based on your standardized score of {2} " , _applicant, e.Message, _score, _id);
            //System.Console.WriteLine("List of applicants {0}",_applicantsNames.Count);
        }
    }
}