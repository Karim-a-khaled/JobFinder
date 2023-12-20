using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Enums
{
    public enum RoleEnum : int
    {
        [EnumDisplay("JobSeeker")]
        JobSeeker = 1,

        [EnumDisplay("Employer")]
        Employer = 2,
    }
}
