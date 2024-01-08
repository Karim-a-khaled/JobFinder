using JobFinder.Entities.DTOs;
using JobFinder.Entities.DTOs.FileDTOs;
using JobFinder.Entities.Entities;
using JobFinder.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;
        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Entities.File>> GetFile(int id)
        {
            var file = await _fileService.GetFileById(id);
            if (file is null)
                return NotFound("File Not Found");

            return Ok(file);
        }
    }
}
