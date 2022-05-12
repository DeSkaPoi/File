using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File.Domain.Model;
using File.Infrastructure.DBModel;

namespace FileManagement.Converters
{
    public static class ConvertsModelToDataBase
    {
        public static FileInfoDataBase ConvertToDataBase(this FileInformation fileManager)
        {
            var fileObject = new FileObjectDataBase(fileManager.FileObj.File);
            return new FileInfoDataBase(fileManager.Id, fileManager.Title, fileManager.Format, fileManager.KeyWords, fileManager.Description, fileManager.ContentType, fileManager.Content,
                fileManager.CreationTime, fileManager.LastUpDate, fileManager.Size, fileObject);
        }
    }
}
