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
        public static FileInfoDataBase ConvertToDataBase(this FileInformation file)
        {
            FileObjectDataBase fileObject = null;
            if (file.FileObj is not null)
            {
                fileObject = new FileObjectDataBase(file.FileObj.File);
            }
            return new FileInfoDataBase(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, fileObject);
        }
    }
}
