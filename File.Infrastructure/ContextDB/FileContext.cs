using File.Infrastructure.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace File.Infrastructure.ContextDB
{
    public class FileContext : DbContext
    {
        public DbSet<FileInfoDataBase> Files { get; set; }
        public DbSet<PayloadFileDataBase> PayloadFile { get; set; }
        public FileContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileInfoDataBase>(tmp =>
            {
                tmp.Property(prop => prop.Content).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Description).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Format).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.KeyWords).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Size).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Title).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.ContentType).HasDefaultValue(null);
                tmp.Property(prop => prop.LastUpDate).HasDefaultValue(null);

                tmp.HasOne(fileManager => fileManager.FileObj)
                   .WithOne(fileObj => fileObj.Manager);
            });

            modelBuilder.Entity<PayloadFileDataBase>(fileObject =>
            {
                fileObject.HasKey(primaryKey => primaryKey.Id);
                fileObject.ToTable("PayloadFile");
                fileObject.Property(prop => prop.File).HasDefaultValue(null);
                
                fileObject
                    .HasOne(fileObj => fileObj.Manager)
                    .WithOne(fileManager => fileManager.FileObj)
                    .HasForeignKey<PayloadFileDataBase>(fileManager => fileManager.Id);
            });
        }
    }
}
