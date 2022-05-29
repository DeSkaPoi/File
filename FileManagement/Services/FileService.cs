using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Model;
using File.Infrastructure.DBModel;
using File.Infrastructure.RepositoryDB;
using FileManagement.Converters;
using FileManagement.Services;

namespace File.Domain.Services
{
    public class FileService : IFileService, IFileObjectService
    {
        private readonly IFileRepository _repositoryInfo;
        private readonly IFileObjectRepository _repositoryObject;

        public FileService(IFileRepository repository, IFileObjectRepository repositoryObject)
        {
            _repositoryInfo = repository;
            _repositoryObject = repositoryObject;
        }

        public async Task<IReadOnlyList<FileInformation>> GetFilesAsync()
        {
            var filesDb = await _repositoryInfo.GetAllFilesAsync();
            var filesModel = filesDb.ConvertToModel();
            return filesModel;
        }

        public async Task<FileInformation> GetFileAsync(Guid id)
        {
            var fileDb = await _repositoryInfo.GetByIdFileAsync(id);
            if (fileDb == null)
            {
                return null;
            }
            var filesModel = fileDb.ConvertToModel();
            return filesModel;
        }

        public async Task<FileObject> GetFileObjectAsync(Guid id)
        {
            var fileDb = await _repositoryObject.GetByIdFileObjectAsync(id);
            if (fileDb == null)
            {
                throw new Exception($"file with this key: {id} does not exist");
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
             
            await _repositoryInfo.UpdateFileAsync(file.ConvertToDataBase());
        }

        public async Task ChangeFileObjectAsync(FileObject file)
        {
            var fileDb = await _repositoryInfo.GetByIdFileObjectAsync(file.Id);
            if (fileDb is null)
            {
                throw new Exception($"file with this key: {file.Id} does not exist");
            }

            /*if (fileDb.File.Equals(file.File))
            {
                fileDb.File = file.File;
                fileDb.FileType = file.Name;
                fileDb.FileType = file.FileType;
            }
            await _repositoryInfo.UpdateFileObjectAsync(fileDb);*/
            await _repositoryInfo.UpdateFileObjectAsync(file.ConvertToDataBase());
        }

        public async Task AddFileObjectAsync(FileObject file)
        {
            var fileObject = new FileObjectDataBase(file.Id, file.Name, file.File, file.FileType);
            await _repositoryInfo.AddFileObjectAsync(fileObject);
        }

        public async Task<Guid> AddFileAsync(FileInformation file)
        {
            return await _repositoryInfo.AddFileAsync(file.ConvertToDataBase());
        }

        public async Task<IReadOnlyList<Guid>> DeleteFiles(IReadOnlyList<Guid> ids)
        {
            var NoneDeleteGuid = new List<Guid>();
            int i = 0;
            try
            {
                for (; i < ids.Count; i++)
                {
                    await _repositoryInfo.DeleteFileAsync(ids[i]);
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
            await _repositoryInfo.DeleteFileAsync(id);
        }
    }
}
