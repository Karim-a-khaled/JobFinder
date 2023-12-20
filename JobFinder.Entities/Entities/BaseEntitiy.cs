using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities
{
    public class BaseEntitiy
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
