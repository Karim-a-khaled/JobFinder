using JobFinder.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Service
{
    public class UserFactory
    {
        public ProfileBaseEntity DeterminUser(bool isCompany)
        {
            if (isCompany)
                return new Company();
            

            else if(!isCompany)
                return new JobSeeker();

            return null;
        }
    }
}
