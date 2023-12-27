using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] CvFile { get; set; }

        public string JobSeekerId { get; set; } 
        public JobSeeker JobSeeker { get; set; }
    }
}
