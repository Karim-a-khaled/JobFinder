using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public int? CompanyProfilePhotoId { get; set; }
        public virtual File CompanyProfilePhoto { get; set; }
    }
}
