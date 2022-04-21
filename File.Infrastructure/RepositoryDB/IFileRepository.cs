using File.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public interface IFileRepository
    {
        public Task<IReadOnlyList<FileManager>> GetAllFilesAsync();
        public Task<FileManager> GetByIdFileAsync(Guid idFile);
        public Task AddFileAsync(FileManager file);
        public Task DeleteFileAsync(Guid idFile);
        public Task UpdateFileAsync(FileManager file);
    }
}
