using JobFinder.Entities.DTOs;
using JobFinder.Entities.Entities;
using JobFinder.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            var applications = await _applicationService.GetApplications();
            if (applications is null)
                return NotFound("Applications Were Not Found");

            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            // Retrieve the application with the specified ID
            var application = await _applicationService.GetApplication(id);

            if (application is null)
                return NotFound("Application Was Not Found");

            return Ok(application);
        }

        [HttpPost]
        public async Task<ActionResult<Application>> AddAppplication(ApplicationDto applicationDto)
        {
            var applicationToAdd = await _applicationService.AddApplication(applicationDto);
            if (applicationToAdd is null)
                return BadRequest("Failed To Add The Application");

            return Ok(applicationToAdd);
        }
    }
}
