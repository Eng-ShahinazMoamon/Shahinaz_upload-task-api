using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uploud_task_api.DAL.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<FileDetailEntity> FileDetailEntity{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //unique 
            modelBuilder.Entity<FileDetailEntity>().HasIndex(u => u.DocumentTitle).IsUnique();
            modelBuilder.Entity<FileDetailEntity>(e =>
            {
                e.Property(a => a.Id).ValueGeneratedOnAdd();
                e.Property(a => a.DocumentTitle).HasMaxLength(200).IsRequired().IsUnicode(true);
                e.Property(a => a.DocumentDescription).HasMaxLength(500).IsRequired().IsUnicode(true);
                e.Property(a => a.DocumentURL).HasMaxLength(200).IsRequired().IsUnicode(false);
                e.Property(a => a.CreationDate).IsRequired();
            } );
        }
    }
}
