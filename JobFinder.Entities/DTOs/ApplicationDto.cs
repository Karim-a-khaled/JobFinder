using Microsoft.AspNetCore.Http;

namespace JobFinder.Entities.DTOs
{
    public class ApplicationDto
    {
        public int? Id { get; set; }
        public int JobId { get; set; }
        public IFormFile File { get; set; }
    }
}
