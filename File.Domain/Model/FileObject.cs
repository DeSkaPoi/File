using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.Model
{
    public class FileObject
    {
        public byte[] File { get; set; }

        public FileObject(byte[] file)
        {
            File = file;
        }
    }
}
