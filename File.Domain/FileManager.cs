using System;

namespace File.Domain
{
    public class FileManager
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ObjectId { get; set; }
        public string Format { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public int? ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpDate { get; set; }
        public string Size { get; set; }
    }
}
