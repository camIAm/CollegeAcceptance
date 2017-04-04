using System;

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
}