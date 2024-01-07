using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.JobDTOs
{
    public class JobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
