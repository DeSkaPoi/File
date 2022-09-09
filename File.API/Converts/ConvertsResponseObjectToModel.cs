using System;
using File.API.ModelResponses;
using File.Domain.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace File.API.Converts
{
    public static class ConvertsResponseObjectToModel
    {
        public static FileInformation ConvertToModel(this FileInfoResponse file)
        {
            /*if (file.FileObject != null)
            {
                return new FileInformation(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                    file.CreationTime, file.LastUpDate, file.Size, new PayloadFile(file.FileObject.Name, file.FileObject.File, file.FileObject.FileTypeMime));
            }
            throw new Exception("FileObject is null");*/

            return new FileInformation(file.Id, file.DocumentId, file.Title, file.Format, file.KeyWords, file.Description,
                file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, null);
        }

        public static PayloadFile ConvertToModel(this PayloadFileResponse file)
        {
            return new PayloadFile(file.Name, file.File, file.FileTypeMime);
        }
    }
}
