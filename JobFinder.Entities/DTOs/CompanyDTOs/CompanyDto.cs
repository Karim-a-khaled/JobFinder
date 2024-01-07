using JobFinder.Entities.DTOs.FileDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.CompanyDTOs
{
    public class CompanyDto
    {
        public string CompanyName { get; set; }
        public string AboutUs { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public FileDto CompanyProfilePicture { get; set; }
    }
}
