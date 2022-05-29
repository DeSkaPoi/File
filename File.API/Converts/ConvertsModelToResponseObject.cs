using System.Collections.Generic;
using System.Linq;
using File.Domain.Model;
using File.Domain.ModelResponses;

namespace File.API.Converts
{
    public static class ConvertsModelToResponseObject
    {
        public static FileInfoResponse ConvertInfoToResponse(this FileInformation file)
        {
            return new FileInfoResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size);
        }

        public static IReadOnlyList<FileInfoResponse> ConvertInfoToResponse(this IReadOnlyList<FileInformation> files)
        {
            return files.Select(file => file.ConvertInfoToResponse()).ToList();
        }

        public static FileObjectResponse ConvertToResponse(this FileObject file)
        {
            return new FileObjectResponse(file.Id, file.Name, file.File, file.FileType);
        }
    }
}
