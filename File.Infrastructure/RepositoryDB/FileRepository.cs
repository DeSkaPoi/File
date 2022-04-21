using File.Domain;
using File.Infrastructure.ContextDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public class FileRepository : IFileRepository
    {
        private readonly FileContext _context;
        public FileRepository(FileContext context)
        {
            this._context = context;
        }

        public async Task<IReadOnlyList<FileManager>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<FileManager> GetByIdFileAsync(Guid idFile)
        {
            return await _context.Files.FindAsync(idFile);
        }

        public async Task AddFileAsync(FileManager file)
        {
            file.CreationTime = DateTime.Now;
            await _context.AddAsync(file);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFileAsync(Guid idFile)
        {
            FileManager file = await _context.Files.FindAsync(idFile);
            if (file == null)
            {
                throw new Exception("file is not exist");
            }
            _context.Remove(file);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFileAsync(FileManager file)
        {
            file.LastUpDate = DateTime.Now;
            _context.Update(file);
            await _context.SaveChangesAsync();
        }
    }
}
