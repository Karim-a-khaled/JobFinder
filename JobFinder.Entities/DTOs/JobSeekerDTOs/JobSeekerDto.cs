using Microsoft.AspNetCore.Http;

namespace JobFinder.Entities.DTOs.JobSeekerDTOs
{
    public class JobSeekerDto
    {
        public string Name { get; set; }
        public bool IsFresh { get; set; }
        public int YearsOfExperience { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public IFormFile ResumeFile { get; set; }
    }
}
