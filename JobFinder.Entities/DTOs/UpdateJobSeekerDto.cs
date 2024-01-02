using Microsoft.AspNetCore.Http;

namespace JobFinder.Entities.DTOs
{
    public class UpdateJobSeekerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public int UserId { get; set; }
        public bool IsFresh { get; set; }
        public int? JobSeekerProfilePhotoId { get; set; }
        public int? JobSeekerCvId { get; set; }
        public IFormFile CVFile { get; set; }
        public IFormFile JobSeekerProfilePhoto { get; set; }

    }
}
