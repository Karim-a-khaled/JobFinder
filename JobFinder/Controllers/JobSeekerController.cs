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
    public class JobSeekerController : ControllerBase
    {
        private readonly JobSeekerService _jobSeekerService;
        public JobSeekerController(JobSeekerService jobSeekerService)
        {
            _jobSeekerService = jobSeekerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSeeker>>> GetApplications()
        {
            var jobSeekers = await _jobSeekerService.GetJobSeekers();
            
            if (jobSeekers is null)
                return NotFound("Job Seekers Were Not Found");

            return Ok(jobSeekers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeeker>> GetJobSeeker(int id)
        {
            var jobSeeker = await _jobSeekerService.GetJobSeeker(id);
            
            if (jobSeeker is null)
                return NotFound("Job Seeker Not Found");

            return Ok(jobSeeker);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteJobSeeker(int id)
        {
            var jobSeeker = _jobSeekerService.DeleteJobSeeker(id);
            if (jobSeeker is null)
                return NotFound("JobSeeker Was Not Found");

            return Ok(jobSeeker);
        }

        [HttpPut()]
        public async Task<ActionResult<string>> UpdateJobSeeker(UpdateJobSeekerDto request)
        {
            var jobSeeker = await _jobSeekerService.UpdateJobSeeker(request);
            if (jobSeeker is null)
                return NotFound("JobSeeker Was Not Found");

            return Ok("Updated Succesfully");
        }
    }


}
