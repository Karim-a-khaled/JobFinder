using JobFinder.Entities.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities
{
    public class ProfileBaseEntity : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
