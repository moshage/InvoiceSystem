using Microsoft.EntityFrameworkCore;
using NFSystem.Models;

namespace NFSystem.Data
{
    public class InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : DbContext(options)
    {
        public DbSet<Invoices> ServiceInvoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoices>()
                .Property(n => n.CnpjServiceProvider)
                .HasColumnType("char(14)");

            modelBuilder.Entity<Invoices>()
                .Property(n => n.CnpjTaker)
                .HasColumnType("char(14)");

            modelBuilder.Entity<Invoices>()
                .Property(n => n.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoices>()
                .Property(n => n.CriationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
