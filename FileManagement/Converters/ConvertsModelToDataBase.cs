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
            if (file.FileObj != null)
            {
                return new FileInfoDataBase(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                    file.CreationTime, file.LastUpDate, file.Size, new FileObjectDataBase(file.FileObj.Id, file.FileObj.Name, file.FileObj.File, file.FileObj.FileTypeMime));
            }
            throw new Exception("FileObject is null");
        }

        public static FileObjectDataBase ConvertToDataBase(this FileObject file)
        {
            return new FileObjectDataBase(file.Id, file.Name, file.File, file.FileTypeMime);
        }
    }
}
