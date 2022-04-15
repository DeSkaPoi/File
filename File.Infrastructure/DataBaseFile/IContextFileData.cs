using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using MongoDB.Bson;

namespace File.Infrastructure.DataBaseFile
{
    public interface IContextFileData
    {
        public Task<ObjectId> AddFileAsync(string name, Stream fileStream);
        public Task<Stream> GetFileAsync(ObjectId obj);

    }
}
