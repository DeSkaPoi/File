using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.Model
{
    public class FileObject
    {
        public Guid IdFileInfo { get; private set; }
        public byte[] File { get; private set; }

        public FileObject(Guid idFileInfo ,byte[] file)
        {
            IdFileInfo = idFileInfo;
            File = file;
        }
    }
}
