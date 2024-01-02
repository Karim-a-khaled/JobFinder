using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class JobSeeker : ProfileBaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsFresh { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        
        public int? JobSeekerProfilePhotoId { get; set; }
        public File JobSeekerProfilePhoto { get; set; }

        public int? JobSeekerCvId { get; set; }
        public virtual File JobSeekerCv { get; set; }
    }
}
