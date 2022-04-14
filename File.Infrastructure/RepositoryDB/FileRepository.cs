using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using File.Domain;
using File.Infrastructure.ContextDB;

namespace File.Infrastructure.RepositoryDB
{
    public class FileRepository : IFileRepository
    {
        private readonly FileContext context;
        public FileRepository(FileContext context)
        {
            this.context = context;
        }

        public async Task<List<FileManager>> GetAllFilesAsync()
        {
            return await context.Files.Where(file => file.BelongDocument == false).ToListAsync();
        }

        public async Task<FileManager> GetByIdFileAsync(Guid idFile)
        {
            return await context.Files.FindAsync(idFile);
        }

        public async Task AddFileAsync(FileManager file)
        {
            file.CreationTime = DateTime.Now;
            await context.AddAsync(file);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFileAsync(Guid idFile)
        {
            FileManager file = await context.Files.FindAsync(idFile);
            if (file == null)
            {
                throw new Exception("file is not exist");
            }
            context.Remove(file);
            await context.SaveChangesAsync();
        }
        public async Task UpdateFileAsync(FileManager file)
        {
            file.LastUpDate = DateTime.Now;
            context.Update(file);
            await context.SaveChangesAsync();
        }
    }
}
