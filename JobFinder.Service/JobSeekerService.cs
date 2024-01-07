using JobFinder.Data;
using JobFinder.Entities.DTOs.JobSeekerDTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Service
{
    public class JobSeekerService
    {
        private readonly AppDbContext _context;
        public JobSeekerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobSeeker>> GetJobSeekers()
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

        public async Task<string> DeleteJobSeeker(int id)
        {
            var jobSeeker = _context.JobSeekers.FirstOrDefault(a => a.Id == id);
            if (jobSeeker is null)
                return null;

            _context.JobSeekers.Remove(jobSeeker);
            await _context.SaveChangesAsync();
            return "Deleted Succesfuly";
        }

        public async Task<string> UpdateJobSeeker(UpdateJobSeekerDto request)
        {
            var jobSeeker = _context.JobSeekers.FirstOrDefault(a => a.Id == request.Id);
            
            if (jobSeeker is null)
                return null;
            
            jobSeeker.Name = request.Name;
            jobSeeker.YearsOfExperience = request.YearsOfExperience;
            jobSeeker.IsFresh = request.IsFresh;
            jobSeeker.CreationDate = DateTime.Now;

            if (jobSeeker.JobSeekerProfilePhotoId is null)
            {
                var file = new Entities.Entities.File
                {
                    Name = request.JobSeekerProfilePicture.FileName,
                    CreationDate = DateTime.Now,

                };
                await _context.Files.AddAsync(file);
                jobSeeker.JobSeekerProfilePhotoId = file.Id;
            }
            else
            {
                var file = await _context.Files.FirstOrDefaultAsync(f => f.Id == jobSeeker.JobSeekerProfilePhotoId);
                file.Name = request.JobSeekerProfilePicture.FileName;
                //file.Path = 
                
                _context.Files.Update(file);
                jobSeeker.JobSeekerProfilePhotoId = file.Id;
            }

            if (jobSeeker.JobSeekerCvId is null)
            {
                var file = new Entities.Entities.File
                {
                    Name = request.CvFile.FileName,
                    //Path = 
                    CreationDate = DateTime.Now,
                };
                await _context.Files.AddAsync(file);
                jobSeeker.JobSeekerCvId = file.Id;
            }
            else
            {
                
                var file = await _context.Files.FirstOrDefaultAsync(f => f.Id == jobSeeker.JobSeekerCvId);
                file.Name = request.CvFile.FileName;
                //file.Path = 

                _context.Files.Update(file);
                jobSeeker.JobSeekerCvId = file.Id;

            }
            await _context.SaveChangesAsync();
            _context.JobSeekers.Update(jobSeeker);
            await _context.SaveChangesAsync();
            return "Updated Succesfuly";
        }
    }
}
