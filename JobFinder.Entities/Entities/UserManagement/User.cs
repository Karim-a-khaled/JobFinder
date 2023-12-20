using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities.UserManagement
{
    public class User : BaseEntitiy
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isCompany { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public int? JobSeekerId { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company{ get; set; }

    }
}
