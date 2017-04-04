using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class DataFactory
    {
        Dictionary<DataSource,Lazy<ILoadApplicants>> _loadApplicantSource;
        public DataFactory(Dictionary<DataSource,Lazy<ILoadApplicants>> loadApplicantSource)
        {
            _loadApplicantSource = loadApplicantSource;
        }
        public ILoadApplicants GetApplicantSource(DataSource dataSource)
        {
            Lazy<ILoadApplicants> applicantValue;
            if(!_loadApplicantSource.TryGetValue(dataSource, out applicantValue))
            {
                throw new NotSupportedException("From DataFactory");
            }
            return applicantValue.Value;
        }
    }
}