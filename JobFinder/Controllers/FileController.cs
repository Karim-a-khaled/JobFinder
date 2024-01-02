using JobFinder.Entities.DTOs;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Entities.File>>> GetFiles()
        {
            var files = await _fileService.GetFiles();
            if (files is null)
                return NotFound("Files Were Not Found");

            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Entities.File>> GetFile(int id)
        {
            var file = await _fileService.GetFile(id);
            if (file is null)
                return NotFound("File Not Found");

            return Ok(file);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteFile(int id)
        {
            var company = _fileService.DeleteFile(id);
            if (company is null)
                return NotFound("File Was Not Found");

            return Ok("File Was Deleted Successfuly");
        }

        [HttpPost()]
        public async Task<ActionResult<string>> AddFile(AddOrUpdateFileDto request)
        {
            var file = await _fileService.AddFile(request);
            if (file is null)
                return NotFound("File Already Exist");

            return Ok("Added Succesfully");
        }

        [HttpPut()]
        public async Task<ActionResult<string>> UpdateCompany(AddOrUpdateFileDto request)
        {
            var file = await _fileService.UpdateFile(request);
            if (file is null)
                return NotFound("File Was Not Found");

            return Ok("Updated Succesfully");
        }
    }
}
