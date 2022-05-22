using System;

namespace File.Domain.ModelResponses
{
    public class FileResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public int? ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpDate { get; set; }
        public string Size { get; set; }
        public FileObjectResponse FileObj { get; set; }

        //public FileInfoResponse() { }

        public FileResponse(Guid id, string title, string format, string keyWords, string description, int? contentType,
            string content, DateTime creationTime, DateTime lastUpDate, string size, FileObjectResponse fileObj)
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
            FileObj = fileObj;
        }
    }
}
