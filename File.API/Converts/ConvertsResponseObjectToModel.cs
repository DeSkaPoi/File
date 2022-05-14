using File.Domain.Model;
using File.Domain.ModelResponses;

namespace File.API.Converts
{
    public static class ConvertsResponseObjectToModel
    {
        public static FileInformation ConvertToModel(this FileInfoResponse file)
        {
            FileObject fileObject = null;
            if (file.FileObj is not null)
            {
                fileObject = new FileObject(file.FileObj.File);
            }
            return new FileInformation(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, fileObject);
        }
    }
}
