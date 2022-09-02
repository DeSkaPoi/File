using System;

namespace File.Infrastructure.DBModel
{
    public class PayloadFileDataBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string FileType { get; set; }

        public FileInfoDataBase Manager { get; set; }

        public PayloadFileDataBase(Guid id, string name, byte[] file, string fileType)
        {
            Id = id;
            Name = name;
            File = file;
            FileType = fileType;
        }
    }
}
