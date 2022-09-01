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
            var payload = file.FileObj.ConvertToModel();
            return new FileInformation(file.Id, file.Title, file.Format, file.KeyWords, file.Description, file.ContentType, file.Content,
                file.CreationTime, file.LastUpDate, file.Size, payload);
        }

        public static PayloadFile ConvertToModel(this FileObjectDataBase file)
        {
            if (file is not null)
            {
                return new PayloadFile(file.Name, file.File, file.FileType);
            }

            return null;
        }
        public static IReadOnlyList<FileInformation> ConvertToModel(this IReadOnlyList<FileInfoDataBase> files)
        {
            return files.Select(file => file.ConvertToModel()).ToList();
        }

        public static IReadOnlyList<PayloadFile> ConvertToModel(this IReadOnlyList<FileObjectDataBase> files)
        {
            return files.Select(file => new PayloadFile(file.Name, file.File, file.FileType)).ToList();
        }
    }
}
