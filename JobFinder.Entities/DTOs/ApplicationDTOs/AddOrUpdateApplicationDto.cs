using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.ApplicationDTOs
{
    public class AddOrUpdateApplicationDto
    {
        public int? Id { get; set; }
        public int JobId { get; set; }
        public bool IsSubmitted { get; set; }
        public string CoverLetter { get; set; }
        public IFormFile File { get; set; }
    }
}
