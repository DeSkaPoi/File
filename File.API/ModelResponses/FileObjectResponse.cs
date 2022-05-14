using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.ModelResponses
{
    public class FileObjectResponse
    {
        public byte[] File { get; set; }

        public FileObjectResponse(byte[] file)
        {
            File = file;
        }
    }
}
