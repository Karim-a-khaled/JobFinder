using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
