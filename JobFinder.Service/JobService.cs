using JobFinder.Data;
using JobFinder.Entities.DTOs;
using JobFinder.Entities.DTOs.JobDTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Service
{
    public class JobService
    {
        private readonly AppDbContext _context;
        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobs()
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

        public async Task<string> AddOrUpdateJob(JobDto jobDto)
        {
            var company = await _context.Companies.FindAsync(jobDto.CompanyId);
            if (company is null)
                return null;

            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Title == jobDto.Title && j.Description == jobDto.Description);

            if (job is not null)
            {
                job.Title = jobDto.Title;
                job.Description = jobDto.Description;
                job.CompanyId = company.Id;
                job.ModificationDate = DateTime.Now.Date;

                _context.Jobs.Update(job);
                await _context.SaveChangesAsync();
                return "Updated Succesfully";
            }
            else
            {
                job = new Job
                {
                    Title = jobDto.Title,
                    Description = jobDto.Description,
                    //CompanyId = jobDto.CompanyId,
                    CreationDate = DateTime.Now.Date,
                };

                await _context.Jobs.AddAsync(job);
                await _context.SaveChangesAsync();

                return "Added Succesfully";
            }
        }

        public async Task<string> DeleteJob(int id)
        {
            var job = _context.Jobs.FirstOrDefault(a => a.Id == id);
            if (job is null)
                return null;

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return "Deleted Succesfuly";
        }
    }
}
