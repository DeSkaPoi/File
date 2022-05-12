using System.Collections.Generic;
using System.Linq;
using File.Domain.Model;
using File.Infrastructure.DBModel;

namespace File.Domain.Converters
{
    public static class ConverterDataBaseToModel
    {
        public static FileInformation ConvertToModel(this FileInfoDataBase fileManager)
        {
            var fileObject = new FileObject(fileManager.FileObj.File);
            return new FileInformation(fileManager.Id, fileManager.Title, fileManager.Format, fileManager.KeyWords, fileManager.Description, fileManager.ContentType, fileManager.Content,
                fileManager.CreationTime, fileManager.LastUpDate, fileManager.Size, fileObject);
        }

        public static IReadOnlyList<File.Domain.Model.FileInformation> ConvertToModel(this IReadOnlyList<FileInfoDataBase> fileManager)
        {
            return fileManager.Select(file => file.ConvertToModel()).ToList();
        }
    }
}
