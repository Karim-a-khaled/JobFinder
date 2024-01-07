using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.JobDTOs
{
    public class AddOrUpdateJobDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
