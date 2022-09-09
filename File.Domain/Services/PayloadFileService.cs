using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Converters;
using File.Domain.Model;
using File.Infrastructure.DBModel;
using File.Infrastructure.RepositoryDB;

namespace File.Domain.Services
{
    public class PayloadFileService : IPayloadFileService
    {
        private readonly IPayloaadFileRepository _payloadRepository;
        public PayloadFileService(IPayloaadFileRepository payloadRepository)
        {
            _payloadRepository = payloadRepository;
        }
        public async Task<PayloadFile> GetPayloadFileAsync(Guid idDoc, Guid idFile)
        {
            var fileDataBase = await _payloadRepository.GetByIdPayloadFileAsync(idDoc, idFile);
            return fileDataBase.ConvertToModel();
        }

        public async Task ChangeFileAsync(Guid id, PayloadFile file)
        {
            await _payloadRepository.DeleteFileAsync(id);
            var editingFile = new PayloadFileDataBase(id, file.Name, file.File, file.FileTypeMime);
            await _payloadRepository.AddPayloadFileAsync(editingFile);
        }

        public async Task AddFileAsync(Guid idFile, PayloadFile file)
        {
            var addedFile = new PayloadFileDataBase(idFile, file.Name, file.File, file.FileTypeMime);
            await _payloadRepository.AddPayloadFileAsync(addedFile);
        }

        public async Task DeleteFileAsync(Guid id)
        {
            await _payloadRepository.DeleteFileAsync(id);
        }
    }
}
