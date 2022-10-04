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
        public async Task<PayloadFile> GetPayloadFileAsync(Guid idFile)
        {
            var fileDataBase = await _payloadRepository.GetByIdPayloadFileAsync(idFile);
            return fileDataBase.ConvertToModel();
        }

        public async Task ChangeFileAsync(Guid idFile, PayloadFile file)
        {
            await _payloadRepository.DeleteFileAsync(idFile);
            var editingFile = file.ConvertToDataBase(idFile);
            await _payloadRepository.AddPayloadFileAsync(editingFile);
        }

        public async Task AddFileAsync(Guid idFile, PayloadFile file)
        {
            var addedFile = file.ConvertToDataBase(idFile);
            await _payloadRepository.AddPayloadFileAsync(addedFile);
        }

        public async Task DeleteFileAsync(Guid id)
        {
            await _payloadRepository.DeleteFileAsync(id);
        }
    }
}
