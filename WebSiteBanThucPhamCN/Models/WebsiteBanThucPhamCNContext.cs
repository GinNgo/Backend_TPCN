using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebSiteBanThucPhamCN.Models
{
    public partial class WebsiteBanThucPhamCNContext : DbContext
    {
        public WebsiteBanThucPhamCNContext()
        {
        }

        public WebsiteBanThucPhamCNContext(DbContextOptions<WebsiteBanThucPhamCNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccount { get; set; }
        public virtual DbSet<TblBrand> TblBrand { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblImage> TblImage { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetail { get; set; }
        public virtual DbSet<TblProMappingCat> TblProMappingCat { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblSlide> TblSlide { get; set; }
        public virtual DbSet<TblSuggested> TblSuggested { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=LAPTOP-8RK08EOK\\MSSQLSERVER2019; Initial Catalog=WebsiteBanThucPhamCN; trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK__tbl_Acco__91CBC37819394815");

                entity.ToTable("tbl_Account");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__tbl_Bran__DAD4F05EE55B78CA");

                entity.ToTable("tbl_Brand");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__tbl_Cate__6A1C8AFA7577B803");

                entity.ToTable("tbl_Category");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.ToTable("tbl_Image");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tbl_Orde__C3905BCF967C8026");

                entity.ToTable("tbl_Order");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__tbl_Orde__E4FEDE4A3E8B8DE4");

                entity.ToTable("tbl_OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<TblProMappingCat>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__tbl_Pro___8B57819DC8661769");

                entity.ToTable("tbl_Pro_mapping_Cat");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tbl_Prod__B40CC6CD55686CB6");

                entity.ToTable("tbl_Product");

                entity.Property(e => e.FullDesc)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ShortDesc).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblSlide>(entity =>
            {
                entity.ToTable("tbl_Slide");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblSuggested>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__tbl_Sugg__5C66259B6B18519E");

                entity.ToTable("tbl_Suggested");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_User__1788CC4CD1C52EA2");

                entity.ToTable("tbl_User");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
