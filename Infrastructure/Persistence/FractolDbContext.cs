using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Persistence
{
    public partial class FractolDbContext : DbContext, IFractolDbContext
    {
        public FractolDbContext()
        {
        }

        public FractolDbContext(DbContextOptions<FractolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Picklist> Picklist { get; set; }
        public virtual DbSet<PicklistHelper> PicklistHelper { get; set; }
        public virtual DbSet<Product> Product { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=tcp:cw-amr-esbbch-d-sqlsrv.database.windows.net,1433;Initial Catalog=cw-amr-esbbch-d-sqldb;Persist Security Info=False;User ID=ESB_SVC_DEV;Password=m(%eXW2Sz57k;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picklist>(entity =>
            {
                entity.ToTable("Picklist", "main");

                entity.Property(e => e.RowModified)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(user_name())");
            });
         }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
