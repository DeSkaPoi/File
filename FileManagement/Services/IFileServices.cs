using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Model;

namespace FileManagement.Services
{
    public interface IFileServices
    {
        public Task<IReadOnlyList<FileInformation>> GetFilesAsync();
        public Task<FileInformation> GetFileAsync(Guid id);
        public Task ChangeFileAsync(Guid id, FileInformation file);
        public Task AddFileAsync(FileInformation file);
        public Task<IReadOnlyList<Guid>> DeleteFiles(IReadOnlyList<Guid> ids);
        public Task DeleteFile(Guid id);
        public Task ChangeFileObjectAsync(Guid idFileInfo, MemoryStream ms);
        public Task AddFileObjectAsync(Guid idFileInfo, MemoryStream ms);
        public Task<FileInformation> GetFileObjectAsync(Guid id);
    }
}
