using System;

namespace File.API.ModelResponses
{
    public class FilesInfoResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        //public FileInfoResponse() { }

        public FilesInfoResponse(Guid id, string title, string type)
        {
            Id = id;
            Title = title;
            Type = type;
        }
    }
}
