using System;

namespace File.API.ModelResponses
{
    public class PayloadFileResponse
    {
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string FileTypeMime { get; set; }

        public PayloadFileResponse(string name, byte[] file, string fileTypeMime)
        {
            Name = name;
            File = file;
            FileTypeMime = fileTypeMime;
        }
    }
}
