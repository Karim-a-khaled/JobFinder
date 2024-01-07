using JobFinder.Data;
using JobFinder.Entities.DTOs.CompanyDTOs;
using JobFinder.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using File = JobFinder.Entities.Entities.File;

namespace JobFinder.Service
{
    public class CompanyService
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            if (companies is null)
                return null;

            return companies;
        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(js => js.Id == id);
            if (company is null)
                return null;

            return company;
        }

        public async Task<string> DeleteCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(a => a.Id == id);
            if (company is null)
                return null;

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return "Deleted Succesfuly";
        }

        public async Task<string> UpdateCompany(UpdateCompanyDto request)
        {
            var company = _context.Companies.FirstOrDefault(a => a.UserId == request.UserId);
            if (company is null)
                return null;

            company.PhoneNumber = request.PhoneNumber;
            company.Address = request.Address;
            company.Name = request.Name;
            company.PhoneNumber = request.PhoneNumber;
            company.CreationDate = DateTime.Now;

            var file = new File
            {
                Name = request.CompanyProfilePhoto.FileName,
                // Path
                CreationDate = DateTime.Now,
            };
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            company.CompanyProfilePictureId = file.Id;
            
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return "Updated Succesfuly";
        }
    }
}
