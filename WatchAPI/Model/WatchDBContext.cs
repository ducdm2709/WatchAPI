using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WatchAPI.Model
{
    public partial class WatchDBContext : DbContext
    {
        public WatchDBContext()
        {
        }

        public WatchDBContext(DbContextOptions<WatchDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillDetail> BillDetail { get; set; }
        public virtual DbSet<InfoAccount> InfoAccount { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<TopSell> TopSell { get; set; }
        public virtual DbSet<TradeMark> TradeMark { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Database=WatchDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CustomerName).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillDetail_Bill");

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillDetail_Product");
            });

            modelBuilder.Entity<InfoAccount>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.InfoAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InfoAccount_Account");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.WatchId);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.WatchName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.TradeMark)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TradeMarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_TradeMark");
            });

            modelBuilder.Entity<Storages>(entity =>
            {
                entity.HasKey(e => e.StorageId);

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storages_Product");
            });

            modelBuilder.Entity<TopSell>(entity =>
            {
                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.TopSell)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopSell_Product");
            });

            modelBuilder.Entity<TradeMark>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.TradeMarkName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
