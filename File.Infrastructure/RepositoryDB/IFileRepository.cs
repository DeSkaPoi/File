using File.Infrastructure.DBModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public interface IFileRepository
    {
        public Task<IReadOnlyList<DBModel.FileInfoDataBase>> GetAllFilesAsync();
        public Task<DBModel.FileInfoDataBase> GetByIdFileAsync(Guid idFile);
        public Task AddFileAsync(DBModel.FileInfoDataBase file);
        public Task DeleteFileAsync(Guid idFile);
        public Task UpdateFileAsync(DBModel.FileInfoDataBase file);
    }
}
