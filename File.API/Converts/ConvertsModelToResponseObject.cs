﻿using System.Collections.Generic;
using System.Linq;
using File.API.ModelResponses;
using File.Domain.Model;

namespace File.API.Converts
{
    public static class ConvertsModelToResponseObject
    {
        public static FileInfoResponse ConvertInfoToResponse(this FileInformation file)
        {
            if (file.FileObj != null)
            {
                return new FileInfoResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                    file.CreationTime, file.LastUpDate, file.Size, new PayloadFileResponse(file.FileObj.Id, file.FileObj.Name, file.FileObj.File, file.FileObj.FileTypeMime));
            }
            return new FileInfoResponse(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, null);
        }

        public static IReadOnlyList<FilesInfoResponse> ConvertInfoListToResponse(this IReadOnlyList<FileInformation> files)
        {
            var filesInfoResponses = files.Select(fileInfo => new FilesInfoResponse(fileInfo.Id, fileInfo.Title, fileInfo.FileObj.FileTypeMime)).ToList();
            return filesInfoResponses;
        }

        public static IReadOnlyList<FileInfoResponse> ConvertInfoToResponse(this IReadOnlyList<FileInformation> files)
        {
            return files.Select(file => file.ConvertInfoToResponse()).ToList();
        }

        public static PayloadFileResponse ConvertToResponse(this PayloadFile file)
        {
            return new PayloadFileResponse(file.Id, file.Name, file.File, file.FileTypeMime);
        }
    }
}
