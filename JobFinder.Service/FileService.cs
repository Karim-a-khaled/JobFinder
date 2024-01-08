using Azure.Core;
using JobFinder.Data;
using JobFinder.Entities.DTOs;
using JobFinder.Entities.DTOs.FileDTOs;
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
        private readonly UserService _userService;

        public FileService(AppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task UpdateFile(AddOrUpdateFileDto file)
        {
            var userId = (int)_userService.GetUserId();
            var profilePictureFile = await _context.Files.FindAsync(file.Id);
            if (profilePictureFile is null)
                throw new Exception("Invalid Profile Picture Id");

            profilePictureFile.Path = file.Path;
            profilePictureFile.Name = file.Name;
            profilePictureFile.ModificationDate = DateTime.Now.Date;
            profilePictureFile.ModifiedById = userId;

            _context.Update(profilePictureFile);
            await _context.SaveChangesAsync();

            string currentDirectory = Directory.GetCurrentDirectory();

            var pathToSave = Path.Combine(currentDirectory, file.Path);
            Directory.CreateDirectory(Path.GetDirectoryName(pathToSave));
            await using var fileStream = new FileStream(pathToSave, FileMode.Create);
            await file.File.CopyToAsync(fileStream);
        }

       
        // Done
        public async Task<Entities.Entities.File> AddFile(AddOrUpdateFileDto file)
        {
            var userId = (int)_userService.GetUserId();
            var fileToCreate = new Entities.Entities.File
            {
                Name = file.Name,
                FileId = file.FileId,
                Path = file.Path,
                CreatedById = userId,
                CreationDate = DateTime.Now.Date,
                ContentType = file.File.ContentType
            };
            // Save File in the DB
            await _context.Files.AddAsync(fileToCreate);
            await _context.SaveChangesAsync();

            // Save File Locally
            string currentDirectory = Directory.GetCurrentDirectory();
            var pathToSave = Path.Combine(currentDirectory, file.Path);
            Directory.CreateDirectory(Path.GetDirectoryName(pathToSave));

            await using var fileStream = new FileStream(pathToSave, FileMode.Create);
            await file.File.CopyToAsync(fileStream);

            return fileToCreate;
        }

        public async Task<FileDto> GetFileById(int id)
        {
            var file = await _context.Files.FindAsync(id);
            if (file == null)
                throw new Exception("File Does Not Exist");

            byte[] existingContent;
            using (var existingFileStream = new FileStream(file.Path, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await existingFileStream.CopyToAsync(memoryStream);
                    existingContent = memoryStream.ToArray();
                }
            }
            return new FileDto
            {
                Content = existingContent,
                ContentType = file.ContentType
            };
        }
    }
}
