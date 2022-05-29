using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Model;

namespace FileManagement.Services
{
    public interface IFileObjectService
    {
        public Task ChangeFileObjectAsync(FileObject file);
        public Task AddFileObjectAsync(FileObject file);
        public Task<FileObject> GetFileObjectAsync(Guid id);
    }
}
