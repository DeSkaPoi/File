using System;
using System.Collections.Generic;
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
        public Task ChangeFileManagerAsync(Guid id, FileInformation file);
        public Task PostFileManagerAsync(FileInformation file);
        public Task<IReadOnlyList<Guid>> DeleteFileManagerRange(IReadOnlyList<Guid> ids);
        public Task DeleteFileManager(Guid id);
    }
}
