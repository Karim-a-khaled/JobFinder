using JobFinder.Data;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Service
{
    public class JobSeekerService
    {
        private readonly AppDbContext _context;

        public JobSeekerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobSeeker>> GetJobSeekers()
        {
            var jobSeekers = await _context.JobSeekers.ToListAsync();
            if (jobSeekers is null)
                return null;

            return jobSeekers;
        }

        public async Task<JobSeeker> GetJobSeeker(int id)
        {
            var jobSeeker = await _context.JobSeekers.FirstOrDefaultAsync(js => js.Id == id);
            if (jobSeeker is null)
                return null;

            return jobSeeker;
        }
    }
}
