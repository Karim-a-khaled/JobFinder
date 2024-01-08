using Microsoft.AspNetCore.Http;

namespace JobFinder.Entities.DTOs.JobSeekerDTOs
{
    public class JobSeekerDto
    {
        public string Name { get; set; }
        public bool IsFresh { get; set; }
        public int YearsOfExperience { get; set; }
        public IFormFile JobSeekerProfilePicture { get; set; }
        public IFormFile JobSeekerCv { get; set; }
    }
}
