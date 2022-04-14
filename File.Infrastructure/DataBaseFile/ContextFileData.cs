using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Infrastructure.DataBaseFile.ModelConnect;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using MongoDB.Bson;

namespace File.Infrastructure.DataBaseFile
{
    public class ContextFileData : IContextFileData
    {
        private readonly IGridFSBucket gridFS;
        public ContextFileData(IConnect connect)
        {
            var client = new MongoClient(connect.ConnectionString);
            var database = client.GetDatabase(connect.DatabaseName);
            gridFS = new GridFSBucket(database);
        }



    }
}
