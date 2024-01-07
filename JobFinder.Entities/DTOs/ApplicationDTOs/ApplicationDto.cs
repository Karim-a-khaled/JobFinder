using JobFinder.Entities.DTOs;
using JobFinder.Entities.DTOs.JobDTOs;
using JobFinder.Entities.DTOs.JobSeekerDTOs;

namespace JobFinder.Entities.DTOs.ApplicationDTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public JobSeekerDto JobSeeker { get; set; }
        public int JobSeekerId { get; set; }
        public JobDto Job { get; set; }
        public int JobId { get; set; }
    }
}
