using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Enums
{
    public enum ErrorEnum : int
    {

        [EnumDisplay("SUCCESS")]
        Success = 0,

        [EnumDisplay("FAILED")]
        Failed = 1,

        
    }
}
