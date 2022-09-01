using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Model;

namespace File.Domain.Services
{
    public class PayloadFileService : IPayloadFileService
    {
        public Task<PayloadFile> GetPayloadFileAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ChangeFileAsync(Guid id, PayloadFile file)
        {
            throw new NotImplementedException();
        }

        public Task AddFileAsync(Guid idFile, PayloadFile file)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFileAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
