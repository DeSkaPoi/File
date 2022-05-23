using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Converters;
using File.Domain.Model;
using File.Infrastructure.RepositoryDB;
using FileManagement.Converters;
using FileManagement.Services;

namespace File.Domain.Services
{
    public class FileServices : IFileServices
    {
        private readonly IFileRepository _repository;

        public FileServices(IFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<FileInformation>> GetFilesAsync()
        {
            var filesDb = await _repository.GetAllFilesAsync();
            var filesModel = filesDb.ConvertToModel();
            return filesModel;
        }

        public async Task<FileInformation> GetFileAsync(Guid id)
        {
            var fileDb = await _repository.GetByIdFileAsync(id);
            if (fileDb == null)
            {
                return null;
            }
            var filesModel = fileDb.ConvertToModel();
            return filesModel;
        }

        public async Task<FileInformation> GetFileObjectAsync(Guid id)
        {
            var fileDb = await _repository.GetByIdFileObjectAsync(id);
            if (fileDb == null)
            {
                return null;
            }
            var filesModel = fileDb.ConvertToModel();
            return filesModel;
        }

        public async Task ChangeFileAsync(Guid id, FileInformation file)
        {
            if (id != file.Id)
            {
                throw new Exception("No match between id and object");
            }
             
            await _repository.UpdateFileAsync(file.ConvertToDataBase());
        }

        public async Task ChangeFileObjectAsync(Guid idFileInfo, MemoryStream ms)
        {
            var fileObject = new FileObject(idFileInfo, ms.ToArray());
            await _repository.UpdateFileObjectAsync(fileObject.ConvertToDataBase());
        }

        public async Task AddFileObjectAsync(Guid idFileInfo, MemoryStream ms)
        {
            var fileObject = new FileObject(idFileInfo, ms.ToArray());
            await _repository.AddFileObjectAsync(fileObject.ConvertToDataBase(), fileObject.IdFileInfo);
        }

        public async Task AddFileAsync(FileInformation file)
        {
            await _repository.AddFileAsync(file.ConvertToDataBase());
        }

        public async Task<IReadOnlyList<Guid>> DeleteFiles(IReadOnlyList<Guid> ids)
        {
            var NoneDeleteGuid = new List<Guid>();
            int i = 0;
            try
            {
                for (; i < ids.Count; i++)
                {
                    await _repository.DeleteFileAsync(ids[i]);
                }
            }
            catch (Exception)
            {
                NoneDeleteGuid.Add(ids[i]);
            }

            return NoneDeleteGuid;
        }

        public async Task DeleteFile(Guid id)
        { 
            await _repository.DeleteFileAsync(id);
        }
    }
}
