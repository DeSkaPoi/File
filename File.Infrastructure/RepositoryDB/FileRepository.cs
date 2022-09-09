using File.Infrastructure.DBModel;
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
            _context = context;
        }

        public async Task<IReadOnlyList<FileInfoDataBase>> GetAllFilesAsync(Guid idDoc)
        {
            return await _context.Files.Where(f => f.DocumentId == idDoc).Select(f => new FileInfoDataBase(f.Id, f.DocumentId, f.Title, f.Format, f.KeyWords, f.Description, f.ContentType, f.Content,
               f.CreationTime, f.LastUpDate, f.Size, null)).ToListAsync();
        }

        public async Task<FileInfoDataBase> GetByIdFileAsync(Guid idDoc, Guid idFile)
        {
            //return await _context.Files.FindAsync(idFile);
            return await _context.Files.Where(f => f.DocumentId == idDoc).Include(f => f.FileObj)
                .FirstOrDefaultAsync(f => f.Id == idFile);
        }

        public async Task<PayloadFileDataBase> GetByIdPayloadFileAsync(Guid idFile)
        {
            return await _context.PayloadFile.FindAsync(idFile);
        }

        public async Task<Guid> AddFileAsync(FileInfoDataBase file)
        {
            var fileInfoDb = await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return fileInfoDb.Entity.Id;
        }

        public async Task DeleteFileAsync(Guid idFile)
        {
            var file = await _context.Files.Where(f => f.Id == idFile).Include(f => f.FileObj).FirstOrDefaultAsync();
            if (file == null)
            {
                throw new Exception("file is not exist");
            }
            _context.Remove(file);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFileAsync(FileInfoDataBase file)
        {
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
        }

    }
}
