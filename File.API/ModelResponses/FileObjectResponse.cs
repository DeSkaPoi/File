using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.ModelResponses
{
    public class FileObjectResponse
    {
        public Guid IdFileInfo { get; set; }
        public byte[] File { get; set; }

        public FileObjectResponse(Guid idFileInfo, byte[] file)
        {
            IdFileInfo = idFileInfo;
            File = file;
        }
    }
}
