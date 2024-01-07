using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.Entities.DTOs.CompanyDTOs
{
    public class UpdateCompanyDto
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int? CompanyProfilePhotoId { get; set; }
        public IFormFile CompanyProfilePhoto { get; set; }
    }
}
