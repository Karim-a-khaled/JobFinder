using JobFinder.Data;
using JobFinder.Entities.DTOs.ApplicationDTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Service
{

    public class ApplicationService
    {
        private readonly AppDbContext _context;
        public ApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetApplications()
        {
            var applications = await _context.Applications.ToListAsync();
            return applications;
        }

        public async Task<Application> GetApplication(int id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
            if (application is null)
                return null;

            return application;
        }

        public async Task<Application> AddApplication(AddOrUpdateApplicationDto applicationDto)
        {
            var existingApplication = await _context.Applications.FindAsync();

            if (existingApplication != null)
            {
                throw new Exception("A job application with the same title and description already exists.");
            }

            var applicationToAdd = new Application
            {
                CoverLetter = applicationDto.CoverLetter,
                CreationDate = DateTime.Now.Date
            };

            await _context.AddAsync(applicationToAdd);
            await _context.SaveChangesAsync();

            return applicationToAdd;
        }

        public async Task<string> DeleteApplication(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.Id == id);
            if (application is null)
                return null;

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return "Deleted Succesfuly";
        }
    }
}
