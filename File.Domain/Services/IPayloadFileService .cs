using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using File.Domain.Model;

namespace File.Domain.Services
{
    public interface IPayloadFileService
    {
        public Task<PayloadFile> GetPayloadFileAsync(Guid idFile);
        public Task ChangeFileAsync(Guid id, PayloadFile file);
        public Task AddFileAsync(Guid idFile, PayloadFile file);
        public Task DeleteFileAsync(Guid id);
    }
}
