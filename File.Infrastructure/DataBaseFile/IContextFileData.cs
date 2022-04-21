using MongoDB.Bson;
using System.IO;
using System.Threading.Tasks;

namespace File.Infrastructure.DataBaseFile
{
    public interface IContextFileData
    {
        public Task<ObjectId> AddFileAsync(string name, Stream fileStream);
        public Task<Stream> GetFileAsync(ObjectId obj);
        public Task UpdateFileAsync(string objectId, Stream streamPicture);
        public Task DeleteFileAsync(ObjectId obj);

    }
}
