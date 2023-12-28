using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
