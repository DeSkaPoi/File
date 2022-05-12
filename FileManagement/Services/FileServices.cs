using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Converters;
using File.Domain.Model;
using File.Infrastructure.RepositoryDB;
using FileManagement.Converters;

namespace File.Domain.Services
{
    public class FileServices
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
                new Exception($"not found file {id}");
            }
            var filesModel = fileDb.ConvertToModel();
            return filesModel;
        }

        public async Task ChangeFileManagerAsync(Guid id, FileInformation file)
        {
            if (id != file.Id)
            {
                new Exception("No match between id and object");
            }
             
            await _repository.UpdateFileAsync(file.ConvertToDataBase());
        }

        public async Task PostFileManagerAsync(FileInformation file)
        {
            await _repository.AddFileAsync(file.ConvertToDataBase());
        }

        public async Task<IReadOnlyList<Guid>> DeleteFileManagerRange(IReadOnlyList<Guid> ids)
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

        public async Task DeleteFileManager(Guid id)
        { 
            await _repository.DeleteFileAsync(id);
        }
    }
}
