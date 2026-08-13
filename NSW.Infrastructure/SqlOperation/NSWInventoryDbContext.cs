using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NSW.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Infrastructure.SqlOperation
{
    public class NSWInventoryDbContext:IdentityDbContext<Users,Roles,string>
    {
        public NSWInventoryDbContext(DbContextOptions<NSWInventoryDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<StockLevels> StockLevels { get; set; }
        public DbSet<StockTransactions> StockTransactions { get; set; }
        public DbSet<StockTransfers> StockTransfers { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
        public DbSet<LowStockAlerts> LowStockAlerts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<SalesIssueItems> SalesIssueItems { get; set; }
        public DbSet<SalesIssues> SalesIssues { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            ConfigureProduct(builder);
            ConfigureStockLevels(builder);
            ConfigureStockTransactions(builder);
            ConfigureStockTransfers(builder);
            ConfigureWarehouses(builder);
            ConfigureLowStockAlerts(builder);
            ConfigureCategories(builder);
            ConfigurePurchaseOrderItems(builder);
            ConfigurePurchaseOrders(builder);
            ConfigureSalesIssueItems(builder);
            ConfigureSalesIssues(builder);
            ConfigureSuppliers(builder);
        }
        public void ConfigureProduct(ModelBuilder builder)
        {
            var product = builder.Entity<Products>();
            product.HasKey(p => p.ProdId);
            product.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            product.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            product.Property(x => x.CategoryId).IsRequired();
            product.Property(x=>x.SKU).IsRequired();
            product.Property(x => x.BarCode).IsRequired();
            product.Property(x => x.ProdId).ValueGeneratedOnAdd();
            product.HasIndex(x => x.SKU).IsUnique();
            product.HasIndex(x => x.BarCode).IsUnique();
            product.HasMany(x => x.StockLevels).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
            product.HasMany(x => x.StockTransactions).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
            product.HasMany(x => x.SalesIssueItems).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
            product.HasMany(x => x.StockTransfers).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
            product.HasMany(x => x.LowStockAlerts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            product.HasMany(x => x.PurchaseOrderItems).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
        }
        public void ConfigureStockLevels(ModelBuilder builder)
        {
            var stockLevel = builder.Entity<StockLevels>();
            stockLevel.HasKey(x => x.Id); 
            stockLevel.Property(x => x.ProductId).IsRequired();
            stockLevel.Property(x => x.WareHouseId).IsRequired();
            stockLevel.Property(x=>x.QuantityOnHand).HasDefaultValue(0);
            stockLevel.HasIndex(x => x.ProductId);
            stockLevel.HasIndex(x => x.WareHouseId);
            stockLevel.HasOne(x => x.Products).WithMany(x => x.StockLevels).
                HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            stockLevel.HasOne(x => x.Warehouses).WithMany(x => x.StockLevels).
           HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);
            stockLevel.Property(x => x.Id).ValueGeneratedOnAdd();
        }
        public void ConfigureStockTransactions(ModelBuilder builder)
        {
            var stockTransaction = builder.Entity<StockTransactions>();
            stockTransaction.HasKey(x => x.Id);
            stockTransaction.HasOne(x => x.Products).WithMany(x => x.StockTransactions).
                HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            stockTransaction.HasOne(x => x.Warehouses).WithMany(x => x.StockTransactions).
                HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);
            stockTransaction.Property(x => x.Id).ValueGeneratedOnAdd();
            stockTransaction.Property(x=>x.ReferenceId).HasColumnType("uniqueidentifier");
            stockTransaction.Property(x=>x.CreatedAt).HasDefaultValueSql("GETDATE()");
            stockTransaction.HasIndex(x => x.ProductId);
            stockTransaction.HasIndex(x => x.WareHouseId);
        }
        public void ConfigureStockTransfers(ModelBuilder builder)
        {
            var transfers = builder.Entity<StockTransfers>();
            transfers.HasKey(x => x.Id);
            transfers.Property(x => x.Id).ValueGeneratedOnAdd();
            transfers.Property(x => x.Quantity).HasDefaultValue(0);
            transfers.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            transfers.Property(x => x.Status).HasMaxLength(50);

            transfers.HasOne(x => x.Products).WithMany(x => x.StockTransfers)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

            transfers.HasOne(x => x.FromWarehouses).WithMany(x => x.TransfersFrom)
                .HasForeignKey(x => x.FromWareHouseId).OnDelete(DeleteBehavior.Restrict);

            transfers.HasOne(x => x.ToWarehouses).WithMany(x => x.TransfersTo)                                                          
                .HasForeignKey(x => x.ToWareHouseId).OnDelete(DeleteBehavior.Restrict);

            transfers.HasIndex(x => x.ProductId);
            transfers.HasIndex(x => x.FromWareHouseId);
            transfers.HasIndex(x => x.ToWareHouseId);
        }
        public void ConfigureWarehouses(ModelBuilder builder)
        {
            var wh = builder.Entity<Warehouses>();
            wh.HasKey(x => x.Id);
            wh.Property(x => x.Id).ValueGeneratedOnAdd();
            wh.Property(x => x.Name).IsRequired().HasMaxLength(100);
            wh.Property(x => x.Location).HasMaxLength(200);
            wh.Property(x => x.ManagerId).HasMaxLength(450);

            wh.HasMany(x => x.PurchaseOrders).WithOne(x => x.Warehouses)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.LowStockAlerts).WithOne(x => x.Warehouses)
                .HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.StockLevels).WithOne(x => x.Warehouses)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.StockTransactions).WithOne(x => x.Warehouses)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.SalesIssues).WithOne(x => x.Warehouses)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.TransfersFrom).WithOne(x => x.FromWarehouses)
                .HasForeignKey(x => x.FromWareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasMany(x => x.TransfersTo).WithOne(x => x.ToWarehouses)
                .HasForeignKey(x => x.ToWareHouseId).OnDelete(DeleteBehavior.Restrict);

            wh.HasIndex(x => x.ManagerId);
        }
        public void ConfigureLowStockAlerts(ModelBuilder builder)
        {
            var alert = builder.Entity<LowStockAlerts>();
            alert.HasKey(x => x.Id);
            alert.Property(x => x.Id).ValueGeneratedOnAdd();
            alert.Property(x => x.TriggeredAt).HasDefaultValueSql("GETDATE()");
            alert.Property(x => x.IsResolved).HasDefaultValue(false);

            alert.HasOne(x => x.Product).WithMany(x => x.LowStockAlerts)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

            alert.HasOne(x => x.Warehouses).WithMany(x => x.LowStockAlerts)
                .HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Restrict);

            alert.HasIndex(x => x.ProductId);
            alert.HasIndex(x => x.WarehouseId);
        }
        public void ConfigureCategories(ModelBuilder builder)
        {
            var cat = builder.Entity<Categories>();
            cat.HasKey(x => x.CatId);
            cat.Property(x => x.CatId).ValueGeneratedOnAdd();
            cat.Property(x => x.Name).IsRequired().HasMaxLength(100);
            cat.Property(x => x.Description).HasMaxLength(500);

            cat.HasMany(x => x.Products).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            cat.HasIndex(x => x.Name).IsUnique(false);
        }
        public void ConfigurePurchaseOrderItems(ModelBuilder builder)
        {
            var poi = builder.Entity<PurchaseOrderItems>();
            poi.HasKey(x => x.Id);
            poi.Property(x => x.Id).ValueGeneratedOnAdd();
            poi.Property(x => x.Quantity).HasDefaultValue(0);
            poi.Property(x => x.UnitCost).HasDefaultValue(0);

            poi.HasOne(x => x.PurchaseOrders).WithMany(x => x.PurchaseOrderItems)
                .HasForeignKey(x => x.PurchaseId).OnDelete(DeleteBehavior.Restrict);

            poi.HasOne(x => x.Products).WithMany(x => x.PurchaseOrderItems)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

            poi.HasIndex(x => x.PurchaseId);
            poi.HasIndex(x => x.ProductId);
        }
        public void ConfigurePurchaseOrders(ModelBuilder builder)
        {
            var po = builder.Entity<PurchaseOrders>();
            po.HasKey(x => x.Id);
            po.Property(x => x.Id).ValueGeneratedOnAdd();
            po.Property(x => x.Status).HasMaxLength(50);
            po.Property(x => x.OrderDate).HasDefaultValueSql("GETDATE()");

            po.HasOne(x => x.Supplier).WithMany(x => x.PurchaseOrders)
                .HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.Restrict);

            po.HasOne(x => x.Warehouses).WithMany(x => x.PurchaseOrders)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            po.HasIndex(x => x.SupplierId);
            po.HasIndex(x => x.WareHouseId);
        }
        public void ConfigureSalesIssueItems(ModelBuilder builder)
        {
            var sii = builder.Entity<SalesIssueItems>();
            sii.HasKey(x => x.Id);
            sii.Property(x => x.Id).ValueGeneratedOnAdd();
            sii.Property(x => x.Quantity).HasDefaultValue(0);

            sii.HasOne(x => x.SalesIssues).WithMany(x => x.SalesIssueItems)
                .HasForeignKey(x => x.SalesIssueId).OnDelete(DeleteBehavior.Restrict);

            sii.HasOne(x => x.Products).WithMany(x => x.SalesIssueItems)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

            sii.HasIndex(x => x.SalesIssueId);
            sii.HasIndex(x => x.ProductId);
        }
        public void ConfigureSalesIssues(ModelBuilder builder)
        {
            var si = builder.Entity<SalesIssues>();
            si.HasKey(x => x.Id);
            si.Property(x => x.Id).ValueGeneratedOnAdd();
            si.Property(x => x.IssuedDate).HasDefaultValueSql("GETDATE()");
            si.Property(x => x.Status).HasMaxLength(50);

            si.HasOne(x => x.Warehouses).WithMany(x => x.SalesIssues)
                .HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.Restrict);

            si.HasMany(x => x.SalesIssueItems).WithOne(x => x.SalesIssues)
                .HasForeignKey(x => x.SalesIssueId).OnDelete(DeleteBehavior.Restrict);

            si.HasIndex(x => x.WareHouseId);
        }
        public void ConfigureSuppliers(ModelBuilder builder)
        {
            var sup = builder.Entity<Suppliers>();
            sup.HasKey(x => x.Id);
            sup.Property(x => x.Id).ValueGeneratedOnAdd();
            sup.Property(x => x.Name).IsRequired().HasMaxLength(200);
            sup.Property(x => x.ContactInfo).HasMaxLength(500);
            sup.Property(x => x.Address).HasMaxLength(500);

            sup.HasMany(x => x.PurchaseOrders).WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.Restrict);

            sup.HasIndex(x => x.Name);
        }
    }
}
