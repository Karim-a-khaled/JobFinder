using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs
{
    public class FileDto
    {
        public IFormFile CVFile { get; set; }

    }
}
