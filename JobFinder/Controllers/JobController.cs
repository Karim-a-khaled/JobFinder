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
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;
        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetApplications()
        {
            var jobs = await _jobService.GetJobs();
            
            if (jobs is null)
                return NotFound("Jobs Were Not Found");

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            // Retrieve the application with the specified ID
            var job = await _jobService.GetJob(id);

            if (job is null)
                return NotFound("Job Was Not Found");

            return Ok(job);
        }

        [HttpPost()]
        public async Task<ActionResult<string>> AddOrUpdateJob([FromBody] JobDto jobDto)
        {
            var result = await _jobService.AddOrUpdateJob(jobDto);

            if (result == "Company Was Not Found")
                return NotFound(result);

            return Ok(result);
        }
    }
}
