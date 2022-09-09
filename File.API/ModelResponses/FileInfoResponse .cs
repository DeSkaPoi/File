﻿using System;

namespace File.API.ModelResponses
{
    public class FileInfoResponse
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public int? ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpDate { get; set; }
        public string Size { get; set; }
        //public PayloadFileResponse FileObject { get; set; }

        //public FileInfoResponse() { }

        public FileInfoResponse(Guid id, Guid documentId, string title, string format, string keyWords, string description, int? contentType,
            string content, DateTime creationTime, DateTime lastUpDate, string size/*, PayloadFileResponse fileObject*/)
        {
            Id = id;
            DocumentId = documentId;
            Title = title;
            Format = format;
            KeyWords = keyWords;
            Description = description;
            ContentType = contentType;
            Content = content;
            CreationTime = creationTime;
            LastUpDate = lastUpDate;
            Size = size;
            /*FileObject = fileObject*/;
        }
    }
}
