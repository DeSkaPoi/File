using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.ModelResponses
{
    public class FileObjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string FileType { get; set; }

        public FileObjectResponse(Guid id, string name, byte[] file, string fileType)
        {
            Id = id;
            Name = name;
            File = file;
            FileType = fileType;
        }
    }
}
