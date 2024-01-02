using JobFinder.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs
{
    public class UpdateCompanyDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int? CompanyProfilePhotoId { get; set; }
        public IFormFile CompanyProfilePhoto { get; set; }

    }
}
