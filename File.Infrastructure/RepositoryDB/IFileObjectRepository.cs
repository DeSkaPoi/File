using File.Infrastructure.DBModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public interface IFileObjectRepository
    {
        public Task UpdateFileObjectAsync(FileObjectDataBase file);
        public Task AddFileObjectAsync(FileObjectDataBase file);
        public Task<FileObjectDataBase> GetByIdFileObjectAsync(Guid idFile);
    }
}
