using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using File.Domain;



namespace File.Infrastructure
{
    public class FileContext : DbContext
    {
        public DbSet<FileManager> Files { get; set; }
        public FileContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileManager>(tmp => 
            {
                tmp.Property(prop => prop.Content).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Description).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Format).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.KeyWords).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Size).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Title).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.ContentType).HasDefaultValue(null);
                tmp.Property(prop => prop.LastUpDate).HasDefaultValue(null);
                tmp.Property(prop => prop.BelongDocument).HasDefaultValue(false);
            });
        }
    }
}
