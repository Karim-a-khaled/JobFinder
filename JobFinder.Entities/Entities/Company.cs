using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobFinder.Entities.Entities.UserManagement;

namespace JobFinder.Entities.Entities
{
    public class Company : BaseEntitiy
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
