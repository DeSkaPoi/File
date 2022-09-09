using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using File.Domain.Model;

namespace File.Domain.Services
{
    public interface IFileService
    {
        public Task<IReadOnlyList<FileInformation>> GetFilesAsync(Guid idDoc);
        public Task<FileInformation> GetFileAsync(Guid idDoc, Guid idFile);
        public Task ChangeFileAsync(Guid id, FileInformation file);
        public Task<Guid> AddFileAsync(FileInformation file);
        public Task<IReadOnlyList<Guid>> DeleteFilesAsync(IReadOnlyList<Guid> ids);
        public Task DeleteFileAsync(Guid id);
    }
}
