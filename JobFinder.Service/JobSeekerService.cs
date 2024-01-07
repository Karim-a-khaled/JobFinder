using JobFinder.Data;
using JobFinder.Entities.DTOs.JobSeekerDTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            if (jobSeeker.JobSeekerProfilePictureId is null)
            {
                var file = new Entities.Entities.File
                {
                    Name = request.JobSeekerProfilePicture.FileName,
                    CreationDate = DateTime.Now,
                    Path = $"jobSeeker-{jobSeeker.Id}/profilePicture/{jobSeeker.JobSeekerProfilePicture.Id}-{jobSeeker.JobSeekerProfilePicture.Name}",
                    ContentType = request.JobSeekerProfilePicture.ContentType
                };
                await _context.Files.AddAsync(file);
            }

            else
            {
                var file = await _context.Files.FirstOrDefaultAsync(f => f.Id == jobSeeker.JobSeekerProfilePictureId);
                file.Name = request.JobSeekerProfilePicture.FileName;
                file.Path = $"jobSeeker-{jobSeeker.Id}/profilePicture/{jobSeeker.JobSeekerProfilePicture.Id}-{jobSeeker.JobSeekerProfilePicture.Name}",
                file.ContentType = request.JobSeekerProfilePicture.ContentType;

                _context.Files.Update(file);
            }

            if (jobSeeker.JobSeekerCvId is null)
            {
                var file = new Entities.Entities.File
                {
                    Name = request.JobSeekerCv.FileName,
                    Path = $"jobSeeker-{jobSeeker.Id}/Cv/{jobSeeker.JobSeekerCv.Id}-{jobSeeker.JobSeekerCv.Name}",
                    CreationDate = DateTime.Now,
                    ContentType = request.JobSeekerCv.ContentType
                };
                await _context.Files.AddAsync(file);
            }
            else
            {

                var file = await _context.Files.FirstOrDefaultAsync(f => f.Id == jobSeeker.JobSeekerCvId);

                file.Name = request.JobSeekerCv.FileName;
                file.Path = $"jobSeeker-{jobSeeker.Id}/Cv/{jobSeeker.JobSeekerCv.Id}-{jobSeeker.JobSeekerCv.Name}";
                file.ModificationDate = DateTime.Now;
                file.ContentType = request.JobSeekerCv.ContentType;
                
                _context.Files.Update(file);
            }

            await _context.SaveChangesAsync();
            return "Updated Succesfuly";
        }
    }
}




