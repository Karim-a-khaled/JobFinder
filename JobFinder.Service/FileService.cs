using Azure.Core;
using JobFinder.Data;
using JobFinder.Entities.DTOs;
using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Service
{
    public class FileService
    {
        private readonly AppDbContext _context;
        public FileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Entities.File>> GetFiles()
        {
            var files = await _context.Files.ToListAsync();
            if (files is null)
                return null;

            return files;
        }

        public async Task<Entities.Entities.File> GetFile(int id)
        {
            var file = await _context.Files.FirstOrDefaultAsync(js => js.Id == id);
            if (file is null)
                return null;

            return file;
        }

        public async Task<string> DeleteFile(int id)
        {
            var file = _context.Files.FirstOrDefault(a => a.Id == id);
            if (file is null)
                return null;

            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
            return "Deleted Succesfuly";
        }
        public async Task<string> AddFile(AddOrUpdateFileDto request)
        {
            var fileToAdd = await _context.Files.FirstOrDefaultAsync(f => f.Name == request.Name && f.Path == request.Path);

            if (fileToAdd is not null)
                return null;

            fileToAdd = new Entities.Entities.File
            {
                Name = request.Name,
                Path = request.Path,
                CreationDate = DateTime.Now,
            };

            await _context.Files.AddAsync(fileToAdd);
            await _context.SaveChangesAsync();
            return "Added Succesfuly";
        }

        public async Task<string> UpdateFile(AddOrUpdateFileDto request)
        {
            var fileToUpdate = await _context.Files.FirstOrDefaultAsync(f => f.Name == request.Name && f.Path == request.Path);

            if (fileToUpdate is null)
                return null;

            fileToUpdate = new Entities.Entities.File
            {
                Name = request.Name,
                Path = request.Path,
                ModificationDate = DateTime.Now,
            };

            _context.Files.Update(fileToUpdate);
            await _context.SaveChangesAsync();
            return "Updated Succesfuly";
        }
    }
}
