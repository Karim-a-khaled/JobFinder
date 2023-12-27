using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities.UserManagement
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsCompany { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
