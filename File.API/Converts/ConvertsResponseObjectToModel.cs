using File.Domain.Model;
using File.Domain.ModelResponses;

namespace File.API.Converts
{
    public static class ConvertsResponseObjectToModel
    {
        public static FileInformation ConvertToModel(this FileInfoResponse file)
        {
            return new FileInformation(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, null);
        }

        public static FileObject ConvertToModel(this FileObjectResponse file)
        {
            return new FileObject(file.Id, file.Name, file.File, file.FileType);
        }
    }
}
