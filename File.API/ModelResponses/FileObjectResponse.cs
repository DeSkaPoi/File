using System;

namespace File.API.ModelResponses
{
    public class FileObjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string FileTypeMime { get; set; }

        public FileObjectResponse(Guid id, string name, byte[] file, string fileTypeMime)
        {
            Id = id;
            Name = name;
            File = file;
            FileTypeMime = fileTypeMime;
        }
    }
}
