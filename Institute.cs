using System;

namespace ConsoleApplication
{
    public class Institute
    {
        internal string InstituteName{get;set;}
        public Institute(){}
        public Institute(string instituteName, Publisher pub)
        {
            InstituteName = instituteName;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        void HandleCustomEvent(object sender, AcceptanceLetter e)
        {  
            Console.WriteLine( "applicant:{0} would like to attend your school \n e.Message:{1}\n" , InstituteName, e.Message);
        }
    }

}
