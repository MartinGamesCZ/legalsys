using legalsys.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legalsys.Database
{
    class InvoiceContext : DbContext
    {
        public DbSet<InvoiceEntity> InvoiceSet { get; set; }

        public InvoiceContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = Invoices.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InvoiceEntity>().HasData(
                new InvoiceEntity
                {
                    Id = 1,
                    CustomerName = "Fake s.r.o.",
                    CustomerAddress = "Falešná 98 Falešnov 520 01",
                    CustomerCIN = "123 45 678",
                    ServiceName = ServiceName.FinancialAdvisory,
                    Hours = 3,
                    Rate = 6000,
                    Currency = Currency.CZK
                }
            );
        }
    }
}