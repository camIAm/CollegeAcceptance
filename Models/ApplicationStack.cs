using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ApplicationStack
    {
        public Stack<Applicant> ApplicantStack {get; set;}
        public ApplicationStack()
        {
            ApplicantStack = ApplicantStack ?? new Stack<Applicant>();
        }
    }
}