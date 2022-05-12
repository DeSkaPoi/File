using System;

namespace File.Infrastructure.DBModel
{
    public class FileObjectDataBase
    {
        public Guid Id { get; set; }
        public byte[] File { get; set; }

        public Guid FileManagerId { get; set; }
        public FileInfoDataBase Manager { get; set; }

        
        public FileObjectDataBase(byte[] file)
        {
            File = file;
        }
    }
}
