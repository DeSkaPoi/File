using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain;

namespace File.Infrastructure.RepositoryDB
{
    public interface IFileRepository
    {
        public Task<List<FileManager>> GetAllFilesAsync();
        public Task<FileManager> GetByIdFileAsync(Guid idFile);
        public Task AddFileAsync(FileManager file);
        public Task DeleteFileAsync(Guid idFile);
        public Task UpdateFileAsync(FileManager file);
    }
}
