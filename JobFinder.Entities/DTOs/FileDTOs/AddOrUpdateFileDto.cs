using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.FileDTOs
{
    public class AddOrUpdateFileDto
    {
        public int? Id { get; set; }
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string FileId { get; set; }
        public string Path { get; set; }
        public IFormFile File { get; set; }
    }
}
