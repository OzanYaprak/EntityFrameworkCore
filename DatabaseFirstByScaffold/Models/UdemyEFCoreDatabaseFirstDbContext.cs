using System;
using System.Collections.Generic;
using DatabaseFirst.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DatabaseFirstByScaffold.Models
{
    public partial class UdemyEFCoreDatabaseFirstDbContext : DbContext
    {
        public UdemyEFCoreDatabaseFirstDbContext()
        {
        }

        public UdemyEFCoreDatabaseFirstDbContext(DbContextOptions<UdemyEFCoreDatabaseFirstDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UdemyEFCoreDatabaseFirstDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;");
                optionsBuilder.UseSqlServer(DbContextInitilizer.Configuration.GetConnectionString("SQLConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
