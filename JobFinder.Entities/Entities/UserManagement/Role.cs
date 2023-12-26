using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities.UserManagement
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public int? Timer { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public Enums.RoleEnum RoleType { get; set; }
    }
}
