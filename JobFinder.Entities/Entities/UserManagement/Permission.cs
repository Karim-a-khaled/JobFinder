using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities.UserManagement
{
    public class Permission : BaseEntitiy
    {
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
