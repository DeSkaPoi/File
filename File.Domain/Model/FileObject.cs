using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.Model
{
    public class FileObject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public byte[] File { get; private set; }
        public string FileType { get; private set; }

        public FileObject(Guid id, string name, byte[] file, string fileType)
        {
            Id = id;
            Name = name;
            File = file;
            FileType = fileType;
        }
    }
}
