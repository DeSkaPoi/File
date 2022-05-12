using System.Collections.Generic;
using System.Linq;
using File.Domain.Model;

namespace File.API.Converts
{
    public static class ConvertsModelToResponseObject
    {
        public static FileInfoResponse ConvertToResponse(this FileInformation file)
        {
            FileObjectResponse fileObject = null;
            if (file.FileObj is not null)
            {
                fileObject = new FileObjectResponse(file.FileObj.File);
            }
            return new FileInfoResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, fileObject);
        }

        public static IReadOnlyList<FileInfoResponse> ConvertToModel(this IReadOnlyList<FileInformation> files)
        {
            return files.Select(file => file.ConvertToResponse()).ToList();
        }
    }
}
