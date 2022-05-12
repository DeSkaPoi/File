using System;
using System.IO;

namespace File.API.Responses
{
    public class ResponseFile
    {
        public Guid FileId { get; }
        public byte[] Content { get; }

        public ResponseFile(Guid filetId, byte[] content)
        {
            FileId = filetId;
            Content = content;
        }
    }
}
