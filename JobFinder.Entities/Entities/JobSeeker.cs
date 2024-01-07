using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class JobSeeker : BaseEntity
    {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsFresh { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        
        public int? JobSeekerProfilePictureId { get; set; }
        public File JobSeekerProfilePicture { get; set; }

        public int? JobSeekerCvId { get; set; }
        public virtual File JobSeekerCv { get; set; }
    }
}
