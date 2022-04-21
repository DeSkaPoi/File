using File.Infrastructure.DataBaseFile.ModelConnect;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Threading.Tasks;

namespace File.Infrastructure.DataBaseFile
{
    public class ContextFileData : IContextFileData
    {
        private readonly IGridFSBucket _gridFs;
        public ContextFileData(IConnect connect)
        {
            var client = new MongoClient(connect.ConnectionString);
            var database = client.GetDatabase(connect.DatabaseName);
            _gridFs = new GridFSBucket(database);
        }

        public async Task<ObjectId> AddFileAsync(string name, Stream fileStream)
        {
            return await _gridFs.UploadFromStreamAsync(name, fileStream);
        }

        public async Task<Stream> GetFileAsync(ObjectId obj)
        {
            Stream stream = new MemoryStream();
            await _gridFs.DownloadToStreamAsync(obj, stream);
            stream.Close();
            return stream;
        }

        public async Task UpdateFileAsync(string objectId, Stream streamPicture)
        {
            var objId = ObjectId.Parse(objectId);
        }

        public async Task DeleteFileAsync(ObjectId obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
