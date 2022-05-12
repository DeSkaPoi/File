using System.Collections.Generic;
using System.Linq;
using File.Domain.Model;
using File.Infrastructure.DBModel;

namespace File.Domain.Converters
{
    public static class ConverterDataBaseToModel
    {
        public static FileInformation ConvertToModel(this FileInfoDataBase file)
        {
            FileObject fileObject = null;
            if (file.FileObj is not null)
            {
                fileObject = new FileObject(file.FileObj.File);
            }
            return new FileInformation(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, fileObject);
        }

        public static IReadOnlyList<FileInformation> ConvertToModel(this IReadOnlyList<FileInfoDataBase> files)
        {
            return files.Select(file => file.ConvertToModel()).ToList();
        }
    }
}
