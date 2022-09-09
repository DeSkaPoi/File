using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Infrastructure.DBModel;

namespace File.Infrastructure.RepositoryDB
{
    public interface IPayloaadFileRepository
    {
        public Task<PayloadFileDataBase> GetByIdPayloadFileAsync(Guid idDoc, Guid idFile);
        public Task<Guid> AddPayloadFileAsync(PayloadFileDataBase file);
        public Task DeleteFileAsync(Guid idFile);
    }
}
