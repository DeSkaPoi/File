using File.Infrastructure.DBModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public interface IFileRepository
    {
        public Task<IReadOnlyList<FileInfoDataBase>> GetAllFilesAsync();
        public Task<FileInfoDataBase> GetByIdFileAsync(Guid idFile);
        public Task AddFileAsync(FileInfoDataBase file);
        public Task DeleteFileAsync(Guid idFile);
        public Task UpdateFileAsync(FileInfoDataBase file);
    }
}
