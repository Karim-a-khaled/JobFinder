using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class JobSeeker : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsFresh { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public File File { get; set; }
    }
}
