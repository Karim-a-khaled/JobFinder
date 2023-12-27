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
    public class CompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompanies()
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

    }
}
