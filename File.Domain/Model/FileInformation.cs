using System;

namespace File.Domain.Model
{
    public class FileInformation
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Format { get; private set; }
        public string KeyWords { get; private set; }
        public string Description { get; private set; }
        public int? ContentType { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpDate { get; private set; }
        public string Size { get; private set; }

        public PayloadFile FileObj { get; private set; }

        public FileInformation(Guid id, string title, string format, string keyWords, string description, int? contentType,
            string content, DateTime creationTime, DateTime lastUpDate, string size, PayloadFile fileObject)
        {
            Id = id;
            Title = title;
            Format = format;
            KeyWords = keyWords;
            Description = description;
            ContentType = contentType;
            Content = content;
            CreationTime = creationTime;
            LastUpDate = lastUpDate;
            Size = size;
            FileObj = fileObject;
        }
    }
}
