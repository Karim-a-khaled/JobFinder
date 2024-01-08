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
            var companies = await _context.Companies
                .Include(c => c.CompanyProfilePicture)
                .ToListAsync();
            if (companies is null)
                return null;

            return companies;
        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companies
                .Include (c => c.CompanyProfilePicture)
                .FirstOrDefaultAsync(c => c.Id == id);
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
            
            if(company.CompanyProfilePictureId is null || company.CompanyProfilePictureId == 0)
            {
                var file = new File
                {
                    Name = request.CompanyProfilePicture.FileName,
                    Path = $"company-{company.Id}/profilePicture/{company.CompanyProfilePicture.Id}_{company.CompanyProfilePicture.Name}",
                    CreationDate = DateTime.Now,
                    ContentType = request.CompanyProfilePicture.ContentType
                };
                await _context.Files.AddAsync(file);
            }
            else
            {
                var file = _context.Files.FirstOrDefault(f => f.Id == company.CompanyProfilePictureId);
                file.Name = request.CompanyProfilePicture.FileName;
                file.Path = $"company-{company.Id}/profilePicture/{company.CompanyProfilePicture.Id}_{company.CompanyProfilePicture.Name}";
                file.ModificationDate = DateTime.Now;
                file.ContentType = request.CompanyProfilePicture.ContentType;
                _context.Files.Update(file);
            }

            await _context.SaveChangesAsync();
            
            return "Updated Succesfuly";
        }
    }
}
