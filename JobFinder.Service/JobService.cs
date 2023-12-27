using JobFinder.Data;
using JobFinder.Entities.DTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Service
{
    public class JobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            if (jobs is null)
                return null;

            return jobs;
        }

        public async Task<Job> GetJob(int id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (job is null)
                return null;

            return job;
        }

        public async Task<Job> AddJob(JobDto jobDto)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Title == jobDto.Title
                        && j.Description == jobDto.Description);

            if (job is not null)
                throw new Exception("job is already exist");

            job = new Job
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
            };

            return job;
        }
    }
}
