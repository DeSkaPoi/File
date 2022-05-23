using System.Collections.Generic;
using System.Linq;
using File.Domain.Model;
using File.Domain.ModelResponses;

namespace File.API.Converts
{
    public static class ConvertsModelToResponseObject
    {
        public static FileResponse ConvertToResponse(this FileInformation file)
        {
            FileObjectResponse fileObject = null;
            if (file.FileObj is not null)
            {
                fileObject = file.FileObj.ConvertToResponse();
            }
            return new FileResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, fileObject);
        }

        public static FileInfoResponse ConvertInfoToResponse(this FileInformation file)
        {
            return new FileInfoResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size);
        }

        public static IReadOnlyList<FileInfoResponse> ConvertInfoToResponse(this IReadOnlyList<FileInformation> files)
        {
            return files.Select(file => file.ConvertInfoToResponse()).ToList();
        }

        public static IReadOnlyList<FileResponse> ConvertToResponse(this IReadOnlyList<FileInformation> files)
        {
            return files.Select(file => file.ConvertToResponse()).ToList();
        }

        public static FileObjectResponse ConvertToResponse(this FileObject file)
        {
            return new FileObjectResponse(file.IdFileInfo, file.File);
        }
    }
}
