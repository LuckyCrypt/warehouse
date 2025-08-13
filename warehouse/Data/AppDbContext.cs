using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using System.Data;
using warehouse.Data.Models;

namespace warehouse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Resources> Resources { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<ReceiptDocument> ReceiptDocuments { get; set; }
        public DbSet<ReceiptResource> ReceiptResources { get; set; }
        public DbSet<ShipmentDocument> ShipmentDocuments { get; set; }
        public DbSet<ShipmentResource> ShipmentResources { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<StockBalance> StockBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Уникальные индексы для имен и номеров
            modelBuilder.Entity<Resources>()
                .HasIndex(r => r.Name)
                .IsUnique();
            modelBuilder.Entity<Units>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Clients>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<ReceiptDocument>()
                .HasIndex(rd => rd.Number)
                .IsUnique();
            modelBuilder.Entity<ShipmentDocument>()
                .HasIndex(sd => sd.Number)
                .IsUnique();
            modelBuilder.Entity<StockBalance>()
                .HasIndex(sd => sd.Id)
                .IsUnique(); 

            modelBuilder.Entity<StockBalance>();
            // Связи для ReceiptResource
            modelBuilder.Entity<ReceiptResource>()
                .HasOne(rr => rr.ReceiptDocument)
                .WithMany(rd => rd.ReceiptResources)
                .HasForeignKey(rr => rr.ReceiptDocumentId);
            modelBuilder.Entity<ReceiptResource>()
                .HasOne(rr => rr.Resource)
                .WithMany()
                .HasForeignKey(rr => rr.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ReceiptResource>()
                .HasOne(rr => rr.Unit)
                .WithMany()
                .HasForeignKey(rr => rr.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
            // Связи для ShipmentResource
            modelBuilder.Entity<ShipmentResource>()
                .HasOne(sr => sr.ShipmentDocument)
                .WithMany(sd => sd.ShipmentResources)
                .HasForeignKey(sr => sr.ShipmentDocumentId);
            modelBuilder.Entity<ShipmentResource>()
                .HasOne(sr => sr.Resource)
                .WithMany()
                .HasForeignKey(sr => sr.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ShipmentResource>()
                .HasOne(sr => sr.Unit)
                .WithMany()
                .HasForeignKey(sr => sr.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
            //Связи для StockBalance
            modelBuilder.Entity<StockBalance>()
                .HasOne(sr => sr.Resource)
                .WithMany()
                .HasForeignKey(sr => sr.ResourceId);
            modelBuilder.Entity<StockBalance>()
                .HasOne(sr => sr.Unit)
                .WithMany()
                .HasForeignKey(sr => sr.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
