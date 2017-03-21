using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Applicants
    {
        public Stack<Applicant> _applicantStack;
        public Stack<Applicant> ApplicantStack {get; set;}
        //{
         //get { return _applicantStack;}
         //set {  _applicantStack = value ?? new Stack<Applicant>();}
         //} 
        public Applicants()
        {
            ApplicantStack = _applicantStack ?? new Stack<Applicant>();
            /* 
            if(ApplicantStack == null)
            {
                ApplicantStack = new Stack<Applicant>();
            }
            */
        }
    }
}