using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities
{
    public class Application : BaseEntitiy
    {
        public string CoverLetter { get; set; }
        public int MyProperty { get; set; }

        public int JobSeekerId { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
