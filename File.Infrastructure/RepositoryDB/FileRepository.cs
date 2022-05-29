using File.Infrastructure.DBModel;
using File.Infrastructure.ContextDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public class FileRepository : IFileRepository, IFileObjectRepository
    {
        private readonly FileContext _context;
        public FileRepository(FileContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FileInfoDataBase>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
            return await _context.Files.Include(f => f.FileObj).ToListAsync();
        }

        public async Task<FileInfoDataBase> GetByIdFileAsync(Guid idFile)
        {
            return await _context.Files.FindAsync(idFile);
            return await _context.Files.Include(f => f.FileObj).FirstOrDefaultAsync(f => f.Id == idFile);
        }

        public async Task<FileObjectDataBase> GetByIdFileObjectAsync(Guid idFile)
        {
            return await _context.FilesObject.FindAsync(idFile);
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
        public async Task UpdateFileObjectAsync(FileObjectDataBase file)
        {
            /*if (!fileDb.FileObj.Equals(file.File))
            {
                fileDb.FileObj.File = file.File;
                fileDb.FileObj.FileType = file.FileType;
            }*/
            _context.FilesObject.Update(file);
            await _context.SaveChangesAsync();
        }

        public async Task AddFileObjectAsync(FileObjectDataBase file)
        {
            await _context.FilesObject.AddAsync(file);
            //await _context.AddAsync(file);
            await _context.SaveChangesAsync();
        }
    }
}
