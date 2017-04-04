using System;

namespace ConsoleApplication
{
    public class Institute
    {
        internal string InstituteName{ get;set; } 
        public int MinimumScore{ get;set; }
        public Institute(){}
        public Institute(Publisher pub)
        {
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            System.Console.WriteLine("ConsoleApplication.Institute");
            Console.WriteLine( "Letter to applicant:{0} would like you to attend their school as of {1}\n" , InstituteName, e.Message);
        }
    }

}
